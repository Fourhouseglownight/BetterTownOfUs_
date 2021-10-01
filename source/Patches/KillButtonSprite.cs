using HarmonyLib;
using UnityEngine;

namespace BetterTownOfUs
{
    [HarmonyPatch(typeof(KillButtonManager), nameof(KillButtonManager.Start))]
    public static class KillButtonAwake
    {
        public static void Prefix(KillButtonManager __instance)
        {
            __instance.transform.Find("Text_TMP").gameObject.SetActive(false);
        }
    }
    
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class KillButtonSprite
    {
        private static Sprite Shift => BetterTownOfUs.Shift;
        private static Sprite Rewind => BetterTownOfUs.Rewind;
        private static Sprite Medic => BetterTownOfUs.MedicSprite;
        private static Sprite Seer => BetterTownOfUs.SeerSprite;
        private static Sprite Douse => BetterTownOfUs.DouseSprite;

        private static Sprite Revive => BetterTownOfUs.ReviveSprite;

        private static Sprite Button => BetterTownOfUs.ButtonSprite;


        public static void Postfix(HudManager __instance)
        {
            if (__instance.KillButton == null) return;

            var flag = false;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Shifter))
            {
                __instance.KillButton.renderer.sprite = Shift;
                flag = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.TimeLord))
            {
                __instance.KillButton.renderer.sprite = Rewind;
                flag = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.Seer))
            {
                __instance.KillButton.renderer.sprite = Seer;
                flag = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.Medic))
            {
                __instance.KillButton.renderer.sprite = Medic;
                flag = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.Arsonist))
            {
                __instance.KillButton.renderer.sprite = Douse;
                flag = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.Altruist))
            {
                __instance.KillButton.renderer.sprite = Revive;
                flag = true;
            }
            else
            {
                __instance.KillButton.renderer.sprite = TranslationController.Instance.GetImage(ImageNames.KillButton);
                flag = PlayerControl.LocalPlayer.Is(RoleEnum.Sheriff);
            }

            var keyInt = Input.GetKeyInt(KeyCode.Q);
            var controller = ConsoleJoystick.player.GetButtonDown(8);
            if (keyInt | controller && __instance.KillButton != null && flag && !PlayerControl.LocalPlayer.Data.IsDead)
                __instance.KillButton.PerformKill();
        }
    }
}