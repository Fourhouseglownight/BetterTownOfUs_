using UnityEngine;
using BetterTownOfUs.NeutralRoles.ParasiteMod;

namespace BetterTownOfUs.Roles
{
    public class Parasite : Role
    {
        public Parasite(PlayerControl player) : base(player)
        {
            Name = "Parasite";
            ImpostorText = () => "Steal badboy's role";
            TaskText = () => "Parasitize badboy who tries to kill you\nFake Tasks:";
            Color = new Color(0.71f, 0.50f, 0.04f, 1f);
            RoleType = RoleEnum.Parasite;
            Faction = Faction.Neutral;
        }

        public void Loses()
        {
            Player.Data.IsImpostor = true;
        }

        protected override void IntroPrefix(IntroCutscene._CoBegin_d__14 __instance)
        {
            var parasiteam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            parasiteam.Add(PlayerControl.LocalPlayer);
            __instance.yourTeam = parasiteam;
        }

        internal override bool Criteria()
        {
            if (ParasiteShift.Parasitized == null) return base.Criteria();
            if (PlayerControl.LocalPlayer == ParasiteShift.Parasitized) return true;
            if (CustomGameOptions.ImpostorsKnowTeam <= 1 && PlayerControl.LocalPlayer.Data.IsImpostor && ParasiteShift.Parasitized.Data.IsImpostor) return true;
            return base.Criteria();
        }
    }
}