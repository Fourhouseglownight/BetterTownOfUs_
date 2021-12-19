using UnityEngine;
using BetterTownOfUs.NeutralRoles.ParasiteMod;

namespace BetterTownOfUs.Roles
{
    public class Parasite : Role
    {
        public Parasite(PlayerControl player) : base(player, RoleEnum.Parasite)
        {
            ImpostorText = () => "Steal badboy's role";
            TaskText = () => "Parasitize badboy who tries to kill you\nFake Tasks:";
        }

        public void Loses()
        {
            LostByRPC = true;
        }

        protected override void IntroPrefix(IntroCutscene._CoBegin_d__18 __instance)
        {
            var parasiteam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            parasiteam.Add(PlayerControl.LocalPlayer);
            __instance.yourTeam = parasiteam;
        }

        internal override bool Criteria()
        {
            if (ParasiteShift.Parasitized == null) return base.Criteria();
            if (PlayerControl.LocalPlayer == ParasiteShift.Parasitized) return true;
            if (CustomGameOptions.ImpostorsKnowTeam <= 1 && PlayerControl.LocalPlayer.Is(Faction.Impostors) && ParasiteShift.Parasitized.Is(Faction.Impostors)) return true;
            return base.Criteria();
        }
    }
}