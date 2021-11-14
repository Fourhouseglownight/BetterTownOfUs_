using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.ImpostorRoles.LycanMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static Sprite LycanSprite => BetterTownOfUs.MorphSprite;

        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Lycan)) return;
            var role = Role.GetRole<Lycan>(PlayerControl.LocalPlayer);
            if (role.LycanButton == null)
            {
                role.LycanButton = UnityEngine.Object.Instantiate(__instance.KillButton, HudManager.Instance.transform);
                role.LycanButton.renderer.enabled = true;
            }

            role.LycanButton.renderer.sprite = LycanSprite;
            role.LycanButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead && !MeetingHud.Instance);
            var position = __instance.KillButton.transform.localPosition;
            role.LycanButton.transform.localPosition = new Vector3(position.x, __instance.ReportButton.transform.localPosition.y, position.z);

            if (role.Wolfed)
            {
                role.LycanButton.SetCoolDown(role.TimeRemaining, CustomGameOptions.WolfDuration);
                return;
            }
            role.LycanButton.SetCoolDown(role.WolfTimer(), CustomGameOptions.WolfCd);
            role.LycanButton.renderer.color = Palette.EnabledColor;
            role.LycanButton.renderer.material.SetFloat("_Desat", 0f);
        }
    }
}