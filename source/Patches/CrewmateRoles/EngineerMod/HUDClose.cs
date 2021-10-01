using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.CrewmateRoles.EngineerMod
{
    public enum EngineerFixPer
    {
        Custom,
        Round,
        Game
    }

    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            foreach (var role in Role.GetRoles(RoleEnum.Engineer))
            {
                var engineer = (Engineer) role;
                if (CustomGameOptions.EngineerFixPer == EngineerFixPer.Round || (CustomGameOptions.EngineerFixPer == EngineerFixPer.Custom && engineer.RF > 0))
                {
                    engineer.UsedThisRound = false;
                    engineer.FR = CustomGameOptions.FixesPerRound;
                }
            }
        }
    }
}