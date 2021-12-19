using BetterTownOfUs.ImpostorRoles.UnderdogMod;

namespace BetterTownOfUs.Roles
{
    public class Underdog : Role
    {
        public Underdog(PlayerControl player) : base(player, RoleEnum.Underdog)
        {
            ImpostorText = () => "Use your comeback power to win";
            TaskText = () => "long kill cooldown when 2 imps, short when 1 imp";
        }

        protected override void DoOnMeetingEnd()
        {
            SetKillTimer();
        }

        public float MaxTimer() => PerformKill.LastImp() ? PlayerControl.GameOptions.KillCooldown - (CustomGameOptions.UnderdogKillBonus) : (PerformKill.IncreasedKC() ? PlayerControl.GameOptions.KillCooldown : PlayerControl.GameOptions.KillCooldown + (CustomGameOptions.UnderdogKillBonus));

        public void SetKillTimer()
        {
            Player.SetKillTimer(MaxTimer());
        }
    }
}
