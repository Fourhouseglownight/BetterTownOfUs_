using System.Linq;
using HarmonyLib;
using BetterTownOfUs.Extensions;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.CrewmateRoles.SeerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class Update
    {
        public static string NameText(PlayerControl player, string str = "", bool meeting = false)
        {
            if (CamouflageUnCamouflage.IsCamoed)
            {
                if (meeting) return player.name + str;

                return "";
            }

            return player.name + str;
        }

        private static Color FactionColor(Role role)
        {
            switch (role.Faction)
            {
                case Faction.Crewmates:
                    return Color.green;
                case Faction.Impostors:
                    return Color.red;
                case Faction.Neutral:
                    return CustomGameOptions.NeutralRed ? Color.red : Color.grey;
                default:
                    return Color.white;
            };
        }

        private static void UpdateMeeting(MeetingHud __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Seer))
            {
                var seerRole = (Seer) role;
                if (!seerRole.Investigated.ContainsKey(PlayerControl.LocalPlayer.PlayerId)) continue;
                if (!seerRole.CheckSeeReveal(PlayerControl.LocalPlayer)) continue;
                var state = __instance.playerStates.FirstOrDefault(x => x.TargetPlayerId == seerRole.Player.PlayerId);
                state.NameText.color = seerRole.Color;
                state.NameText.text = NameText(seerRole.Player, " (Seer)", true);
            }
        }

        private static void UpdateMeeting(MeetingHud __instance, Seer seer)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!seer.Investigated.TryGetValue(player.PlayerId, out var successfulInvestigation) || !successfulInvestigation) continue;
                foreach (var state in __instance.playerStates)
                {
                    if (player.PlayerId != state.TargetPlayerId) continue;
                    var roleType = Utils.GetRole(player);
                    switch (roleType)
                    {
                        case RoleEnum.Crewmate:
                            state.NameText.color =
                                CustomGameOptions.SeerInfo == SeerInfo.Faction ? Color.green : Color.white;
                            state.NameText.text = NameText(player,
                                CustomGameOptions.SeerInfo == SeerInfo.Role ? " (Crew)" : "", true);
                            break;
                        case RoleEnum.Impostor:
                            state.NameText.color = CustomGameOptions.SeerInfo == SeerInfo.Faction
                                ? Color.red
                                : Palette.ImpostorRed;
                            state.NameText.text = NameText(player,
                                CustomGameOptions.SeerInfo == SeerInfo.Role ? " (Imp)" : "", true);
                            break;
                        default:
                            var role = Role.GetRole(player);
                            state.NameText.color = CustomGameOptions.SeerInfo == SeerInfo.Faction
                                ? FactionColor(role)
                                : role.Color;
                            state.NameText.text = NameText(player,
                                CustomGameOptions.SeerInfo == SeerInfo.Role ? $" ({role.Name})" : "", true);
                            break;
                    }
                }
            }
        }

        [HarmonyPriority(Priority.Last)]
        private static void Postfix(HudManager __instance)

        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;

            if (MeetingHud.Instance != null) UpdateMeeting(MeetingHud.Instance);
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Seer)) return;
            var seer = Role.GetRole<Seer>(PlayerControl.LocalPlayer);
            if (MeetingHud.Instance != null) UpdateMeeting(MeetingHud.Instance, seer);


            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!seer.Investigated.TryGetValue(player.PlayerId, out var successfulInvestigation) || !successfulInvestigation) continue;
                var roleType = Utils.GetRole(player);
                var nameText = player.cosmetics.nameText;
                nameText.transform.localPosition = new Vector3(0f, 2f, -0.5f);
                switch (roleType)
                {
                    case RoleEnum.Crewmate:
                        nameText.color =
                            CustomGameOptions.SeerInfo == SeerInfo.Faction ? Color.green : Color.white;
                        nameText.text = NameText(player,
                            CustomGameOptions.SeerInfo == SeerInfo.Role ? " (Crew)" : "");
                        break;
                    case RoleEnum.Impostor:
                        nameText.color = CustomGameOptions.SeerInfo == SeerInfo.Faction
                            ? Color.red
                            : Palette.ImpostorRed;
                        nameText.text = NameText(player,
                            CustomGameOptions.SeerInfo == SeerInfo.Role ? " (Imp)" : "");
                        break;
                    default:
                        var role = Role.GetRole(player);
                        nameText.color = CustomGameOptions.SeerInfo == SeerInfo.Faction
                            ? FactionColor(role)
                            : role.Color;
                        nameText.text = NameText(player,
                            CustomGameOptions.SeerInfo == SeerInfo.Role ? $" ({role.Name})" : "");
                        break;
                }
            }
        }
    }
}