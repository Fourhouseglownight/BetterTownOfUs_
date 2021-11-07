using System.Linq;
using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.ImpostorRoles.UnderdogMod
{
    [HarmonyPatch(typeof(KillButtonManager), nameof(KillButtonManager.PerformKill))]
    public class PerformKillButton
    {
        public static bool Prefix(KillButtonManager __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Underdog);
            if (!flag) return true;
            if (!__instance.isActiveAndEnabled) return false;
            if (__instance.isCoolingDown) return false;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            var role = Role.GetRole<Underdog>(PlayerControl.LocalPlayer); 
            Utils.SetTarget(ref role.ClosestPlayer, __instance);
            if (role.ClosestPlayer == null) return false;
            Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.ClosestPlayer);
            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.MurderPlayer))]
    public class PerformKill
    {
        public static void Postfix(PlayerControl __instance, [HarmonyArgument(0)] PlayerControl target)
        {
            var role = Role.GetRole(__instance);
            if (role?.RoleType == RoleEnum.Underdog)
                ((Underdog)role).SetKillTimer();
        }

        internal static bool LastImp()
        {
            return PlayerControl.AllPlayerControls.ToArray()
                .Count(x => x.Data.IsImpostor && !x.Data.IsDead) == 1;
        }
    }
}
