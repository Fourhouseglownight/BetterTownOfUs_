using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace BetterTownOfUs.CustomOption
{
    [HarmonyPatch(typeof(OptionsMenuBehaviour), nameof(OptionsMenuBehaviour.Start))]
    public class OptionsMenuBehaviourStartPatch
    {
        private static Vector3? origin;
        private static ToggleButtonBehaviour streamButton;
        
        private static void updateToggle(ToggleButtonBehaviour button, string text, bool on)
        {
            if (button == null || button.gameObject == null) return;

            Color color = on ? new Color(0f, 1f, 0.16470589f, 1f) : Color.white;
            button.Background.color = color;
            button.Text.text = $"{text}{(on ? "On" : "Off")}";
            if (button.Rollover) button.Rollover.ChangeOutColor(color);
        }

        public static void Postfix(OptionsMenuBehaviour __instance)
        {
            if (__instance.CensorChatButton != null) {
                if (origin == null) origin = __instance.CensorChatButton.transform.localPosition;
                __instance.CensorChatButton.transform.localPosition = origin.Value + Vector3.left * 1.3f;
            }

            if ((streamButton == null || streamButton.gameObject == null)) {
                streamButton = UnityEngine.Object.Instantiate(__instance.CensorChatButton, __instance.CensorChatButton.transform.parent);
                streamButton.transform.localPosition = (origin ?? Vector3.zero) + Vector3.right * 1.3f;
                PassiveButton passiveButton = streamButton.GetComponent<PassiveButton>();
                passiveButton.OnClick = new Button.ButtonClickedEvent();
                passiveButton.OnClick.AddListener((UnityEngine.Events.UnityAction)streamToggle);
                updateToggle(streamButton, "Streamer Mode: ", BetterTownOfUs.StreamMode.Value);

                void streamToggle() {
                    BetterTownOfUs.StreamMode.Value = !BetterTownOfUs.StreamMode.Value;
                    Color color = BetterTownOfUs.StreamMode.Value ? new Color(0f, 1f, 0.16470589f, 1f) : Color.white;
                    streamButton.Background.color = color;
                    streamButton.Text.text = $"Streamer Mode: {(BetterTownOfUs.StreamMode.Value ? "On" : "Off")}";
                    if (streamButton.Rollover) streamButton.Rollover.ChangeOutColor(color);
                }
            }
        }
    }

    [HarmonyPatch(typeof(TextBoxTMP), nameof(TextBoxTMP.SetText))]
	public static class HiddenTextPatch
	{
		private static void Postfix(TextBoxTMP __instance)
		{
			if (BetterTownOfUs.StreamMode.Value && (__instance.name == "GameIdText" || __instance.name == "IpTextBox" || __instance.name == "PortTextBox")) __instance.outputText.text = new string('*', __instance.text.Length);
		}
	}
}
