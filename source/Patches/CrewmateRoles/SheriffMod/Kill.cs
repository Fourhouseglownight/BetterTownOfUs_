using System;
using HarmonyLib;
using Hazel;
using BetterTownOfUs.CrewmateRoles.MedicMod;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.SheriffMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public static class Kill
    {
        [HarmonyPriority(Priority.First)]
        private static bool Prefix(KillButton __instance)
        {
            if (__instance != DestroyableSingleton<HudManager>.Instance.KillButton) return true;
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Sheriff);
            if (!flag) return true;
            var role = Role.GetRole<Sheriff>(PlayerControl.LocalPlayer);
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            if (role.SheriffKillTimer() != 0f) return false;
            if (!__instance.enabled || role.ClosestPlayer == null) return false;
            var distBetweenPlayers = Utils.getDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
            var flag3 = distBetweenPlayers < GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance];
            if (!flag3) return false;
            if (role.ClosestPlayer.isShielded())
            {
                Utils.BreakShield(role.ClosestPlayer);

                if (CustomGameOptions.ShieldBreaks)
                {
                    role.LastKilled = DateTime.UtcNow;
                }

                return false;
            }

            var flag4 = role.ClosestPlayer.Is(Faction.Impostors) ||
                        role.ClosestPlayer.Is(RoleEnum.Jester) && CustomGameOptions.SheriffKillsJester ||
                        role.ClosestPlayer.Is(RoleEnum.Shifter) && CustomGameOptions.SheriffKillsShifter ||
                        role.ClosestPlayer.Is(RoleEnum.Parasite) && CustomGameOptions.SheriffKillsParasite ||
                        role.ClosestPlayer.Is(RoleEnum.Glitch) && CustomGameOptions.SheriffKillsGlitch ||
                        role.ClosestPlayer.Is(RoleEnum.Executioner) && CustomGameOptions.SheriffKillsExecutioner ||
                        role.ClosestPlayer.Is(RoleEnum.Mentalist) && CustomGameOptions.SheriffKillsMentalist ||
                        role.ClosestPlayer.Is(RoleEnum.Arsonist) && CustomGameOptions.SheriffKillsArsonist ||
                        role.ClosestPlayer.Is(RoleEnum.Cannibal) && CustomGameOptions.SheriffKillsCannibal;
                ;
            if (!flag4)
            {
                if (CustomGameOptions.SheriffKillOther)
                    Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.ClosestPlayer);
                Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, PlayerControl.LocalPlayer);
            }
            else
            {
                Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.ClosestPlayer);
            }

            role.LastKilled = DateTime.UtcNow;

            return false;
        }
    }
}
