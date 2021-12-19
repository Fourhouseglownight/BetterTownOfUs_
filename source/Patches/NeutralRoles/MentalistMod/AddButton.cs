using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.NeutralRoles.MentalistMod
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
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Mentalist)) return;
            Mentalist mentalist = Role.GetRole<Mentalist>(PlayerControl.LocalPlayer);
            mentalist.Guesses.Clear();
            mentalist.Buttons.Clear();

            if (PlayerControl.LocalPlayer.Data.IsDead || mentalist.GuessNeed <= 0)
                return;
                
            foreach (var voteArea in __instance.playerStates)
            {
                IMeetingGuesser.GenButton(
                    mentalist,
                    voteArea,
                    playerControl => !IsExempt(playerControl),
                    (playerControl, role) =>
                    {
                        IMeetingGuesser.KillFromMeetingGuess(mentalist, playerControl, role);
                        mentalist.Kill();
                        mentalist.RegenTask();
                    });
            }
        }
    }
}
