﻿using HarmonyLib;
using Hazel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reactor.Extensions;
using BetterTownOfUs.CrewmateRoles.MedicMod;
using BetterTownOfUs.Extensions;
using BetterTownOfUs.ImpostorRoles.CamouflageMod;
using BetterTownOfUs.Roles;
using BetterTownOfUs.Roles.Modifiers;
using BetterTownOfUs.NeutralRoles.ParasiteMod;
using UnhollowerBaseLib;
using UnityEngine;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using PerformKill = BetterTownOfUs.ImpostorRoles.UnderdogMod.PerformKill;

namespace BetterTownOfUs
{
    [HarmonyPatch]
    public static class Utils
    {
        internal static bool ShowDeadBodies = false;

        public static Dictionary<PlayerControl, Color> oldColors = new Dictionary<PlayerControl, Color>();

        public static List<WinningPlayerData> potentialWinners = new List<WinningPlayerData>();

        public static void SetSkin(PlayerControl Player, string skin)
        {
            Player.MyPhysics.SetSkin(skin);
        }


        public static void MakeInvisible(PlayerControl player, bool showBlur)
        {
            Color color = Color.clear;
            if (showBlur)
            {
                color.a = 0.1f;
            }

            player.SetOutfit(CustomPlayerOutfitType.Swooper, new GameData.PlayerOutfit()
            {
                ColorId = player.CurrentOutfit.ColorId,
                HatId = "",
                SkinId = "",
                VisorId = "",
                _playerName = " "
            });
            player.MyRend.color = color;
        }

        public static void Morph(PlayerControl player, PlayerControl MorphedPlayer, bool resetAnim = false)
        {
            if (CamouflageUnCamouflage.IsCamoed) return;
            if (player.Is(RoleEnum.Lycan))
            {
                if (player.GetCustomOutfitType() != CustomPlayerOutfitType.Wolf) player.SetOutfit(CustomPlayerOutfitType.Wolf, new GameData.PlayerOutfit()
                {
                    ColorId = 0,
                    HatId = "",
                    SkinId = "",
                    VisorId = "",
                    PetId = "",
                    _playerName = "Lycan"
                });
                PlayerControl.SetPlayerMaterialColors(Color.grey, player.myRend);
                player.myRend.size = new Vector2(0.9f, 1.1f);
                player.nameText.color = Palette.ImpostorRed;
                Role.GetRole<Lycan>(player).Wolfed = true;
            }
            else if (player.GetCustomOutfitType() != CustomPlayerOutfitType.Morph)
                player.SetOutfit(CustomPlayerOutfitType.Morph, MorphedPlayer.Data.DefaultOutfit);
        }

        public static void MakeVisible(PlayerControl player)
        {
            Unmorph(player);
            player.MyRend.color = Color.white;
        }

        public static void Unmorph(PlayerControl player)
        {
            if (player.Is(RoleEnum.Lycan)) Role.GetRole<Lycan>(player).Wolfed = false;
            player.SetOutfit(CustomPlayerOutfitType.Default);
        }

