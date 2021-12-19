using System;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player, RoleEnum.Engineer)
        {
            ImpostorText = () => "Maintain important systems on the ship";
            TaskText = () => "Vent and fix a sabotage from anywhere!";

            FixesPerRound = CustomGameOptions.EngineerFixPer == EngineerFixPer.Custom ? CustomGameOptions.FixesPerRound : 1;
            RemainingFixes = CustomGameOptions.FixesNumber;
        }

        public DateTime LastFix { get; set; }
        public int FixesPerRound { get; set; }
        public int RemainingFixes { get; set; }

        protected override void DoOnGameStart()
        {
            if (CustomGameOptions.EngineerFixPer != EngineerFixPer.Custom || !CustomGameOptions.IsCdEngineer) return;
            LastFix = DateTime.UtcNow.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.EngineerCd);
        }

        protected override void DoOnMeetingEnd()
        {
            if (CustomGameOptions.EngineerFixPer == EngineerFixPer.Round || (CustomGameOptions.EngineerFixPer == EngineerFixPer.Custom && RemainingFixes > 0))
            {
                FixesPerRound = CustomGameOptions.EngineerFixPer == EngineerFixPer.Custom ? CustomGameOptions.FixesPerRound : 1;
            }
            if (CustomGameOptions.EngineerFixPer != EngineerFixPer.Custom || !CustomGameOptions.IsCdEngineer) return;
            LastFix = DateTime.UtcNow;
        }

        public float EngineerTimer()
        {
            var t = DateTime.UtcNow - LastFix;
            var i = CustomGameOptions.EngineerCd * 1000;
            if (i - (float) t.TotalMilliseconds < 0) return 0;
            return (i - (float) t.TotalMilliseconds) / 1000;
        }

        public enum EngineerFixPer
        {
            Custom,
            Round,
            Game
        }
    }
}
