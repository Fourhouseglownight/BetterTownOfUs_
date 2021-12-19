﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetterTownOfUs.Roles
{
    public class Miner : Role
    {
        public readonly List<Vent> Vents = new List<Vent>();

        public KillButton _mineButton;
        public DateTime LastMined;


        public Miner(PlayerControl player) : base(player, RoleEnum.Miner)
        {
            ImpostorText = () => "From the top, make it drop, that's a vent";
            TaskText = () => "From the top, make it drop, that's a vent";
            LastMined = DateTime.UtcNow;
        }

        public bool CanPlace { get; set; }
        public Vector2 VentSize { get; private set; }

        protected override void DoOnGameStart()
        {
            LastMined = DateTime.UtcNow.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.MineCd);
            var vents = Object.FindObjectsOfType<Vent>();
            VentSize =
                Vector2.Scale(vents[0].GetComponent<BoxCollider2D>().size, vents[0].transform.localScale) * 0.75f;
        }

        protected override void DoOnMeetingEnd()
        {
            LastMined = DateTime.UtcNow;
        }

        public KillButton MineButton
        {
            get => _mineButton;
            set
            {
                _mineButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float MineTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastMined;
            var num = CustomGameOptions.MineCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}
