using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.CrewmateRoles.EngineerMod
{
    [HarmonyPatch(typeof(HudManager))]
    public class KillButtonSprite
    {
        private static Sprite Sprite => BetterTownOfUs.EngineerFix;


        [HarmonyPatch(nameof(HudManager.Update))]
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Engineer)) return;
            if (__instance.KillButton == null) return;

            var role = Role.GetRole<Engineer>(PlayerControl.LocalPlayer);

            __instance.KillButton.renderer.sprite = Sprite;
            if ((CustomGameOptions.EngineerFixPer == EngineerFixPer.Custom) && CustomGameOptions.IsCdEngineer) __instance.KillButton.SetCoolDown(role.EngineerTimer(), CustomGameOptions.EngineerCd);
            else __instance.KillButton.SetCoolDown(0f, 10f);
            __instance.KillButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead &&
                                                       __instance.UseButton.isActiveAndEnabled && !MeetingHud.Instance);

            if (PlayerControl.LocalPlayer.Data.IsDead) return;
            if (!ShipStatus.Instance) return;
            var renderer = __instance.KillButton.renderer;
            if (Utils.IsSabotageActive() && !role.UsedThisRound & __instance.KillButton.enabled)
            {
                renderer.color = Palette.EnabledColor;
                renderer.material.SetFloat("_Desat", 0f);
                return;
            }

            renderer.color = Palette.DisabledClear;
            renderer.material.SetFloat("_Desat", 1f);
        }
    }
}