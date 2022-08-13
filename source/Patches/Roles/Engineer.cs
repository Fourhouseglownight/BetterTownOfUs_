using UnityEngine;
using TMPro;
using BetterTownOfUs.CrewmateRoles.EngineerMod;
namespace BetterTownOfUs.Roles
{
    public class Engineer : Role
    {
        public float EngiCooldown { get; set; }
        public float EngiFixPerRound { get; set; }
        public float EngiFixPerGame { get; set; }
        public TextMeshPro UsesText;
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            ImpostorText = () => "Maintain important systems on the ship";
            TaskText = () => "Vent and fix a sabotage from anywhere!";
            Color = Patches.Colors.Engineer;
            RoleType = RoleEnum.Engineer;
            EngiCooldown = CustomGameOptions.EngiCooldown;
            EngiFixPerRound = CustomGameOptions.EngineerFixPer  ==  EngineerFixPer.Custom ? CustomGameOptions.EngiFixPerRound : 1;
            EngiFixPerGame = CustomGameOptions.EngiFixPerGame;


            AddToRoleHistory(RoleType);
        }
        
    }
}