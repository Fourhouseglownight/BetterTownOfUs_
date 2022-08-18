using System.Linq;
using HarmonyLib;
using BetterTownOfUs.Roles;
using BetterTownOfUs.Extensions;

namespace BetterTownOfUs
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.SetTarget))]
    public class SetTarget
    {
        private static PlayerControl Target;

        public static bool Prefix(ref PlayerControl target)
        {
            if (!PlayerControl.LocalPlayer.Data.IsImpostor()) return true;
            target = Target;
            return true;
        }

        [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
        public static class Update
        {
            public static void Postfix(HudManager __instance)
            {
                if (PlayerControl.AllPlayerControls.Count <= 1) return;
                if (PlayerControl.LocalPlayer == null) return;
                if (PlayerControl.LocalPlayer.Data == null) return;
                if (__instance.KillButton == null) return;
                if (Role.GetRole(PlayerControl.LocalPlayer) == null) return;
                Utils.SetTarget(ref Target, __instance.KillButton, float.NaN, PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Is(Faction.Impostors)).ToList(), killButton:true);
            }
        }
    }
}