        public static void Camouflage()
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (player.GetCustomOutfitType() != CustomPlayerOutfitType.Camouflage)
                {
                    player.SetOutfit(CustomPlayerOutfitType.Camouflage, new GameData.PlayerOutfit()
                    {
                        ColorId = player.GetDefaultOutfit().ColorId,
                        HatId = "",
                        SkinId = "",
                        VisorId = "",
                        _playerName = " "
                    });

                    PlayerControl.SetPlayerMaterialColors(Color.grey, player.myRend);
                }
            }
        }

        public static void UnCamouflage()
        {
            foreach (var player in PlayerControl.AllPlayerControls) Unmorph(player);
        }

        public static bool IsCrewmate(this PlayerControl player)
        {
            return GetRole(player) == RoleEnum.Crewmate;
        }

        public static void AddUnique<T>(this Il2CppSystem.Collections.Generic.List<T> self, T item)
            where T : IDisconnectHandler
        {
            if (!self.Contains(item)) self.Add(item);
        }

        public static bool isLover(this PlayerControl player)
        {
            return player.Is(RoleEnum.Lover) || player.Is(RoleEnum.LoverImpostor);
        }

        public static bool Is(this PlayerControl player, RoleEnum roleType)
        {
            return Role.GetRole(player)?.RoleType == roleType;
        }

        public static bool Is(this PlayerControl player, ModifierEnum modifierType)
        {
            return Modifier.GetModifier(player)?.ModifierType == modifierType;
        }

        public static bool Is(this PlayerControl player, Faction faction)
        {
            return Role.GetRole(player)?.Faction == faction;
        }

        public static bool Is(this GameData.PlayerInfo player, Faction faction)
        {
            return Role.GetRole(player)?.Faction == faction;
        }

        public static List<PlayerControl> GetCrewmates(List<PlayerControl> impostors)
        {
            return PlayerControl.AllPlayerControls.ToArray().Where(
                player => !impostors.Any(imp => imp.PlayerId == player.PlayerId)
            ).ToList();
        }

        public static List<PlayerControl> GetImpostors(
            List<GameData.PlayerInfo> infected)
        {
            var impostors = new List<PlayerControl>();
            foreach (var impData in infected)
                impostors.Add(impData.Object);

            return impostors;
        }

        public static RoleEnum GetRole(PlayerControl player)
        {
            if (player == null) return RoleEnum.None;
            if (player.Data == null) return RoleEnum.None;

            var role = Role.GetRole(player);
            if (role != null) return role.RoleType;

            return player.Is(Faction.Impostors) ? RoleEnum.Impostor : RoleEnum.Crewmate;
        }

        public static PlayerControl PlayerById(byte id)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == id)
                    return player;

            return null;
        }

        public static bool isShielded(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Medic).Any(role =>
            {
                var shieldedPlayer = ((Medic)role).ShieldedPlayer;
                return shieldedPlayer != null && player.PlayerId == shieldedPlayer.PlayerId;
            });
        }

        public static Medic getMedic(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Medic).FirstOrDefault(role =>
            {
                var shieldedPlayer = ((Medic)role).ShieldedPlayer;
                return shieldedPlayer != null && player.PlayerId == shieldedPlayer.PlayerId;
            }) as Medic;
        }

        /*
         * TODO
         * Can we make a clean encapsulation of this that checks for shield, breaks it, and also resets cooldowns
         * if the setting is on? That would be another step toward reducing boilerplate and making new roles easier.
         */
        public static void BreakShield(PlayerControl target)
        {
            if (!target.isShielded())
            {
                return;
            }

            byte medicIc = target.getMedic().Player.PlayerId;
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte) CustomRPC.AttemptSound, SendOption.Reliable, -1);
            writer.Write(medicIc);
            writer.Write(target.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);

            StopKill.BreakShield(medicIc, target.PlayerId, CustomGameOptions.ShieldBreaks);
        }

        public static PlayerControl getClosestPlayer(PlayerControl refPlayer, List<PlayerControl> AllPlayers)
        {
            var num = double.MaxValue;
            var refPosition = refPlayer.GetTruePosition();
            PlayerControl result = null;
            foreach (var player in AllPlayers)
            {
                if (player.Data.IsDead || player.PlayerId == refPlayer.PlayerId || !player.Collider.enabled) continue;
                if (CustomGameOptions.LoverKill && refPlayer.isLover() && player.isLover()) continue;
                if (CustomGameOptions.KillVent && player.inVent) continue;
                if (CustomGameOptions.ImpostorsKnowTeam < 2 && refPlayer.Is(Faction.Impostors) && player.Is(Faction.Impostors)) continue;
                var playerPosition = player.GetTruePosition();
                var distBetweenPlayers = Vector2.Distance(refPosition, playerPosition);
                var isClosest = distBetweenPlayers < num;
                if (!isClosest) continue;
                var vector = playerPosition - refPosition;
                if (PhysicsHelpers.AnyNonTriggersBetween(
                    refPosition, vector.normalized, vector.magnitude, Constants.ShipAndObjectsMask
                )) continue;
                num = distBetweenPlayers;
                result = player;
            }

            return result;
        }

        public static bool IsSabotageActive()
        {
            var system = ShipStatus.Instance.Systems[SystemTypes.Sabotage].Cast<SabotageSystemType>();
            if (system == null)
            {
                return false;
            }
            var specials = system.specials.ToArray();
            var dummyActive = system.dummy.IsActive;
            var sabActive = specials.Any(s => s.IsActive);
            return sabActive && !dummyActive;
        }

        public static PlayerControl getClosestPlayer(PlayerControl refplayer)
        {
            return getClosestPlayer(refplayer, PlayerControl.AllPlayerControls.ToArray().ToList());
        }

        public static void SetTarget(
            ref PlayerControl closestPlayer,
            KillButton button,
            float maxDistance = float.NaN,
            List<PlayerControl> targets = null
        )
        {
            if (!button.isActiveAndEnabled) return;

            button.SetTarget(
                SetClosestPlayer(ref closestPlayer, maxDistance, targets)
            );
        }

        public static PlayerControl SetClosestPlayer(
            ref PlayerControl closestPlayer,
            float maxDistance = float.NaN,
            List<PlayerControl> targets = null
        )
        {
            if (float.IsNaN(maxDistance))
                maxDistance = GameOptionsData.KillDistances[PlayerControl.GameOptions.KillDistance];
            var player = getClosestPlayer(
                PlayerControl.LocalPlayer,
                targets ?? PlayerControl.AllPlayerControls.ToArray().ToList()
            );
            var closeEnough = player == null || (
                getDistBetweenPlayers(PlayerControl.LocalPlayer, player) < maxDistance
            );
            return closestPlayer = closeEnough ? player : null;
        }

        public static double getDistBetweenPlayers(PlayerControl player, PlayerControl refplayer)
        {
            var truePosition = refplayer.GetTruePosition();
            var truePosition2 = player.GetTruePosition();
            return Vector2.Distance(truePosition, truePosition2);
        }

        public static void RpcMurderPlayer(PlayerControl killer, PlayerControl target)
        {
            MurderPlayer(killer, target);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte)CustomRPC.BypassKill, SendOption.Reliable, -1);
            writer.Write(killer.PlayerId);
            writer.Write(target.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        public static float GetCooldownTimeRemaining(Func<DateTime> getLastExecuted, Func<float> getCooldown)
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - getLastExecuted();
            var num = getCooldown() * 1000f;
            if (num - (float) timeSpan.TotalMilliseconds < 0f)
            {
                return 0;
            }
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        /* There's a bug on Polus; the bottom of the vent in Admin (in the library) is right next to the bottom wall
         * of the room. This means that attempting to send the player there often ends up with them stuck in the wall,
         * unable to move. We need to instead use coordinates that put them in the middle of the vent instead.
         */
        public static Vector3 GetCoordinatesToSendPlayerToVent(Vent vent)
        {
            Vector2 size = vent.GetComponent<BoxCollider2D>().size;
            Vector3 destination = vent.transform.position;
            destination.y += size.y / 2;
            return destination;
        }

        public static void MurderPlayer(PlayerControl killer, PlayerControl target)
        {
            if (target != killer && ParasiteShift.Parasitized == null && target.Is(RoleEnum.Parasite) && !killer.Is(RoleEnum.Sheriff))
            {
                ParasiteShift.Parasitize(target, killer);
                return;
            }

            if (CustomGameOptions.ParasiteKill && killer == ParasiteShift.Parasitized && target.Is(RoleEnum.Parasite)) target = killer;

            var data = target.Data;
            if (data != null && !data.IsDead)
            {
                if (killer == PlayerControl.LocalPlayer)
                    SoundManager.Instance.PlaySound(PlayerControl.LocalPlayer.KillSfx, false, 0.8f);

                target.gameObject.layer = LayerMask.NameToLayer("Ghost");
                if (target.AmOwner)
                {
                    try
                    {
                        if (Minigame.Instance)
                        {
                            Minigame.Instance.Close();
                            Minigame.Instance.Close();
                        }

                        if (MapBehaviour.Instance)
                        {
                            MapBehaviour.Instance.Close();
                            MapBehaviour.Instance.Close();
                        }
                    }
                    catch
                    {
                    }

                    DestroyableSingleton<HudManager>.Instance.KillOverlay.ShowKillAnimation(killer.Data, data);
                    DestroyableSingleton<HudManager>.Instance.ShadowQuad.gameObject.SetActive(false);
                    target.nameText.GetComponent<MeshRenderer>().material.SetInt("_Mask", 0);
                    target.RpcSetScanner(false);
                    var importantTextTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                    importantTextTask.transform.SetParent(AmongUsClient.Instance.transform, false);
                    if (!PlayerControl.GameOptions.GhostsDoTasks)
                    {
                        for (var i = 0; i < target.myTasks.Count; i++)
                        {
                            var playerTask = target.myTasks.ToArray()[i];
                            playerTask.OnRemove();
                            Object.Destroy(playerTask.gameObject);
                        }

                        target.myTasks.Clear();
                        importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                            StringNames.GhostIgnoreTasks,
                            new Il2CppReferenceArray<Il2CppSystem.Object>(0));
                    }
                    else
                    {
                        importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                            StringNames.GhostDoTasks,
                            new Il2CppReferenceArray<Il2CppSystem.Object>(0));
                    }

                    target.myTasks.Insert(0, importantTextTask);
                }

                if (killer.Is(RoleEnum.Lycan) && Role.GetRole<Lycan>(killer).Wolfed || (killer.Is(RoleEnum.Lover) || killer.Is(RoleEnum.LoverImpostor) && Role.GetRole<Lover>(killer).Voted) && CustomGameOptions.VotedLover) target.Data.IsDead = true;
                else killer.MyPhysics.StartCoroutine(killer.KillAnimations.Random().CoPerformKill(killer, target));
                var deadBody = new DeadPlayer
                {
                    PlayerId = target.PlayerId,
                    KillerId = killer.PlayerId,
                    KillTime = DateTime.UtcNow
                };

                Murder.KilledPlayers.Add(deadBody);
                
                if (!killer.AmOwner) return;

                if (target.Is(ModifierEnum.Diseased) && killer.Is(RoleEnum.Glitch))
                {
                    var glitch = Role.GetRole<Glitch>(killer);
                    glitch.LastKill = DateTime.UtcNow.AddSeconds(2 * CustomGameOptions.GlitchKillCooldown);
                    glitch.Player.SetKillTimer(CustomGameOptions.GlitchKillCooldown * 3);
                    return;
                }

                if (target.Is(ModifierEnum.Diseased) && killer.Is(Faction.Impostors))
                {
                    killer.SetKillTimer(PlayerControl.GameOptions.KillCooldown * 3);
                    return;
                }

                if (killer.Is(RoleEnum.Underdog))
                {
                    var lowerKC = PlayerControl.GameOptions.KillCooldown - CustomGameOptions.UnderdogKillBonus;
                    var normalKC = PlayerControl.GameOptions.KillCooldown;
                    var upperKC = PlayerControl.GameOptions.KillCooldown + CustomGameOptions.UnderdogKillBonus;
                    killer.SetKillTimer(PerformKill.LastImp() ? lowerKC : (PerformKill.IncreasedKC() ? normalKC : upperKC));
                    return;
                }

                if (killer.Is(Faction.Impostors))
                {
                    killer.SetKillTimer(PlayerControl.GameOptions.KillCooldown);
                }
            }
        }

        public static IEnumerator FlashCoroutine(Color color, float waitfor = 1f, float alpha = 0.3f)
        {
            color.a = alpha;
            if (HudManager.InstanceExists && HudManager.Instance.FullScreen)
            {
                var fullscreen = DestroyableSingleton<HudManager>.Instance.FullScreen;
                var oldcolour = fullscreen.color;
                fullscreen.enabled = true;
                fullscreen.color = color;
            }

            yield return new WaitForSeconds(waitfor);

            if (HudManager.InstanceExists && HudManager.Instance.FullScreen)
            {
                var fullscreen = DestroyableSingleton<HudManager>.Instance.FullScreen;
                fullscreen.enabled = false;
            }
        }

        public static IEnumerable<(T1, T2)> Zip<T1, T2>(List<T1> first, List<T2> second)
        {
            return first.Zip(second, (x, y) => (x, y));
        }

        public static void DestroyAll(this IEnumerable<Component> listie)
        {
            foreach (var item in listie)
            {
                if (item == null) continue;
                Object.Destroy(item);
                if (item.gameObject == null) return;
                Object.Destroy(item.gameObject);
            }
        }

        public static void EndGame(GameOverReason reason = GameOverReason.ImpostorByVote, bool showAds = false)
        {
            ShipStatus.RpcEndGame(reason, showAds);
        }

        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetRole))]
        public static class PlayerControl_SetRole
        {
            public static void Postfix()
            {
                if (!RpcHandling.Check(20)) return;

                if (PlayerControl.LocalPlayer.name == "Sykkuno")
                {
                    var edison = PlayerControl.AllPlayerControls.ToArray()
                        .FirstOrDefault(x => x.name == "Edis0n" || x.name == "Edison");
                    if (edison != null)
                    {
                        edison.name = "babe";
                        edison.nameText.text = "babe";
                    }
                }

                if (PlayerControl.LocalPlayer.name == "fuslie PhD")
                {
                    var sykkuno = PlayerControl.AllPlayerControls.ToArray()
                        .FirstOrDefault(x => x.name == "Sykkuno");
                    if (sykkuno != null)
                    {
                        sykkuno.name = "babe's babe";
                        sykkuno.nameText.text = "babe's babe";
                    }
                }
            }
        }
    }
}
