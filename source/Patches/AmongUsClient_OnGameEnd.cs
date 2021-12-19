using System.Linq;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs
{
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class AmongUsClient_OnGameEnd
    {
        public static List<WinningPlayerData> ImpsAlive = new List<WinningPlayerData>();
        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] EndGameResult endGameResult)
        {
            EndGameSummary.UpdatePlayerInfo();
            Utils.potentialWinners.Clear();
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                Utils.potentialWinners.Add(new WinningPlayerData(player.Data));

                if (CustomGameOptions.ImpostorsKnowTeam == 3 && endGameResult.GameOverReason != GameOverReason.HumansByTask && endGameResult.GameOverReason != GameOverReason.HumansByVote && player.Is(Faction.Impostors) && !player.Data.IsDead && !player.Data.Disconnected) ImpsAlive.Add(new WinningPlayerData(player.Data));
            }
        }
    }

    [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.SetEverythingUp))]
    public class EndGameManagerSetUpPatch
    {
        public static void Postfix(EndGameManager __instance)
        {
            EndGameSummary.LoadGameSummary(__instance);
        }
    }

    [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.Start))]
    public class EndGameManager_SetEverythingUp
    {
        public static void Prefix()
        {
            var jester = Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Jester && ((Jester) x).VotedOut);
            var executioner = Role.AllRoles.FirstOrDefault(x =>
                x.RoleType == RoleEnum.Executioner && ((Executioner) x).TargetVotedOut);
            var toRemoveColorIds = Role.AllRoles.Where(o => o.LostByRPC).Select(o => o.Player.Data.DefaultOutfit.ColorId).ToArray();
            var toRemoveWinners = TempData.winners.ToArray().Where(o => toRemoveColorIds.Contains(o.ColorId)).ToArray();
            for (int i = 0; i < toRemoveWinners.Count(); i++)
            {
                TempData.winners.Remove(toRemoveWinners[i]);
            }

            if (jester != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == jester.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners)
                {
                    win.IsDead = false;
                    TempData.winners.Add(win);
                }

                return;
            }

            if (executioner != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == executioner.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }

            var mentalist =
                Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Mentalist && ((Mentalist) x).MentalistWin);
            if (mentalist != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == mentalist.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }

            var lover = Role.AllRoles
                .Where(x => x.RoleType == RoleEnum.Lover || x.RoleType == RoleEnum.LoverImpostor)
                .FirstOrDefault(x => ((Lover) x).LoveCoupleWins);
            if (lover != null)
            {
                var lover1 = (Lover) lover;
                var lover2 = lover1.OtherLover;
                var winners = Utils.potentialWinners
                    .Where(x => x.PlayerName == lover1.PlayerName || x.PlayerName == lover2.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }

            var glitch = Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Glitch && ((Glitch) x).GlitchWins);
            if (glitch != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == glitch.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }

            var arsonist =
                Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Arsonist && ((Arsonist) x).ArsonistWins);
            if (arsonist != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == arsonist.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }

            var cannibal =
                Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Cannibal && ((Cannibal) x).CannibalWin);
            if (cannibal != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == cannibal.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }

            var phantom =
                Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Phantom && ((Phantom) x).CompletedTasks);
            if (phantom != null)
            {
                var winners = Utils.potentialWinners.Where(x => x.PlayerName == phantom.PlayerName).ToList();
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in winners) TempData.winners.Add(win);
                return;
            }
            
            if (CustomGameOptions.ImpostorsKnowTeam == 3 && AmongUsClient_OnGameEnd.ImpsAlive.Count == 1)
            {
                TempData.winners = new List<WinningPlayerData>();
                foreach (var win in AmongUsClient_OnGameEnd.ImpsAlive) TempData.winners.Add(win);
            }
        }
    }
}
