using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.CrewmateRoles.CovertMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class ManageCovertButton
    {
        private static Sprite CovertSprite => BetterTownOfUs.SwoopSprite;

        public static void Postfix(HudManager __instance)
        {
            if (
                PlayerControl.AllPlayerControls.Count <= 1
                || PlayerControl.LocalPlayer == null
                || PlayerControl.LocalPlayer.Data == null
                || !PlayerControl.LocalPlayer.Is(RoleEnum.Covert)
            )
            {
                return;
            }

            Covert role = Role.GetRole<Covert>(PlayerControl.LocalPlayer);

            if (role.CovertButton == null)
            {
                role.CovertButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.CovertButton.graphic.enabled = true;
                role.CovertButton.GetComponent<AspectPosition>().DistanceFromEdge = BetterTownOfUs.ButtonPosition;
                role.CovertButton.gameObject.SetActive(false);
            }

            role.CovertButton.GetComponent<AspectPosition>().Update();
            role.CovertButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead && !MeetingHud.Instance);
            role.CovertButton.graphic.sprite = CovertSprite;

            if (role.IsCovert)
            {
                role.CovertButton.SetCoolDown(role.CovertTimeRemaining, CustomGameOptions.CovertDuration);
                return;
            }

            role.CovertButton.SetCoolDown(role.CovertTimer(), CustomGameOptions.CovertCooldown);
            role.CovertButton.graphic.color = Palette.EnabledColor;
            role.CovertButton.graphic.material.SetFloat("_Desat", 0f);
        }
    }
}