using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Spy : Role
    {
        public Spy(PlayerControl player) : base(player, RoleEnum.Spy)
        {
            ImpostorText = () => "Snoop around and find stuff out";
            TaskText = () => "Spy on people and find the Impostors";
        }
    }
}
