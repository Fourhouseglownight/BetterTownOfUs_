using System;
using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.EngineerMod
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
    public static class Start
    {
        public static void Postfix(ShipStatus __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Engineer))
            {
                var engineer = (Engineer) role;
                engineer.LF = DateTime.UtcNow;
                engineer.LF = engineer.LF.AddSeconds(-8.0);
            }
        }
    }
}