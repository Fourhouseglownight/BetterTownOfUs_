using HarmonyLib;
using UnityEngine;

namespace BetterTownOfUs
{
    internal class ImpKillOn
    {
        //Patch that fixes Kill button between impostors
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FindClosestTarget))]
        public static class PlayerControl_FindClosestTarget
        {
            private static int ShipAndObjectsMask = LayerMask.GetMask(new string[]
            {
                "Ship",
                "Objects"
            });

            public static bool Prefix(PlayerControl __instance, ref PlayerControl __result)
            {
                if (!CustomGameOptions.AnonImp) return true;
                PlayerControl result = null;
                float num = GameOptionsData.KillDistances[
                    Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)];
                if (!ShipStatus.Instance)
                {
                    return true;
                }

                Vector2 truePosition = __instance.GetTruePosition();
                for (int i = 0; i < GameData.Instance.AllPlayers.Count; i++)
                {
                    GameData.PlayerInfo playerInfo = GameData.Instance.AllPlayers[i];
                    if (!playerInfo.Disconnected && playerInfo.PlayerId != __instance.PlayerId &&
                        !playerInfo.IsDead)
                    {
                        PlayerControl @object = playerInfo.Object;
                        if (@object)
                        {
                            Vector2 vector = @object.GetTruePosition() - truePosition;
                            float magnitude = vector.magnitude;
                            if (magnitude <= num && !PhysicsHelpers.AnyNonTriggersBetween(truePosition,
                                vector.normalized, magnitude, ShipAndObjectsMask))
                            {
                                result = @object;
                                num = magnitude;
                            }
                        }
                    }
                }

                __result = result;
                return false;
            }
        }
    }
}