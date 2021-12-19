using System;
using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetterTownOfUs.Patches.ImpostorRoles.ConcealerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class ManageConcealButton
    {
        public static void Postfix(HudManager __instance)
        {
            if (
                PlayerControl.AllPlayerControls.Count <= 1
                || PlayerControl.LocalPlayer == null
                || PlayerControl.LocalPlayer.Data == null
                || !PlayerControl.LocalPlayer.Is(RoleEnum.Concealer)
            )
            {
                return;
            }

            Concealer role = Role.GetRole<Concealer>(PlayerControl.LocalPlayer);
            if (role.ConcealButton == null)
            {
                role.ConcealButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.ConcealButton.graphic.enabled = true;
                role.ConcealButton.GetComponent<AspectPosition>().DistanceFromEdge = BetterTownOfUs.ButtonPosition;
                role.ConcealButton.gameObject.SetActive(false);
            }

            role.ConcealButton.GetComponent<AspectPosition>().Update();
            role.ConcealButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead && !MeetingHud.Instance);
            role.ConcealButton.graphic.sprite = BetterTownOfUs.SwoopSprite;

            if (role.Concealed != null)
            {
                // TODO: This will kind of lie to them about how long the conceal lasts, can we change the experience?
                role.ConcealButton.SetCoolDown(role.TimeBeforeConcealed + role.ConcealTimeRemaining, CustomGameOptions.ConcealDuration);
                return;
            }

            Utils.SetTarget(ref role.Target, role.ConcealButton);

            role.ConcealButton.SetCoolDown(role.ConcealTimer(), CustomGameOptions.ConcealCooldown);
            role.ConcealButton.graphic.color = Palette.EnabledColor;
        }
    }
}
