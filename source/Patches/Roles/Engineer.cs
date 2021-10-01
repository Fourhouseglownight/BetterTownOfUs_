using System;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            ImpostorText = () => "Maintain important systems on the ship";
            TaskText = () => "Vent and fix a sabotage from anywhere!";
            Color = new Color(1f, 0.65f, 0.04f, 1f);
            RoleType = RoleEnum.Engineer;

            FR = CustomGameOptions.FixesPerRound;
            RF = CustomGameOptions.FixesNumber;
        }

        public DateTime LF { get; set; }
        public int FR { get; set; }
        public int RF { get; set; }

        public bool UsedThisRound { get; set; } = false;

        public float EngineerTimer()
        {
            var t = DateTime.UtcNow - LF;
            var i = CustomGameOptions.EngineerCd * 1000;
            if (i - (float) t.TotalMilliseconds < 0) return 0;
            return (i - (float) t.TotalMilliseconds) / 1000;
        }
    }
}