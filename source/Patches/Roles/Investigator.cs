using System.Collections.Generic;
using BetterTownOfUs.CrewmateRoles.InvestigatorMod;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Investigator : Role
    {
        public readonly List<Footprint> AllPrints = new List<Footprint>();


        public Investigator(PlayerControl player) : base(player, RoleEnum.Investigator)
        {
            ImpostorText = () => "Find all imposters by examining footprints";
            TaskText = () => "You can see everyone's footprints.";
        }
    }
}
