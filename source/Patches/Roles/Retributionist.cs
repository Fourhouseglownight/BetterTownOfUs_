using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Retributionist : Role, IMeetingGuesser
    {
        public Dictionary<byte, (GameObject, GameObject, TMP_Text)> Buttons { get; } = new Dictionary<byte, (GameObject, GameObject, TMP_Text)>();
        public Dictionary<byte, int> Guesses { get; } = new Dictionary<byte, int>();
        public List<RoleEnum> PossibleGuesses { get; }
        public int RemainingKills { get; set; }
        public bool CanKeepGuessing() => RemainingKills > 0;
        private static bool MissKill = false;
        public bool CanMissKill() => !MissKill;
        public bool MissingGuess() => MissKill = true;

        public Retributionist(PlayerControl player) : base(player, RoleEnum.Retributionist)
        {
            ImpostorText = () => "Kill impostors during meetings if you can guess their roles";
            TaskText = () => "Guess the roles of impostors mid-meeting to kill them!";

            RemainingKills = CustomGameOptions.GuesserKills;
            
            PossibleGuesses = CustomGameOptions.CanGuessNeutrals
                ? CustomGameOptions.GetEnabledRoles(Faction.Impostors, Faction.Neutral)
                : CustomGameOptions.GetEnabledRoles(Faction.Impostors);

            if (CustomGameOptions.GuesserKillNoRole)
                PossibleGuesses.Add(RoleEnum.Impostor);
        }
    }
}
