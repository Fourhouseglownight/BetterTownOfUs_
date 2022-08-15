using System.Linq;
using HarmonyLib;
using UnityEngine;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.SpyMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static Sprite SpySprite => BetterTownOfUs.SpySprite;

        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Spy)) return;
            var role = Role.GetRole<Spy>(PlayerControl.LocalPlayer);
            if (role.SpyButton == null)
            {
                role.SpyButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.SpyButton.graphic.enabled = true;
                role.SpyButton.GetComponent<AspectPosition>().DistanceFromEdge = BetterTownOfUs.ButtonPosition;
                role.SpyButton.gameObject.SetActive(false);
            }

            role.SpyButton.GetComponent<AspectPosition>().Update();
            role.SpyButton.graphic.sprite = SpySprite;
            role.SpyButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead && !MeetingHud.Instance);

            if (role.Enabled)
            {
                role.SpyButton.SetCoolDown(role.TimeRemaining, CustomGameOptions.SpyDuration);
                return;
            }

            role.SpyButton.SetCoolDown(role.SpyTimer(), CustomGameOptions.SpyCd);

            var system = ShipStatus.Instance.Systems[SystemTypes.Sabotage].Cast<SabotageSystemType>();
            var specials = system.specials.ToArray();
            var dummyActive = system.dummy.IsActive;
            var sabActive = specials.Any(s => s.IsActive);

            if (sabActive & !dummyActive)
            {
                role.SpyButton.graphic.color = Palette.DisabledClear;
                role.SpyButton.graphic.material.SetFloat("_Desat", 1f);
                return;
            }

            role.SpyButton.graphic.color = Palette.EnabledColor;
            role.SpyButton.graphic.material.SetFloat("_Desat", 0f);
        }
    }
}