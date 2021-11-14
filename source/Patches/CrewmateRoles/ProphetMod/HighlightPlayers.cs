using HarmonyLib;
using BetterTownOfUs.ImpostorRoles.CamouflageMod;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.CrewmateRoles.ProphetMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HighlightPlayers
    {
        [HarmonyPriority(Priority.Last)]
        private static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Prophet)) return;

            var prophet = Role.GetRole<Prophet>(PlayerControl.LocalPlayer);

            ShowRevealsInGame(__instance, prophet);
            if (MeetingHud.Instance != null)
            {
                ShowRevealsDuringMeeting(MeetingHud.Instance, prophet);
            }
        }

        private static void ShowRevealsDuringMeeting(MeetingHud __instance, Prophet prophet)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!prophet.Revealed.Contains(player.PlayerId))
                {
                    continue;
                }

                foreach (var state in __instance.playerStates)
                {
                    if (player.PlayerId != state.TargetPlayerId)
                    {
                        continue;
                    }

                    state.NameText.color = Color.green;
                    state.NameText.text = NameText(player, " (Crew)", true);
                }
            }
        }

        private static void ShowRevealsInGame(HudManager __instance, Prophet prophet)
        {

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!prophet.Revealed.Contains(player.PlayerId))
                {
                    continue;
                }

                player.nameText.transform.localPosition = new Vector3(0f, 2f, -0.5f);
                player.nameText.color = Color.green;
                player.nameText.text = NameText(player, " (Crew)");
            }
        }

        private static string NameText(PlayerControl player, string str = "", bool meeting = false)
        {
            if (CamouflageUnCamouflage.IsCamoed)
            {
                if (meeting && !CustomGameOptions.MeetingColourblind)
                {
                    return player.name + str;
                }

                return "";
            }

            return player.name + str;
        }
    }
}