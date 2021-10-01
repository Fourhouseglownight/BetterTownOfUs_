using HarmonyLib;
using BetterTownOfUs.CrewmateRoles.AltruistMod;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.CrewmateRoles.LoversMod
{
    

    /*[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class NoReport
    {
        private static PlayerControl Lover1;
        private static PlayerControl Lover2;
        public static DeadBody Body;
        public static void Postfix(PlayerControl __instance)
        {
            if (!__instance.AmOwner || !__instance.CanMove || !Die.flag) return;
        
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (Lover1 != null && player.isLover())
                {
                    Lover2 = player;
                    break;
                }
                if (player.isLover()) Lover1 = player;
            }

            foreach (DeadBody body in UnityEngine.GameObject.FindObjectsOfType<DeadBody>())
            {
                if (body.ParentId == Lover1.PlayerId || body.ParentId == Lover2.PlayerId)
                {   
                    Body = body;
                    break;
                }
            }

            var truePosition = __instance.GetTruePosition();

            var data = __instance.Data;
            var stuff = Physics2D.OverlapCircleAll(truePosition, __instance.MaxReportDistance, Constants.Usables);
            var flag = (PlayerControl.GameOptions.GhostsDoTasks || !data.IsDead) &&
                       (!AmongUsClient.Instance || !AmongUsClient.Instance.IsGameOver) && __instance.CanMove;
            var flag2 = false;

            foreach (var collider2D in stuff)
                if (flag && !flag2 && !data.IsDead && collider2D.tag == "DeadBody")
                {
                    var component = collider2D.GetComponent<DeadBody>();

                    if (Vector2.Distance(truePosition, component.TruePosition) <= __instance.MaxReportDistance)
                    {
                        var matches = Body.ParentId == component.ParentId;
                        if (matches) flag2 = true;
                    }

                    DestroyableSingleton<HudManager>.Instance.ReportButton.SetActive(flag2);
                }
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.ReportClosest))]
    public static class DontReport
    {
        public static bool Prefix(PlayerControl __instance)
        {
            if (AmongUsClient.Instance.IsGameOver || PlayerControl.LocalPlayer.Data.IsDead) return false;
            if (!Die.flag) return true;
            foreach (var collider2D in Physics2D.OverlapCircleAll(__instance.GetTruePosition(),
                __instance.MaxReportDistance, Constants.PlayersOnlyMask))
                if (!(collider2D.tag != "DeadBody"))
                {
                    var component = collider2D.GetComponent<DeadBody>();
                    if (component && !component.Reported)
                    {
                        var matches = NoReport.Body.ParentId == component.ParentId;
                        if (matches)
                            component.OnClick();
                        if (component.Reported) break;
                    }
                }

            return false;
        }
    }*/

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Die))]
    public class Die
    {      
        private static bool voted = false;
        private static PlayerControl otherLover;
        public static bool Prefix(PlayerControl __instance, [HarmonyArgument(0)] DeathReason reason)
        {
            __instance.Data.IsDead = true;

            var flag3 = __instance.isLover() && CustomGameOptions.BothLoversDie;
            if (!flag3) return true;
            otherLover = Role.GetRole<Lover>(__instance).OtherLover.Player;
            if (otherLover.Data.IsDead) return true;

            if (reason == DeathReason.Exile)
            {
                KillButtonTarget.DontRevive = __instance.PlayerId;
                if (CustomGameOptions.LoverVoted)
                {
                    voted = true;
                    var exileInstance = DestroyableSingleton<PbExileController>.Instance;
                    exileInstance.Begin(otherLover.Data, false);
                    //exileInstance.Awake();
                    //AmongUsClient.Instance.StartCoroutine(exileInstance.Animate());
                }
            }
            
            if (AmongUsClient.Instance.AmHost && !voted) Utils.RpcMurderPlayer(otherLover, otherLover);

            return true;
        }

        /*public static void Postfix()
        {
            if (voted)
            {
                var exileInstance = DestroyableSingleton<PbExileController>.Instance;
                DestroyableSingleton<PbExileController>.Instance.Begin(otherLover.Data, false);
                exileInstance.Awake();
                exileInstance.StartCoroutine(exileInstance.Animate());
            }
            return;
        }*/
    }
}