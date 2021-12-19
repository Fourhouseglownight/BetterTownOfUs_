using HarmonyLib;
using BetterTownOfUs.Roles;
using BetterTownOfUs.Roles.Modifiers;

namespace BetterTownOfUs.Modifiers
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public class AddButton
    {

        public static bool IsExempt(PlayerControl player)
        {
            if (
                player.Is(Faction.Impostors) && CustomGameOptions.ImpostorsKnowTeam < 2
            )
            {
                return true;
            }

            Role role = Role.GetRole(player);
            return role != null && role.Criteria();
        }

        public static void Postfix(MeetingHud __instance)
        {
            foreach (Modifier modifier in Assassin.GetAssassins())
            {
                Assassin assassin = (Assassin) modifier;
                assassin.Guesses.Clear();
                assassin.Buttons.Clear();
            }

            if (
                PlayerControl.LocalPlayer.Data.IsDead
                || !Assassin.IsAssassin(PlayerControl.LocalPlayer)
            )
            {
                return;
            }

            Assassin assassinModifier = Assassin.GetAssassin<Assassin>(PlayerControl.LocalPlayer);
            if (assassinModifier.RemainingKills <= 0) return;
            foreach (PlayerVoteArea voteArea in __instance.playerStates)
            {
                IMeetingGuesser.GenButton(
                    assassinModifier,
                    voteArea,
                    playerControl => !IsExempt(playerControl),
                    (playerControl, modifier) =>
                    {
                        IMeetingGuesser.KillFromMeetingGuess(assassinModifier, playerControl, modifier);
                        assassinModifier.RemainingKills--;
                    });
            }
        }
    }
}
