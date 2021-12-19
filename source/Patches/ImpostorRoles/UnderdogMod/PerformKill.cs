using System.Linq;
using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.ImpostorRoles.UnderdogMod
{
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
                .Count(x => x.Is(Faction.Impostors) && !x.Data.IsDead) == 1;
        }

        internal static bool IncreasedKC()
        {
            if (CustomGameOptions.UnderdogIncreasedKC)
                return false;
            else
                return true;
        }
    }
}
