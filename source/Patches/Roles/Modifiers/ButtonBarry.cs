using UnityEngine;

namespace BetterTownOfUs.Roles.Modifiers
{
    public class ButtonBarry : Modifier
    {
        public KillButton ButtonButton;

        public bool ButtonUsed;

        public ButtonBarry(PlayerControl player) : base(player, ModifierEnum.ButtonBarry)
        {
            Name = "Button Barry";
            TaskText = () => "Call a button from anywhere!";
            Color = new Color(0.9f, 0f, 1f, 1f);
        }
    }
}