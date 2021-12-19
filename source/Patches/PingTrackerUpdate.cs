using UnhollowerBaseLib;
using HarmonyLib;
using UnityEngine;

namespace BetterTownOfUs
{
    //[HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {
        [HarmonyPrefix]
        public static void Prefix(PingTracker __instance)
        {
            if (!__instance.GetComponentInChildren<SpriteRenderer>())
            {
                var spriteObject = new GameObject("VotezVertSprite");
                spriteObject.AddComponent<SpriteRenderer>().sprite = BetterTownOfUs.VotezVertSprite;
                spriteObject.transform.parent = __instance.transform;
                spriteObject.transform.localPosition = new Vector3(-1.1f, -0.7f, -1);
                spriteObject.transform.localScale *= 0.72f;
            }
        }

        [HarmonyPostfix]
        public static void Postfix(PingTracker __instance)
        {
            var position = __instance.GetComponent<AspectPosition>();
            if (!MeetingHud.Instance) position.DistanceFromEdge = new Vector3(3.1f, 0.1f, 0);
            else position.DistanceFromEdge = new Vector3(3.6f, 0.1f, -1);
            position.AdjustPosition();

            __instance.text.fontSize = 2.5f;
            __instance.text.text =
                "<color=#018001FF>BetterTownOfUs " + BetterTownOfUs.GetVersion() + "</color>\n" +
                "Disponible sur/Available on :\n" +
                "<color=#3769feFF>VisionUniverse.fr</color>\n" +
                $"Ping: {AmongUsClient.Instance.Ping}ms\n" +
                (!MeetingHud.Instance
                    ? "<color=#018001FF>Votez Vert ft. JMC</color>"
                    : "");
        }
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
    public class Start
    {
        public static float Timer = 620;
        public static string LobbyCodeText = "";
        public static void Postfix(GameStartManager __instance)
        {
            if (AmongUsClient.Instance.GameId == 32) return;
            Timer = 620; 
            string code = InnerNet.GameCode.IntToGameName(AmongUsClient.Instance.GameId);
            GUIUtility.systemCopyBuffer = code;
            LobbyCodeText = DestroyableSingleton<TranslationController>.Instance.GetString(StringNames.RoomCode, new Il2CppReferenceArray<Il2CppSystem.Object>(0)) + "\r\n" + code;
        }
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
    public class GameStartManagerUpdatePatch
    {
        private static bool update = false;
        
        public static void Prefix(GameStartManager __instance)
        {
            if (!AmongUsClient.Instance.AmHost  || !GameData.Instance || AmongUsClient.Instance.GameId == 32) return;
            update = GameData.Instance.PlayerCount != __instance.LastPlayerCount;
        }

        public static void Postfix(GameStartManager __instance)
        {
            if (AmongUsClient.Instance.GameId == 32) return;
            string currentText = "";
            __instance.GameRoomName.text = BetterTownOfUs.StreamMode.Value ? $"<color=#3769fe>Better\nTown of Us</color>" : Start.LobbyCodeText;

            if (!AmongUsClient.Instance.AmHost || !GameData.Instance) return;
            if (update) currentText = __instance.PlayerCounter.text;

            Start.Timer = Mathf.Max(0f, Start.Timer -= Time.deltaTime);
            int minutes = (int) Start.Timer / 60;
            int seconds = (int) Start.Timer % 60;
            string suffix = $"\t{minutes:00}:{seconds:00}";
            var color = minutes > 3 ? "#018001" : "#fc7703";
            if (minutes < 1) color = "#ff0000";

            __instance.PlayerCounter.text = currentText + $"<color={color}>{suffix}</color>";
            __instance.PlayerCounter.autoSizeTextContainer = true;
        }
    }
}
