using System;
using HarmonyLib;
using Hazel;
using BetterTownOfUs.CrewmateRoles.MedicMod;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.Patches.ImpostorRoles.ConcealerMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Concealer))
            {
                return true;
            }

            if (
                !PlayerControl.LocalPlayer.CanMove
                || PlayerControl.LocalPlayer.Data.IsDead
                )
            {
                return false;
            }

            Concealer role = Role.GetRole<Concealer>(PlayerControl.LocalPlayer);
            if (__instance != role.ConcealButton)
            {
                return true;
            }

            if (
                __instance.isCoolingDown
                || !__instance.isActiveAndEnabled
                || role.ConcealTimer() != 0
                || role.Target == null
                || role.Target.Is(Faction.Impostors)
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
