using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.SnitchMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HighlightImpostors
    {
        private static void UpdateMeeting(MeetingHud __instance)
        {
            if (!CustomGameOptions.SnitchSeesInMeetings)
                return;

            foreach (var state in __instance.playerStates)
            {
                if (Utils.PlayerById(state.TargetPlayerId).Is(Faction.Impostors)) state.NameText.color = Palette.ImpostorRed;

                var role = Role.GetRole(state);
                if (role.Faction == Faction.Neutral && CustomGameOptions.SnitchSeesNeutrals)
                    state.NameText.color = role.Color;
            }
        }

        public static void Postfix(HudManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Snitch)) return;
            var role = Role.GetRole<Snitch>(PlayerControl.LocalPlayer);
            if (!role.TasksDone) return;
            if (MeetingHud.Instance) UpdateMeeting(MeetingHud.Instance);

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (player.Is(Faction.Impostors)) player.nameText.color = Palette.ImpostorRed;
                var playerRole = Role.GetRole(player);
                if (playerRole.Faction == Faction.Neutral && CustomGameOptions.SnitchSeesNeutrals)
                    player.nameText.color = role.Color;
            }
        }
    }
}