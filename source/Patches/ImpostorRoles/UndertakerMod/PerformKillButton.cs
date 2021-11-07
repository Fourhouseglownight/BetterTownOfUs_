using System;
using HarmonyLib;
using Hazel;
using Reactor.Extensions;
using BetterTownOfUs.Extensions;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.ImpostorRoles.UndertakerMod
{
    [HarmonyPatch(typeof(KillButtonManager), nameof(KillButtonManager.PerformKill))]
    public class PerformKillButton
    {
        public static bool Prefix(KillButtonManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Undertaker)) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            if (!__instance.isActiveAndEnabled) return false;
            if (__instance.isCoolingDown) return false;
            var role = Role.GetRole<Undertaker>(PlayerControl.LocalPlayer);

            if (__instance == role.DragDropButton)
            {
                if (role.DragDropButton.renderer.sprite == BetterTownOfUs.DragSprite)
                {
                    if (!__instance.enabled) return false;
                    var maxDistance = GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance];
                    if (Vector2.Distance(role.CurrentTarget.TruePosition,
                        PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance) return false;
                    var playerId = role.CurrentTarget.ParentId;

                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte) CustomRPC.Drag, SendOption.Reliable, -1);
                    writer.Write(PlayerControl.LocalPlayer.PlayerId);
                    writer.Write(playerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);

                    role.CurrentlyDragging = role.CurrentTarget;

                    KillButtonTarget.SetTarget(__instance, null, role);
                    __instance.renderer.sprite = BetterTownOfUs.DropSprite;
                    return false;
                }
                else
                {
                    if (!__instance.enabled) return false;
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte) CustomRPC.Drop, SendOption.Reliable, -1);
                    writer.Write(PlayerControl.LocalPlayer.PlayerId);
                    Vector2 position = PlayerControl.LocalPlayer.GetTruePosition();
                    writer.Write(position);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);

                    var body = role.CurrentlyDragging;
                    body.bodyRenderer.material.SetFloat("_Outline", 0f);
                    role.CurrentlyDragging = null;
                    __instance.renderer.sprite = BetterTownOfUs.DragSprite;
                    role.LastDragged = DateTime.UtcNow;
                    //body.transform.position = position;
                    return false;
                }
            }
            
            Utils.SetTarget(ref role.ClosestPlayer, __instance);
            if (role.ClosestPlayer == null) return false;
            Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, role.ClosestPlayer);
            return true;
        }
    }
}
