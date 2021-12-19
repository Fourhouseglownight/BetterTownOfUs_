using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetterTownOfUs.Roles
{
    public class Swooper : Role
    {
        public KillButton _swoopButton;
        public bool Enabled;
        public DateTime LastSwooped;
        public float TimeRemaining;

        public Swooper(PlayerControl player) : base(player, RoleEnum.Swooper)
        {
            ImpostorText = () => "Turn invisible temporarily";
            TaskText = () => "Turn invisible and sneakily kill";
        }

        protected override void DoOnGameStart()
        {
            LastSwooped = DateTime.UtcNow.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.SwoopCd);
        }

        protected override void DoOnMeetingEnd()
        {
            LastSwooped = DateTime.UtcNow;
        }
        public bool IsSwooped => TimeRemaining > 0f;

        public KillButton SwoopButton
        {
            get => _swoopButton;
            set
            {
                _swoopButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float SwoopTimer()
        {
            return Utils.GetCooldownTimeRemaining(() => LastSwooped, () => CustomGameOptions.SwoopCd);
        }

        public void Swoop()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            Utils.MakeInvisible(Player, PlayerControl.LocalPlayer.Is(Faction.Impostors) || PlayerControl.LocalPlayer.Data.IsDead);
        }

        public void UnSwoop()
        {
            Enabled = false;
            LastSwooped = DateTime.UtcNow;
            Utils.MakeVisible(Player);
        }
    }
}
