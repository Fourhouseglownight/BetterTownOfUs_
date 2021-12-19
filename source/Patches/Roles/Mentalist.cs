using System.Collections.Generic;
using System.Linq;
using Hazel;
using TMPro;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Mentalist : Role, IMeetingGuesser
    {
        public Dictionary<byte, (GameObject, GameObject, TMP_Text)> Buttons { get; } = new Dictionary<byte, (GameObject, GameObject, TMP_Text)>();
        public Dictionary<byte, int> Guesses { get; } = new Dictionary<byte, int>();
        public List<RoleEnum> PossibleGuesses { get; }
        public int GuessNeed;
        public bool MentalistWin;
        public bool CanKeepGuessing() => CustomGameOptions.GuesserMultiKill;
        private static bool MissKill = false;
        public bool CanMissKill() => !MissKill;
        public bool MissingGuess() => MissKill = true;
        
        public Mentalist(PlayerControl player) : base(player, RoleEnum.Mentalist)
        {
            ImpostorText = () => "Kill during meetings if you can guess their roles";
            string crew = GuessNeed < 2 ? "Crewmate" : "Crewmates";
            TaskText = () => $"prove your intelligence by guessing {GuessNeed} {crew} to Win\nFake Tasks:";

            GuessNeed = CustomGameOptions.GuessNeed == 0 ? PlayerControl.AllPlayerControls._size / 3 : CustomGameOptions.GuessNeed;

            PossibleGuesses = CustomGameOptions.CanGuessNeutrals
                ? CustomGameOptions.GetEnabledRoles(Faction.Crewmates, Faction.Neutral, Faction.Impostors)
                : CustomGameOptions.GetEnabledRoles(Faction.Crewmates, Faction.Impostors);

            if (CustomGameOptions.GuesserKillNoRole || CustomGameOptions.GuessSnitchViaCrewmate)
            {
                PossibleGuesses.Add(RoleEnum.Crewmate);
                if (CustomGameOptions.GuessSnitchViaCrewmate)
                    PossibleGuesses.Remove(RoleEnum.Snitch);
                if (CustomGameOptions.GuesserKillNoRole)
                    PossibleGuesses.Add(RoleEnum.Impostor);
            }
        }
        
        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            if (GuessNeed < 1)
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.MentalistWin, SendOption.Reliable, -1);
                writer.Write(Player.PlayerId);
                Wins();
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Utils.EndGame();
                return false;
            }
            
            return true;
        }

        public void Wins()
        {
            MentalistWin = true;
        }

        public void Loses()
        {
            LostByRPC = true;
        }

        protected override void IntroPrefix(IntroCutscene._CoBegin_d__18 __instance)
        {
            var mentalistteam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            mentalistteam.Add(PlayerControl.LocalPlayer);
            __instance.yourTeam = mentalistteam;
        }

        public void UpdateTaskText()
        {
            string crew = GuessNeed < 2 ? "Crewmate" : "Crewmates";
            Player.myTasks.ToArray()[0].Cast<ImportantTextTask>().Text = $"{ColorString}Role: Mentalist\nprove your intelligence by guessing {GuessNeed} {crew} to Win\nFake Tasks:</color>";
        }

        public void Kill()
        {
            GuessNeed--;
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(Player.NetId, (byte) CustomRPC.MentalistKill, SendOption.Reliable, -1);
            writer.Write(Player.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);            
        }
    }
}
