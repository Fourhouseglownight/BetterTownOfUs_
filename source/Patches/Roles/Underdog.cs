﻿using BetterTownOfUs.ImpostorRoles.UnderdogMod;

namespace BetterTownOfUs.Roles
{
    public class Underdog : Role
    {
        public PlayerControl ClosestPlayer;
        public Underdog(PlayerControl player) : base(player)
        {
            Name = "Underdog";
            ImpostorText = () => "Use your comeback power to win";
            TaskText = () => "long kill cooldown when 2 imps, short when 1 imp";
            Color = Palette.ImpostorRed;
            RoleType = RoleEnum.Underdog;
            Faction = Faction.Impostors;
        }

        protected override void DoOnMeetingEnd()
        {
            SetKillTimer();
        }

        public float MaxTimer() => PlayerControl.GameOptions.KillCooldown * (
            PerformKill.LastImp() ? 0.5f : 1.5f
        );

        public void SetKillTimer()
        {
            Player.SetKillTimer(MaxTimer());
        }
    }
}
