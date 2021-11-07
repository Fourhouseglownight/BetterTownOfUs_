using System;
using HarmonyLib;
using Hazel;
using BetterTownOfUs.CrewmateRoles.MedicMod;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.Patches.ImpostorRoles.ConcealerMod
{
    [HarmonyPatch(typeof(KillButtonManager), nameof(KillButtonManager.PerformKill))]
    public class PerformKill
    {
        public static bool Prefix(KillButtonManager __instance)
        {
            if (
                !PlayerControl.LocalPlayer.Is(RoleEnum.Concealer)
                || !PlayerControl.LocalPlayer.CanMove
                || PlayerControl.LocalPlayer.Data.IsDead
                || __instance.isCoolingDown
                )
            {
                return false;
            }

            Concealer role = Role.GetRole<Concealer>(PlayerControl.LocalPlayer);
            if (__instance != role.ConcealButton)
            {
                Utils.SetTarget(ref role.Target, __instance);
                if (role.Target == null) return false;
                Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.Target);
                return true;
            }

            if (
                !__instance.isActiveAndEnabled
                || role.ConcealTimer() != 0
                || role.Target == null
            )
            {
                return false;
            }

            if (role.Target.isShielded())
            {
                Utils.BreakShield(role.Target);

                if (CustomGameOptions.ShieldBreaks)
                {
                    role.LastConcealed = DateTime.UtcNow;
                }

                return false;
            }

            // Sets concealed player
            role.StartConceal(role.Target);

            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte) CustomRPC.Conceal,
                SendOption.Reliable, -1);
            writer.Write(PlayerControl.LocalPlayer.PlayerId);
            writer.Write(role.Concealed.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);

            return false;
        }
    }
}
