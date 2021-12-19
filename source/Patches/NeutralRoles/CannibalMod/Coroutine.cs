using System.Collections;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.NeutralRoles.CannibalMod
{
    public class Coroutine
    {
        private static readonly int BodyColor = Shader.PropertyToID("_BodyColor");
        private static readonly int BackColor = Shader.PropertyToID("_BackColor");

        public static IEnumerator EatCoroutine(DeadBody body, Cannibal role)
        {
            KillButtonTarget.SetTarget(DestroyableSingleton<HudManager>.Instance.KillButton, null, role);
            var renderer = body.bodyRenderer;
            var backColor = renderer.material.GetColor(BackColor);
            var bodyColor = renderer.material.GetColor(BodyColor);
            var newColor = new Color(1f, 1f, 1f, 0f);
            for (var i = 0; i < 60; i++)
            {
                if (body == null) yield break;
                renderer.color = Color.Lerp(backColor, newColor, i / 60);
                renderer.color = Color.Lerp(bodyColor, newColor, i / 60);
                yield return null;
            }

            Object.Destroy(body.gameObject);    
            role.EatNeed--;
            role.RegenTask();
            /*if (PlayerControl.LocalPlayer.Is(RoleEnum.Cannibal))
            {
                string bodyTxt = role.EatNeed == 1 ? "Body" : "Bodies";
                PlayerControl.LocalPlayer.myTasks.ToArray()[0].Cast<ImportantTextTask>().Text = $"{role.ColorString}Role: Cannibal\nYou're hungry, you need to eat {role.EatNeed} Dead {bodyTxt} to Win\nFake Tasks:</color>";
            }*/
        }
    }
}