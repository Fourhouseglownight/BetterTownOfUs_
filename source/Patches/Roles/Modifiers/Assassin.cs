using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace BetterTownOfUs.Roles.Modifiers
{
    public class Assassin : Modifier, IMeetingGuesser
    {
        public static readonly Dictionary<byte, Modifier> AssassinsDictionary = new Dictionary<byte, Modifier>();
        public Dictionary<byte, (GameObject, GameObject, TMP_Text)> Buttons { get; } = new Dictionary<byte, (GameObject, GameObject, TMP_Text)>();
        public Dictionary<byte, int> Guesses { get; } = new Dictionary<byte, int>();
        public List<RoleEnum> PossibleGuesses { get; }
        public int RemainingKills { get; set; }
        public bool CanKeepGuessing() => RemainingKills > 0;
        private static bool MissKill;
        public bool CanMissKill() => !MissKill;
        public bool MissingGuess() => MissKill = true;
        public static bool AssassinCanMissKill() => MissKill = AssassinsNumber == 1;
        public static int AssassinsNumber;

        public Assassin(PlayerControl player) : base(player, ModifierEnum.Assassin)
        {
            Name = "Assassin";
            TaskText = () => "Guess the roles of the people and kill them mid-meeting";
            Color = Palette.ImpostorRed;

            RemainingKills = CustomGameOptions.GuesserKills;

            PossibleGuesses = CustomGameOptions.CanGuessNeutrals
                ? CustomGameOptions.GetEnabledRoles(Faction.Crewmates, Faction.Neutral)
                : CustomGameOptions.GetEnabledRoles(Faction.Crewmates);

            if (CustomGameOptions.GuesserKillNoRole || CustomGameOptions.GuessSnitchViaCrewmate)
                PossibleGuesses.Add(RoleEnum.Crewmate);
            if (CustomGameOptions.GuessSnitchViaCrewmate)
                PossibleGuesses.Remove(RoleEnum.Snitch);

            if (CustomGameOptions.ImpostorsKnowTeam == 3)
            {
                PossibleGuesses.AddRange(CustomGameOptions.GetEnabledRoles(Faction.Impostors));
                PossibleGuesses.Add(RoleEnum.Impostor);
            }
        }

        public static bool IsAssassin(PlayerControl player)
        {
            return player != null ? GetAssassin(player) != null : false;
        }

        public static Modifier GetAssassin(PlayerControl player)
        {
            if (player == null) return null;
            return (from entry in AssassinsDictionary where entry.Key == player.PlayerId select entry.Value)
                .FirstOrDefault();
        }

        public static Assassin GetAssassin<Assassin>(PlayerControl player) where Assassin : Modifier
        {
            return GetAssassin(player) as Assassin;
        }

        public static List<Modifier> GetAssassins()
        {
            return AssassinsDictionary.Values.ToList();
        }
    }
}
