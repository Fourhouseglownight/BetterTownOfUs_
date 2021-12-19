using System.Linq;
using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.ImpostorRoles.TeleporterMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HudManagerUpdate
    {
        public static void Postfix(HudManager __instance)
        {
            if (
                PlayerControl.AllPlayerControls.Count <= 1
                || PlayerControl.LocalPlayer == null
                || PlayerControl.LocalPlayer.Data == null
                || !PlayerControl.LocalPlayer.Is(RoleEnum.Teleporter)
            )
            {
                return;
            }

            var role = Role.GetRole<Teleporter>(PlayerControl.LocalPlayer);

            if (role.TeleportButton == null)
            {
                role.TeleportButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.TeleportButton.graphic.enabled = true;
                role.TeleportButton.GetComponent<AspectPosition>().DistanceFromEdge = BetterTownOfUs.ButtonPosition;
                role.TeleportButton.gameObject.SetActive(false);
            }

            role.TeleportButton.GetComponent<AspectPosition>().Update();
            role.TeleportButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead && !MeetingHud.Instance);
            role.TeleportButton.graphic.sprite = BetterTownOfUs.ButtonSprite;
            role.TeleportButton.SetCoolDown(role.TeleportTimer(), CustomGameOptions.TeleporterCooldown);

            if (
                role.TeleportButton.enabled
                && !role.TeleportButton.isCoolingDown
                && !Utils.IsSabotageActive()
                )
            {
                role.TeleportButton.graphic.color = Palette.EnabledColor;
                role.TeleportButton.graphic.material.SetFloat("_Desat", 0f);
                return;
            }

            role.TeleportButton.graphic.color = Palette.DisabledClear;
            role.TeleportButton.graphic.material.SetFloat("_Desat", 1f);
        }
    }
}
