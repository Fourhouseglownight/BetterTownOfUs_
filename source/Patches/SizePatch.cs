using HarmonyLib;
using System.Linq;
using BetterTownOfUs.Extensions;
using UnityEngine;

namespace BetterTownOfUs.Patches
{
    [HarmonyPatch]
    public static class SizePatch
    {
        [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
        [HarmonyPostfix]
        public static void Postfix(HudManager __instance)
        {
            BetterTownOfUs.Logger.LogMessage("size patch 1");
            foreach (var player in PlayerControl.AllPlayerControls.ToArray())
            {
                BetterTownOfUs.Logger.LogMessage("size patch 2");
                if (!player.Data.IsDead)
                    player.transform.localScale = player.GetAppearance().SizeFactor;
                else
                    player.transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                BetterTownOfUs.Logger.LogMessage("size patch 3");

            }

            var playerBindings = PlayerControl.AllPlayerControls.ToArray().ToDictionary(player => player.PlayerId);
            BetterTownOfUs.Logger.LogMessage("size patch 4");
            var bodies = UnityEngine.Object.FindObjectsOfType<DeadBody>();
            BetterTownOfUs.Logger.LogMessage("size patch 5");
            foreach (var body in bodies)
            {
                try {
                    body.transform.localScale = playerBindings[body.ParentId].GetAppearance().SizeFactor;
                    BetterTownOfUs.Logger.LogMessage("size patch 6");
                } catch {
                }
                BetterTownOfUs.Logger.LogMessage("size patch 7");
            }
        }
    }
}