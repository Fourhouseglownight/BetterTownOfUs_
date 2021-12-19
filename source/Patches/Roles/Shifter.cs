using System;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Shifter : Role
    {
        public Shifter(PlayerControl player) : base(player, RoleEnum.Shifter)
        {
            ImpostorText = () => "Shift around different roles";
            TaskText = () => "Steal other people's roles.\nFake Tasks:";
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastShifted { get; set; }

        protected override void DoOnGameStart()
        {
            LastShifted = DateTime.UtcNow.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.ShifterCd);
        }

        protected override void DoOnMeetingEnd()
        {
            LastShifted = DateTime.UtcNow;
        }

        public void Loses()
        {
            LostByRPC = true;
        }

        public float ShifterShiftTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastShifted;
            var num = CustomGameOptions.ShifterCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}
