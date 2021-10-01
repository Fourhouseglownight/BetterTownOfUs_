using System;
using UnityEngine;
using BetterTownOfUs.Extensions;

namespace BetterTownOfUs.Roles
{
    public class Lycan : Role, IVisualAlteration
    {
        public Lycan(PlayerControl player) : base(player)
        {
            Name = "Lycan";
            ImpostorText = () => "Eat Crewmates";
            TaskText = () => "Transform you into wolf to eat Crewmates but still discret.";
            Color = Palette.ImpostorRed;
            LycanButton = null;
            Wolfed = false;
            LastWolfed = DateTime.UtcNow;
            RoleType = RoleEnum.Lycan;
            Faction = Faction.Impostors;
        }

        public DateTime LastWolfed;
        public PlayerControl ClosestPlayer;
        public float TimeRemaining;
        public bool Wolfed { get; set; }
        public KillButtonManager _lycanButton;
        public KillButtonManager LycanButton
        {
            get => _lycanButton;
            set
            {
                _lycanButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public bool WolfedTiming => TimeRemaining > 0f;

        public void Morph()
        {
            TimeRemaining -= Time.deltaTime;
            Utils.Morph(Player, null);
        }

        public void Unmorph()
        {
            Wolfed = false;
            Utils.Unmorph(Player);
            LastWolfed = DateTime.UtcNow;
        }

        public float WolfTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastWolfed;
            var num = CustomGameOptions.WolfCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        public bool TryGetModifiedAppearance(out VisualAppearance appearance)
        {
            if (Wolfed)
            {
                appearance = Utils.WolfAppear;
                return true;
            }

            appearance = Player.GetDefaultAppearance();
            return false;
        }
    }
}