using System;
using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.ImpostorRoles.MorphlingMod
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
    public static class Start
    {
        public static void Postfix(ShipStatus __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Morphling))
            {
                var morphling = (Morphling) role;
                morphling.LastMorphed = DateTime.UtcNow;
            }
        }
    }
}