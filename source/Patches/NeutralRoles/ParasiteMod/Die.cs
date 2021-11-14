using HarmonyLib;

namespace BetterTownOfUs.NeutralRoles.ParasiteMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Die))]
    public class Die
    {
        public static bool Prefix(PlayerControl __instance)
        {
            if (ParasiteShift.Parasitized == null) return true;
            __instance.Data.IsDead = true;
            PlayerControl parasite = null;
            
            foreach (var player in PlayerControl.AllPlayerControls)
                if (player.Is(RoleEnum.Parasite)) parasite = player;
            
            if (__instance == ParasiteShift.Parasitized && !parasite.Data.IsDead) ParasiteShift.ParasitizedDie(parasite, __instance);

            return true;
        }
    }
}