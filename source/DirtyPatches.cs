using System;
using HarmonyLib;
using Hazel.Udp;
using Reactor;

namespace BetterTownOfUs
{
    public static class DirtyPatches
    {
        public static void Initialize(Harmony harmony)
        {
            try
            {
                harmony.Unpatch(
                    AccessTools.Method(typeof(UdpConnection), nameof(UdpConnection.HandleSend)),
                    HarmonyPatchType.Prefix,
                    ReactorPlugin.Id
                );
            }
            catch (Exception e)
            {
                BetterTownOfUs.log.LogError($"Exception unpatching Reactor's UdpConnection.HandleSend Prefix: {e.Message}, Stack: {e.StackTrace}");
            }
        }
    }
}