using System;
using BetterTownOfUs.ImpostorRoles.CamouflageMod;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Concealer : Role
    {
        private KillButton _concealButton;
        public DateTime LastConcealed { get; set; }
        public float TimeBeforeConcealed { get; private set; }
        public float ConcealTimeRemaining { get; private set; }
        public PlayerControl Target;
        public PlayerControl Concealed { get; private set; }

        public Concealer(PlayerControl player) : base(player, RoleEnum.Concealer)
        {
            ImpostorText = () => "Conceal crewmates from each other for a sneaky kill";
            TaskText = () => "Conceal crewmates from each other for a sneaky kill";
        }

        protected override void DoOnGameStart()
        {
            LastConcealed = DateTime.UtcNow.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.ConcealCooldown);
            Target = null;
        }

        protected override void DoOnMeetingEnd()
        {
            LastConcealed = DateTime.UtcNow;
            Target = null;
        }

        public KillButton ConcealButton
        {
            get => _concealButton;
            set
            {
                _concealButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float ConcealTimer()
        {
            return Utils.GetCooldownTimeRemaining(() => LastConcealed, () => CustomGameOptions.ConcealCooldown);
        }

        public void StartConceal(PlayerControl concealed)
        {
            Concealed = concealed;
            TimeBeforeConcealed = CustomGameOptions.TimeToConceal;
        }

        /*
         * Called every time incremement. Will manage the time remaining and transition from Waiting to Conceal
         * to Concealed to Unconcealed.
         */
        public void ConcealTick()
        {
            if (Concealed == null)
            {
                return;
            }

            if (TimeBeforeConcealed > 0)
            {
                // Prevent this from going negative to avoid cooldown wonkiness
                TimeBeforeConcealed = Math.Clamp(TimeBeforeConcealed - Time.deltaTime, 0, TimeBeforeConcealed);
                if (TimeBeforeConcealed <= 0f)
                {
                    ConcealTimeRemaining = CustomGameOptions.ConcealDuration;
                }
            }
            else if (ConcealTimeRemaining > 0)
            {
                ConcealTimeRemaining -= Time.deltaTime;
                Conceal();
            }
            else
            {
                Unconceal();
            }
        }

        private void Conceal()
        {
            // If the local player is an impostor, we don't actually want to swoop them
            if (
                PlayerControl.LocalPlayer.Is(Faction.Impostors)
                || PlayerControl.LocalPlayer.Data.IsDead
                || CamouflageUnCamouflage.IsCamoed
                || Concealed == null
                || PlayerControl.LocalPlayer.PlayerId == Concealed.PlayerId
                )
            {
                return;
            }

            Utils.MakeInvisible(Concealed, false);
        }

        private void Unconceal()
        {
            LastConcealed = DateTime.UtcNow;
            if (Concealed != null)
            {
                Utils.MakeVisible(Concealed);
                Concealed = null;
            }
        }
    }
}
