using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.ImpostorRoles.TeleporterMod
{
    [HarmonyPatch(typeof(KillButtonManager), nameof(KillButtonManager.PerformKill))]
    public static class PerformKill
    {
        public static bool Prefix(KillButtonManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Teleporter))
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

            Teleporter role = Role.GetRole<Teleporter>(PlayerControl.LocalPlayer);
            if (__instance != role.TeleportButton)
            {
                Utils.SetTarget(ref role.ClosestPlayer, __instance);
                if (role.ClosestPlayer == null) return false;
                Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.ClosestPlayer);
                return true;
            }

            if (
                __instance.isCoolingDown
                || !__instance.isActiveAndEnabled
                || role.TeleportTimer() > 0
                || Utils.IsSabotageActive()
            )
            {
                return false;
            }

            role.Teleport();
            return false;
        }
    }
}
