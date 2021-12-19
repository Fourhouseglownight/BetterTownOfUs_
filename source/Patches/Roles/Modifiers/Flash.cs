using BetterTownOfUs.Extensions;
using UnityEngine;

namespace BetterTownOfUs.Roles.Modifiers
{
    public class Flash : Modifier, IVisualAlteration
    {
        public static float SpeedFactor = 1.25f;

        public Flash(PlayerControl player) : base(player, ModifierEnum.Flash)
        {
            Name = "Flash";
            TaskText = () => "Superspeed!";
            Color = new Color(1f, 0.5f, 0.5f, 1f);
        }

        public bool TryGetModifiedAppearance(out VisualAppearance appearance)
        {
            appearance = Player.GetDefaultAppearance();
            appearance.SpeedFactor = SpeedFactor;
            return true;
        }
    }
}