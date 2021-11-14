using System;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Covert : Role
    {
        private KillButtonManager __covertButton;
        public DateTime LastCovert;
        public float CovertTimeRemaining;
        public bool IsCovert { get; private set; }

        public Covert(PlayerControl player) : base(player)
        {
            Name = "Covert";
            ImpostorText = () => "Do your tasks. Covertly.";
            TaskText = () => "Do your tasks. Covertly.";
            Color = new Color(0.48f, 0.50f, 0.10f, 1f);
            RoleType = RoleEnum.Covert;
            Faction = Faction.Crewmates;
        }

        protected override void DoOnGameStart()
        {
            LastCovert = DateTime.UtcNow;
            CovertTimeRemaining = 0f;
        }

        protected override void DoOnMeetingEnd()
        {
            LastCovert = DateTime.UtcNow;
            CovertTimeRemaining = 0f;
        }

        public KillButtonManager CovertButton
        {
            get => __covertButton;
            set
            {
                __covertButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float CovertTimer()
        {
            return Utils.GetCooldownTimeRemaining(() => LastCovert, () => CustomGameOptions.CovertCooldown);
        }

        public void CovertTick()
        {
            if (!IsCovert)
            {
                return;
            }

            if (CovertTimeRemaining > 0f)
            {
                // We have to apply invisibiility every tick, otherwise the default name color will make the name appear
                CovertTimeRemaining -= Time.deltaTime;
                Utils.MakeInvisible(Player, PlayerControl.LocalPlayer.Is(RoleEnum.Covert) || PlayerControl.LocalPlayer.Data.IsDead);
            }
            else
            {
                LeaveCovert();
            }
        }

        public void GoCovert()
        {
            IsCovert = true;
            CovertTimeRemaining = CustomGameOptions.CovertDuration;
            //Utils.MakeInvisible(Player, PlayerControl.LocalPlayer.Is(RoleEnum.Covert) || PlayerControl.LocalPlayer.Data.IsDead);
        }

        private void LeaveCovert()
        {
            IsCovert = false;
            LastCovert = DateTime.UtcNow;
            Utils.MakeVisible(Player);
        }
    }
}