using BetterTownOfUs.Patches;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs
{
    public enum RoleEnum
    {
        [RoleDetails("Mayor", "#704FA8FF", Faction.Crewmates)]
        Mayor,
        [RoleDetails("Lover", "#FF66CCFF", Faction.Crewmates)]
        Lover,
        [RoleDetails("Sheriff", "#FFFF00FF", Faction.Crewmates)]
        Sheriff,
        [RoleDetails("Engineer", "#FFA60AFF", Faction.Crewmates)]
        Engineer,
        [RoleDetails("Swapper", "#66E666FF", Faction.Crewmates)]
        Swapper,
        [RoleDetails("Investigator", "#00B3B3FF", Faction.Crewmates)]
        Investigator,
        [RoleDetails("Time Lord", "#0000FFFF", Faction.Crewmates)]
        TimeLord,
        [RoleDetails("Medic", "#006600FF", Faction.Crewmates)]
        Medic,
        [RoleDetails("Seer", "#FFCC80FF", Faction.Crewmates)]
        Seer,
        [RoleDetails("Spy", "#CCA3CCFF", Faction.Crewmates)]
        Spy,
        [RoleDetails("Snitch", "#D4AF37FF", Faction.Crewmates)]
        Snitch,
        [RoleDetails("Altruist", "#660000FF", Faction.Crewmates)]
        Altruist,
        [RoleDetails("Prophet", "#B026FF", Faction.Crewmates)]
        Prophet,
        [RoleDetails("Covert", "#7B7F1A", Faction.Crewmates)]
        Covert,
        [RoleDetails("Retributionist", "#CCFF00", Faction.Crewmates)]
        Retributionist,
        [RoleDetails("Haunter", "#D3D3D3", Faction.Crewmates)]
        Haunter,

        [RoleDetails("Jester", "#FFBFCCFF", Faction.Neutral)]
        Jester,
        [RoleDetails("Shifter", "#999999FF", Faction.Neutral)]
        Shifter,
        [RoleDetails("Parasite", "#473204FF", Faction.Neutral)]
        Parasite,
        [RoleDetails("The Glitch", "#00FF00FF", Faction.Neutral)]
        Glitch,
        [RoleDetails("Executioner", "#8C4005FF", Faction.Neutral)]
        Executioner,
        [RoleDetails("Mentalist", "#34eb71", Faction.Neutral)]
        Mentalist,
        [RoleDetails("Arsonist", "#FF4D00FF", Faction.Neutral)]
        Arsonist,
        [RoleDetails("Cannibal", "#1e300bFF", Faction.Neutral)]
        Cannibal,
        [RoleDetails("Phantom", "#662962", Faction.Neutral)]
        Phantom,

        [RoleDetails("Loving Impostor", "#FF0000FF", Faction.Impostors)]
        LoverImpostor,
        [RoleDetails("Miner", "#FF0000FF", Faction.Impostors)]
        Miner,
        [RoleDetails("Swooper", "#FF0000FF", Faction.Impostors)]
        Swooper,
        [RoleDetails("Morphling", "#FF0000FF", Faction.Impostors)]
        Morphling,
        [RoleDetails("Camouflager", "#FF0000FF", Faction.Impostors)]
        Camouflager,
        [RoleDetails("Janitor", "#FF0000FF", Faction.Impostors)]
        Janitor,
        [RoleDetails("Undertaker", "#FF0000FF", Faction.Impostors)]
        Undertaker,
        [RoleDetails("Underdog", "#FF0000FF", Faction.Impostors)]
        Underdog,
        [RoleDetails("Lycan", "#FF0000FF", Faction.Impostors)]
        Lycan,
        [RoleDetails("Teleporter", "#FF0000FF", Faction.Impostors)]
        Teleporter,
        [RoleDetails("Concealer", "#FF0000FF", Faction.Impostors)]
        Concealer,
        [RoleDetails("Grenadier", "#FF0000FF", Faction.Impostors)]
        Grenadier,


        [RoleDetails("Crewmate", "#FFFFFFFF", Faction.Crewmates)]
        Crewmate,
        [RoleDetails("Impostor", "#FF0000FF", Faction.Impostors)]
        Impostor,
        None
    }

    public enum ModifierEnum
    {
        Assassin,
        Torch,
        Diseased,
        Flash,
        Tiebreaker,
        Drunk,
        BigBoi,
        ButtonBarry,
        Anthropomancer,
        Carnivore,
    }
}
