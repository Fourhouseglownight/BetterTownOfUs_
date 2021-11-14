using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.NeutralRoles.CannibalMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static ArrowBehaviour Arrow;
        public static DeadBody Target;
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Cannibal)) return;
            var eatButton = __instance.KillButton;

            var role = Role.GetRole<Cannibal>(PlayerControl.LocalPlayer);
            if (PlayerControl.LocalPlayer.Data.IsDead)
            {
                    eatButton.gameObject.SetActive(false);
                    eatButton.isActive = false;
            }
            else
            {
                eatButton.gameObject.SetActive(!MeetingHud.Instance);
                eatButton.isActive = !MeetingHud.Instance;
                eatButton.renderer.sprite = BetterTownOfUs.JanitorClean;
            }

            var truePosition = PlayerControl.LocalPlayer.GetTruePosition();
            var maxDistance = GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance];
            var flag = (PlayerControl.GameOptions.GhostsDoTasks || !PlayerControl.LocalPlayer.Data.IsDead) &&
                       (!AmongUsClient.Instance || !AmongUsClient.Instance.IsGameOver) &&
                       PlayerControl.LocalPlayer.CanMove;
            var allocs = Physics2D.OverlapCircleAll(truePosition, 10,
                LayerMask.GetMask(new[] {"Players", "Ghost"}));
            DeadBody closestBody = null;
            var closestDistance = float.MaxValue;

            foreach (var collider2D in allocs)
            {
                if (!flag || PlayerControl.LocalPlayer.Data.IsDead || collider2D.tag != "DeadBody") continue;
                var component = collider2D.GetComponent<DeadBody>();
                var distance = Vector2.Distance(truePosition, component.TruePosition);
                if (distance <= 10 && Arrow == null) Target = component;
                else if (distance > 10 && Target == component) Target = null;
                if (!(distance <= maxDistance)) continue;  
                if (!(distance < closestDistance)) continue;

                closestBody = component;
                closestDistance = distance;
            }

            KillButtonTarget.SetTarget(eatButton, closestBody, role);
            eatButton.SetCoolDown(0, 1);

            if (Target != null && Arrow == null)
            {
                var gameObj = new GameObject();
                Arrow = gameObj.AddComponent<ArrowBehaviour>();
                gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                var renderer = gameObj.AddComponent<SpriteRenderer>();
                renderer.sprite = BetterTownOfUs.Arrow;
                Arrow.image = renderer;
                gameObj.layer = 5;
            }
        }
    }
}