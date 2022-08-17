using HarmonyLib;
using BetterTownOfUs.Extensions;

namespace BetterTownOfUs.Patches
{
    [HarmonyPatch]
    public static class SpeedPatch
    {
        [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.FixedUpdate))]
        [HarmonyPostfix]
        public static void PostfixPhysics(PlayerPhysics __instance)
        {
            if (__instance.AmOwner && GameData.Instance && __instance.myPlayer.CanMove && !__instance.myPlayer.Data.IsDead)
                __instance.body.velocity *= __instance.myPlayer.GetAppearance().SpeedFactor;
        }

        [HarmonyPatch(typeof(CustomNetworkTransform), nameof(CustomNetworkTransform.FixedUpdate))]
        [HarmonyPostfix]
        public static void PostfixNetwork(CustomNetworkTransform __instance)
        {
            BetterTownOfUs.Logger.LogMessage("speed patch 1");
            if (!__instance.AmOwner && __instance.interpolateMovement != 0.0f && !__instance.gameObject.GetComponent<PlayerControl>().Data.IsDead)
            {
                BetterTownOfUs.Logger.LogMessage("speed patch 2");
                var player = __instance.gameObject.GetComponent<PlayerControl>();
                BetterTownOfUs.Logger.LogMessage("speed patch 3");
                __instance.body.velocity *= player.GetAppearance().SpeedFactor;
                BetterTownOfUs.Logger.LogMessage("speed patch 4");
            }
            BetterTownOfUs.Logger.LogMessage("speed patch 3");
        }
    }
}