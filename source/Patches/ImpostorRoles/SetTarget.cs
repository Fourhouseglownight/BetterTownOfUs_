using HarmonyLib;
using BetterTownOfUs.Extensions;

namespace BetterTownOfUs.Roles
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.SetTarget))]
    public class SetTarget
    {
        private static PlayerControl Target;

        public static bool Prefix(ref PlayerControl target)
        {
            if (!PlayerControl.LocalPlayer.Is(Faction.Impostors)) return true;
            if ((CustomGameOptions.KillVent || CustomGameOptions.ImpostorsKnowTeam >= 2) || (CustomGameOptions.LoverKill && PlayerControl.LocalPlayer.Is(RoleEnum.LoverImpostor))) target = Target;
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
                if (((CustomGameOptions.KillVent || CustomGameOptions.ImpostorsKnowTeam >= 2) && PlayerControl.LocalPlayer.Is(Faction.Impostors)) || (CustomGameOptions.LoverKill && PlayerControl.LocalPlayer.Is(RoleEnum.LoverImpostor))) Utils.SetTarget(ref Target, __instance.KillButton);
            }
        }
    }
}