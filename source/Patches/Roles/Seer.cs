using System;
using System.Collections.Generic;
using BetterTownOfUs.Extensions;
using BetterTownOfUs.CrewmateRoles.SeerMod;

namespace BetterTownOfUs.Roles
{
    public class Seer : Role
    {
        public readonly Dictionary<byte, bool> Investigated = new Dictionary<byte, bool>();

        public Seer(PlayerControl player) : base(player)
        {
            Name = "Seer";
            ImpostorText = () => "Investigate roles";
            TaskText = () => "Investigate roles and find the Impostor";
            Color = Patches.Colors.Seer;
            LastInvestigated = DateTime.UtcNow;
            RoleType = RoleEnum.Seer;
            AddToRoleHistory(RoleType);
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastInvestigated { get; set; }

        public float SeerTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastInvestigated;
            var num = CustomGameOptions.SeerCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public bool CheckSeeReveal(PlayerControl player)
        {
            var role = GetRole(player);
            switch (CustomGameOptions.SeeReveal)
            {
                case SeeReveal.All:
                    return true;
                case SeeReveal.Nobody:
                    return false;
                case SeeReveal.ImpsAndNeut:
                    return role != null && role.Faction != Faction.Crewmates || player.Data.IsImpostor();
                case SeeReveal.Crew:
                    return role != null && role.Faction == Faction.Crewmates || !player.Data.IsImpostor();
            }

            return false;
        }

        internal override bool Criteria()
        {
            foreach (var player in Investigated)
            {
                if (!player.Value) return base.Criteria();
                var role = Role.GetRole(Utils.PlayerById(player.Key));
                switch (role.Faction)
                {
                    case Faction.Crewmates:
                        if (CustomGameOptions.SeeReveal == SeeReveal.All || CustomGameOptions.SeeReveal == SeeReveal.Crew) return true;
                        break;
                    case Faction.Neutral:
                    case Faction.Impostors:
                        if (CustomGameOptions.SeeReveal == SeeReveal.All || CustomGameOptions.SeeReveal == SeeReveal.ImpsAndNeut) return true;
                        break;
                }
                return base.Criteria();
            }
            return base.Criteria();
        }
    }
}