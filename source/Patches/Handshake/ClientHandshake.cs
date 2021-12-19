using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Hazel;
using InnerNet;
using Reactor;
using UnityEngine;

namespace BetterTownOfUs.Handshake
{
    public static class ClientHandshake
    {
        private const byte BTOU_ROOT_HANDSHAKE_TAG = 88;

        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameJoined))]
        public static class AmongUsClient_OnGameJoined
        {
            public static void Postfix(AmongUsClient __instance)
            {
                if (AmongUsClient.Instance.AmHost)
                    return;

                // If I am client, send handshake
                BetterTownOfUs.log.LogMessage($"AmongUsClient.OnGameJoined.Postfix - Am client, sending handshake");
                var messageWriter = MessageWriter.Get(SendOption.Reliable);
                messageWriter.StartMessage(6);
                messageWriter.Write(__instance.GameId);
                messageWriter.WritePacked(__instance.HostId);
                messageWriter.StartMessage(BTOU_ROOT_HANDSHAKE_TAG);
                messageWriter.Write(AmongUsClient.Instance.ClientId);
                messageWriter.Write(BetterTownOfUs.GetVersion());
                messageWriter.EndMessage();
                messageWriter.EndMessage();
                __instance.SendOrDisconnect(messageWriter);
                messageWriter.Recycle();
            }
        }

        [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.HandleGameData))]
        public static class InnerNetClient_HandleGameData
        {
            public static bool Prefix(InnerNetClient __instance,
                [HarmonyArgument(0)] MessageReader reader)
            {
                // If i am host, respond to handshake
                if (__instance.AmHost && reader.BytesRemaining > 3)
                {
                    var handshakeReader = MessageReader.Get(reader).ReadMessageAsNewBuffer();
                    if (handshakeReader.Tag == BTOU_ROOT_HANDSHAKE_TAG)
                    {
                        BetterTownOfUs.log.LogMessage($"InnerNetClient.HandleMessage.Prefix - Host recieved BTOU handshake");

                        var clientId = handshakeReader.ReadInt32();
                        var btouVersion = handshakeReader.ReadString();

                        // List<int> HandshakedClients - exists to disconnect legacy clients that don't send handshake
                        BetterTownOfUs.log.LogMessage($"InnerNetClient.HandleMessage.Prefix - Adding {clientId} with BTOU version {btouVersion} to List<int>HandshakedClients");
                        HandshakedClients.Add(clientId);

                        if (!BetterTownOfUs.GetVersion().Equals(btouVersion))
                        {
                            BetterTownOfUs.log.LogMessage($"InnerNetClient.HandleMessage.Prefix - ClientId {clientId} has mismatched BTOU version {btouVersion}. (Ours is {BetterTownOfUs.GetVersion()})");
                            __instance.SendCustomDisconnect(clientId);
                        }

                        return false;
                    }
                }

                return true;
            }
        }

        // Handle legacy clients that don't send handshakes
        private static HashSet<int> HandshakedClients = new HashSet<int>();
        private static IEnumerator WaitForHandshake(InnerNetClient innerNetClient, int clientId)
        {
            BetterTownOfUs.log.LogMessage($"WaitForHandshake(innerNetClient, clientId = {clientId})");

            yield return new WaitForSeconds(5f);
            BetterTownOfUs.log.LogMessage($"WaitForHandshake() - Waited 5 seconds");
            if (!HandshakedClients.Contains(clientId))
            {
                BetterTownOfUs.log.LogMessage($"WaitForHandshake() - HandshakedClients did not contain clientId {clientId}");
                if (innerNetClient.allClients.ToArray().Any(x => x.Id == clientId))
                    innerNetClient.SendCustomDisconnect(clientId);
            }
            else
            {
                BetterTownOfUs.log.LogMessage($"WaitForHandshake() - HandshakedClients contained clientId {clientId}");
            }
        }

        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
        public static class AmongUsClient_OnPlayerJoined
        {
            public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData data)
            {
                if (AmongUsClient.Instance.AmHost && __instance.GameState == InnerNetClient.GameStates.Started)
                {
                    BetterTownOfUs.log.LogMessage($"Am host and clientId {data.Id} sent JoinGameResponse");
                    Coroutines.Start(WaitForHandshake(__instance, data.Id));
                }
            }
        }

        private static void SendCustomDisconnect(this InnerNetClient innerNetClient, int clientId)
        {
            var messageWriter = MessageWriter.Get(SendOption.Reliable);
            messageWriter.StartMessage(11);
            messageWriter.Write(innerNetClient.GameId);
            messageWriter.WritePacked(clientId);
            messageWriter.Write(false);
            messageWriter.Write(8);
            messageWriter.Write($"The host has a different version of Better Town Of Us ({BetterTownOfUs.GetVersion()})");
            messageWriter.EndMessage();
            innerNetClient.SendOrDisconnect(messageWriter);
            messageWriter.Recycle();
        }
    }
}
