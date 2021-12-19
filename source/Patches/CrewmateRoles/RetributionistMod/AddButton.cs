using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.RetributionistMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public class AddButton
    {

        private static bool IsExempt(PlayerControl player) {
            var role = Role.GetRole(player);
            return role != null && role.Criteria();
        }

        public static void Postfix(MeetingHud __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Retributionist))
            {
                var retributionist = (Retributionist) role;
                retributionist.Guesses.Clear();
                retributionist.Buttons.Clear();
            }

            if (
                PlayerControl.LocalPlayer.Data.IsDead
                || !PlayerControl.LocalPlayer.Is(RoleEnum.Retributionist)
            )
            {
                return;
            }

            var retributionistRole = Role.GetRole<Retributionist>(PlayerControl.LocalPlayer);
            if (retributionistRole.RemainingKills <= 0) return;
            foreach (var voteArea in __instance.playerStates)
            {
                IMeetingGuesser.GenButton(
                    retributionistRole,
                    voteArea,
                    playerControl => !IsExempt(playerControl),
                    (playerControl, role) =>
                    {
                        IMeetingGuesser.KillFromMeetingGuess(retributionistRole, playerControl, role);
                        retributionistRole.RemainingKills--;
                    });
            }
        }
    }
}
