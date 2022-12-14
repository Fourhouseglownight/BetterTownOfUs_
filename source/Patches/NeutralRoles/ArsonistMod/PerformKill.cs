using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using BetterTownOfUs.Roles;
using BetterTownOfUs.CrewmateRoles.MedicMod;

namespace BetterTownOfUs.NeutralRoles.ArsonistMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Arsonist);
            if (!flag) return true;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            var role = Role.GetRole<Arsonist>(PlayerControl.LocalPlayer);
            if (role.DouseTimer() != 0) return false;
            if (!__instance.isActiveAndEnabled || __instance.isCoolingDown) return false;

            if (__instance == role.IgniteButton && role.DousedAlive > 0)
            {
                BetterTownOfUs.Logger.LogMessage(role.DousedAlive);
                BetterTownOfUs.Logger.LogMessage(PlayerControl.AllPlayerControls.ToArray().Count(x => !x.Data.IsDead && !x.Data.Disconnected));
                BetterTownOfUs.Logger.LogMessage(CustomGameOptions.MaxDoused);
                if (role.DousedAlive < PlayerControl.AllPlayerControls.ToArray().Count(x => !x.Data.IsDead && !x.Data.Disconnected) - 1 && role.DousedAlive < CustomGameOptions.MaxDoused) return false;
                if (role.ClosestPlayerIgnite == null) return false;
                var distBetweenPlayers2 = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayerIgnite);
                var flag3 = distBetweenPlayers2 <
                            GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance];
                if (!flag3) return false;
                if (!role.DousedPlayers.Contains(role.ClosestPlayerIgnite.PlayerId)) return false;

                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte) CustomRPC.Ignite, SendOption.Reliable, -1);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                role.Ignite();
                return false;
            }

            if (__instance != DestroyableSingleton<HudManager>.Instance.KillButton) return true;
            if (role.DousedAlive == CustomGameOptions.MaxDoused) return false;
            if (role.ClosestPlayerDouse == null) return false;
            var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayerDouse);
            var flag2 = distBetweenPlayers <
                        GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance];
            if (!flag2) return false;
            if (role.DousedPlayers.Contains(role.ClosestPlayerDouse.PlayerId)) return false;
            if (role.ClosestPlayerDouse.IsInfected() || role.Player.IsInfected())
            {
                foreach (var pb in Role.GetRoles(RoleEnum.Plaguebearer)) ((Plaguebearer)pb).RpcSpreadInfection(role.ClosestPlayerDouse, role.Player);
            }
            if (role.ClosestPlayerDouse.IsOnAlert() || role.ClosestPlayerDouse.Is(RoleEnum.Pestilence))
            {
                if (role.Player.IsShielded())
                {
                    var writer3 = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte)CustomRPC.AttemptSound, SendOption.Reliable, -1);
                    writer3.Write(PlayerControl.LocalPlayer.GetMedic().Player.PlayerId);
                    writer3.Write(PlayerControl.LocalPlayer.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer3);

                    System.Console.WriteLine(CustomGameOptions.ShieldBreaks + "- shield break");
                    if (CustomGameOptions.ShieldBreaks)
                        role.LastDoused = DateTime.UtcNow;
                    StopKill.BreakShield(PlayerControl.LocalPlayer.GetMedic().Player.PlayerId, PlayerControl.LocalPlayer.PlayerId, CustomGameOptions.ShieldBreaks);
                    return false;
                }
                else if (!role.Player.IsProtected())
                {
                    Utils.RpcMurderPlayer(role.ClosestPlayerDouse, PlayerControl.LocalPlayer);
                    return false;
                }
                role.LastDoused = DateTime.UtcNow;
                return false;
            }
            var writer2 = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte) CustomRPC.Douse, SendOption.Reliable, -1);
            writer2.Write(PlayerControl.LocalPlayer.PlayerId);
            writer2.Write(role.ClosestPlayerDouse.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer2);
            role.DousedPlayers.Add(role.ClosestPlayerDouse.PlayerId);
            role.LastDoused = DateTime.UtcNow;

            __instance.SetTarget(null);
            return false;
        }
    }
}
