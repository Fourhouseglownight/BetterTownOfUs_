using System.Collections.Generic;
using System.Linq;
using Hazel;
using Reactor;
using UnityEngine;
using UnityEngine.UI;
using BetterTownOfUs.CrewmateRoles.MedicMod;
using BetterTownOfUs.Roles.Modifiers;

namespace BetterTownOfUs.Roles
{
    public enum MissKillNotifEnum
    {
        Everyone,
        TargetAndGuesser,
        Guesser
    }

    public class GuesserKill
    {
        public static List<PlayerControl> GoodGuesser;
        public static void RpcMurderPlayer(PlayerControl player)
        {
            PlayerVoteArea voteArea = MeetingHud.Instance.playerStates.First(
                x => x.TargetPlayerId == player.PlayerId
            );
            RpcMurderPlayer(voteArea, player);
        }
        public static void RpcMurderPlayer(PlayerVoteArea voteArea, PlayerControl player)
        {
            MurderPlayer(voteArea, player);
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte) CustomRPC.GuesserKill, SendOption.Reliable, -1);
            writer.Write(player.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        public static void MurderPlayer(PlayerControl player, bool checkLover = true)
        {
            PlayerVoteArea voteArea = MeetingHud.Instance.playerStates.First(
                x => x.TargetPlayerId == player.PlayerId
            );
            MurderPlayer(voteArea, player, checkLover);
        }
        public static void MurderPlayer(
            PlayerVoteArea voteArea,
            PlayerControl player,
            bool checkLover = true
        )
        {
            HudManager hudManager = DestroyableSingleton<HudManager>.Instance;
            if (checkLover)
            {
                SoundManager.Instance.PlaySound(player.KillSfx, false, 0.8f);
                hudManager.KillOverlay.ShowKillAnimation(player.Data, player.Data);
            }

            if (player.AmOwner)
            {
                hudManager.ShadowQuad.gameObject.SetActive(false);
                player.nameText.GetComponent<MeshRenderer>().material.SetInt("_Mask", 0);
                player.RpcSetScanner(false);
                ImportantTextTask importantTextTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                importantTextTask.transform.SetParent(AmongUsClient.Instance.transform, false);
                if (!PlayerControl.GameOptions.GhostsDoTasks)
                {
                    for (int i = 0;i < player.myTasks.Count;i++)
                    {
                        PlayerTask playerTask = player.myTasks.ToArray()[i];
                        playerTask.OnRemove();
                        Object.Destroy(playerTask.gameObject);
                    }

                    player.myTasks.Clear();
                    importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                        StringNames.GhostIgnoreTasks,
                        new UnhollowerBaseLib.Il2CppReferenceArray<Il2CppSystem.Object>(0)
                    );
                }
                else
                {
                    importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                        StringNames.GhostDoTasks,
                        new UnhollowerBaseLib.Il2CppReferenceArray<Il2CppSystem.Object>(0));
                }

                player.myTasks.Insert(0, importantTextTask);

                if (player.Is(RoleEnum.Retributionist))
                {
                    Retributionist retributionist = Role.GetRole<Retributionist>(PlayerControl.LocalPlayer);
                    ShowHideButtons.HideButtons(retributionist);
                }

                else if (player.Is(RoleEnum.Mentalist))
                {
                    Mentalist mentalist = Role.GetRole<Mentalist>(PlayerControl.LocalPlayer);
                    ShowHideButtons.HideButtons(mentalist);
                }

                else if (Assassin.IsAssassin(player))
                {
                    Assassin assassin = Assassin.GetAssassin<Assassin>(PlayerControl.LocalPlayer);
                    ShowHideButtons.HideButtons(assassin);
                }
                
                else if (player.Is(RoleEnum.Swapper))
                {
                    List<GameObject> buttons = Role.GetRole<Swapper>(player).Buttons;
                    foreach (GameObject button in buttons)
                    {
                        button.SetActive(false);
                        button.GetComponent<PassiveButton>().OnClick = new Button.ButtonClickedEvent();
                    }
                }
            }
            player.Die(DeathReason.Kill);
            if (checkLover && player.isLover() && CustomGameOptions.BothLoversDie)
                MurderPlayer(Role.GetRole<Lover>(player).OtherLover.Player, false);

            MeetingHud meetingHud = MeetingHud.Instance;
            if (player.AmOwner)
            {
                meetingHud.SetForegroundForDead();
            }
            DeadPlayer deadPlayer = new DeadPlayer
            {
                PlayerId = player.PlayerId,
                KillerId = player.PlayerId,
                KillTime = System.DateTime.UtcNow,
            };

            Murder.KilledPlayers.Add(deadPlayer);
            if (voteArea == null) return;
            if (voteArea.DidVote) voteArea.UnsetVote();
            voteArea.AmDead = true;
            voteArea.Overlay.gameObject.SetActive(true);
            voteArea.Overlay.color = Color.white;
            voteArea.XMark.gameObject.SetActive(true);
            voteArea.XMark.transform.localScale = Vector3.one;

            voteArea.Buttons.SetActive(false);
            foreach (PlayerVoteArea playerVoteArea in meetingHud.playerStates)
            {
                if (playerVoteArea.VotedFor != player.PlayerId) continue;
                playerVoteArea.UnsetVote();
                PlayerControl voteAreaPlayer = Utils.PlayerById(playerVoteArea.TargetPlayerId);
                if (!voteAreaPlayer.AmOwner) continue;
                meetingHud.ClearVote();
            }

            if (!AmongUsClient.Instance.AmHost) return;
            foreach (Role role in Role.GetRoles(RoleEnum.Mayor))
            {
                Mayor mayor = (Mayor)role;
                if (role.Player.PlayerId == player.PlayerId)
                {
                    mayor.ExtraVotes.Clear();
                }
                else
                {
                    int votesRegained = mayor.ExtraVotes.RemoveAll(x => x == player.PlayerId);

                    if (mayor.Player == PlayerControl.LocalPlayer)
                        mayor.VoteBank += votesRegained;

                    MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte)CustomRPC.AddMayorVoteBank, SendOption.Reliable, -1);
                    writer.Write(mayor.Player.PlayerId);
                    writer.Write(votesRegained);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                }
            }
            meetingHud.CheckForEndVoting();
        }

        public static void RpcMissKill(PlayerControl player)
        {
            PlayerVoteArea voteArea = MeetingHud.Instance.playerStates.First(
                x => x.TargetPlayerId == player.PlayerId
            );
            RpcMissKill(voteArea, player);
        }
        public static void RpcMissKill(PlayerVoteArea voteArea, PlayerControl player)
        {
            Coroutines.Start(Utils.FlashCoroutine(Color.red));
            if (CustomGameOptions.GuesserMissKillNotif == MissKillNotifEnum.Guesser) return;
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte) CustomRPC.GuesserMissKill, SendOption.Reliable, -1);
            writer.Write(player.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        public static void MissKillNotif(PlayerControl player)
        {
            if (CustomGameOptions.GuesserMissKillNotif == MissKillNotifEnum.TargetAndGuesser)
            {
                if (player.AmOwner) Coroutines.Start(Utils.FlashCoroutine(Color.red));
            }
            else Coroutines.Start(Utils.FlashCoroutine(Color.red));
        }
    }
}
