﻿using System;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Camouflager : Role

    {
        public KillButton _camouflageButton;
        public bool Enabled;
        public DateTime LastCamouflaged;
        public float TimeRemaining;

        public Camouflager(PlayerControl player) : base(player, RoleEnum.Camouflager)
        {
            ImpostorText = () => "Camouflage and turn everyone grey";
            TaskText = () => "Camouflage and get secret kills";
        }

        protected override void DoOnGameStart()
        {
            LastCamouflaged = DateTime.UtcNow.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.CamouflagerCd);
        }

        protected override void DoOnMeetingEnd()
        {
            LastCamouflaged = DateTime.UtcNow;
        }

        public bool Camouflaged => TimeRemaining > 0f;

        public KillButton CamouflageButton
        {
            get => _camouflageButton;
            set
            {
                _camouflageButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public void Camouflage()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            Utils.Camouflage();
        }

        public void UnCamouflage()
        {
            Enabled = false;
            LastCamouflaged = DateTime.UtcNow;
            Utils.UnCamouflage();
        }

        public float CamouflageTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastCamouflaged;
            var num = CustomGameOptions.CamouflagerCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}
