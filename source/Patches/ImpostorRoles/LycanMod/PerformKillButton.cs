using HarmonyLib;
using Hazel;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.ImpostorRoles.LycanMod
{
    [HarmonyPatch(typeof(KillButtonManager), nameof(KillButtonManager.PerformKill))]
    public class PerformKillButton

    {
        private static Lycan role;public static bool Prefix(KillButtonManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Lycan)) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            role = Role.GetRole<Lycan>(PlayerControl.LocalPlayer);

            if (__instance == role.LycanButton)
            {
                if (!__instance.isActiveAndEnabled) return false;
                if (__instance.isCoolingDown) return false;
                if (role.WolfTimer() != 0) return false;
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.Wolf, SendOption.Reliable, -1);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                role.TimeRemaining = CustomGameOptions.WolfDuration;
                role.Wolfed = true;
                Utils.Morph(role.Player, null, true);
                return false;
            }
            
            Utils.SetTarget(ref role.ClosestPlayer, __instance);
            if (role.ClosestPlayer == null) return false;
            Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.ClosestPlayer);    
            return true;
        }
    }
}