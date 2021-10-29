using HarmonyLib;
using BetterTownOfUs.CrewmateRoles.AltruistMod;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.LoversMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Die))]
    public class Die
    {      
        private static Lover otherLover;
        public static bool Prefix(PlayerControl __instance, [HarmonyArgument(0)] DeathReason reason)
        {
            __instance.Data.IsDead = true;

            var flag3 = __instance.isLover() && CustomGameOptions.BothLoversDie;
            if (!flag3) return true;
            otherLover = Role.GetRole<Lover>(__instance).OtherLover;
            if (otherLover.Player.Data.IsDead) return true;

            if (reason == DeathReason.Exile)
            {
                KillButtonTarget.DontRevive = __instance.PlayerId;
                foreach (var player in PlayerControl.AllPlayerControls) if (CustomGameOptions.LoverVoted) otherLover.Voted = true;
            }
            
            if (AmongUsClient.Instance.AmHost) Utils.RpcMurderPlayer(otherLover.Player, otherLover.Player);

            return true;
        }
    }
}