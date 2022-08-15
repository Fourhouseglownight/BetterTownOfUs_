using HarmonyLib;

namespace BetterTownOfUs
{
    [HarmonyPatch(typeof(ChatController), nameof(ChatController.SendChat))]
    class SendChatPatch
    {
        public static bool Prefix(ChatController __instance)
        {
            string text = __instance.TextArea.text;
            bool handled = false;
            if (text.ToLower().StartsWith("/set"))
            {
                __instance.AddChat(PlayerControl.LocalPlayer, clearSettingsTxt(GameSettings.SettingsTxt).Remove(0, 25));
                handled = true;
            }

            if (handled)
            {
                __instance.TextArea.Clear();
                __instance.quickChatMenu.ResetGlyphs();
            }
            return !handled;
        }

        private static string clearSettingsTxt(string text)
        {
            while (text.Contains("</color>")) text = text.Remove(text.IndexOf("/") - 1, 8);
            while (text.Contains("<color")) text = text.Remove(text.IndexOf("<"), 17);
            return text;
        }
    }
}
