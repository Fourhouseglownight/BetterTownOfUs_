using Il2CppSystem.Collections.Generic;
using Reactor;
using UnityEngine;
using BetterTownOfUs.Extensions;
using BetterTownOfUs.Roles;
using BetterTownOfUs.Roles.Modifiers;
using BetterTownOfUs.ImpostorRoles.UnderdogMod;

namespace BetterTownOfUs.NeutralRoles.ParasiteMod
{
    public class ParasiteShift
    {
        public static PlayerControl Parasitized;
        
        public static void Parasitize(PlayerControl parasite, PlayerControl parasitized)
        {
            Parasite parasiteRole = Role.GetRole<Parasite>(parasite);
            Role parasitizedRole = Role.GetRole(parasitized);
            Parasitized = parasitized;
            
            if (PlayerControl.LocalPlayer == parasite || PlayerControl.LocalPlayer == parasitized)
            {
                Coroutines.Start(Utils.FlashCoroutine(parasiteRole.Color));

                if (PlayerControl.LocalPlayer == parasitized)
                {
                    ImportantTextTask parasiteText = new GameObject("_Player").AddComponent<ImportantTextTask>();
                    parasiteText.transform.SetParent(PlayerControl.LocalPlayer.transform, false);
                    parasiteText.Text =$"{parasiteRole.ColorString}You are parasitized by {parasite.name} stay alive or he will steal your role and you will lose</color>";
                    parasiteText.Index = parasitized.PlayerId;
                    parasitized.myTasks.Insert(0, parasiteText);

                    if (parasitizedRole.Faction == Faction.Impostors)
                    {
                        RoleEnum role = Utils.GetRole(parasitized);
                        if (role == RoleEnum.Underdog) parasitized.SetKillTimer(PlayerControl.GameOptions.KillCooldown * (PerformKill.LastImp() ? 0.5f : 1.5f));
                        else parasitized.SetKillTimer(PlayerControl.GameOptions.KillCooldown);        
                    }
                    else parasitized.SetKillTimer(CustomGameOptions.GlitchKillCooldown);
                }
                else parasite.myTasks.ToArray()[0].Cast<ImportantTextTask>().Text = $"{parasiteRole.ColorString}Role: Parasite\nYou parasitize {parasitized.name} you will steal his role when he dies\nFake Tasks:</color>";
            }
        }

        public static void ParasitizedDie(PlayerControl parasite, PlayerControl parasitized)
        {
            Role parasitizedRole = Role.GetRole(parasitized);
            Role parasiteRole = Role.GetRole(parasite);
            parasiteRole.Player = parasitized;
            parasitizedRole.Player = parasite;
            Role.RoleDictionary.Remove(parasite.PlayerId);
            Role.RoleDictionary.Remove(parasitized.PlayerId);
            Role.RoleDictionary.Add(parasite.PlayerId, parasitizedRole);
            Role.RoleDictionary.Add(parasitized.PlayerId, parasiteRole);
            
            Modifier modifier = Modifier.GetModifier(parasitized);
            Modifier modifier2 = Modifier.GetModifier(parasite);
            if (modifier != null && modifier2 != null)
            {
                modifier.Player = parasite;
                modifier2.Player = parasitized;
                Modifier.ModifierDictionary.Remove(parasitized.PlayerId);
                Modifier.ModifierDictionary.Remove(parasite.PlayerId);
                Modifier.ModifierDictionary.Add(parasite.PlayerId, modifier);
                Modifier.ModifierDictionary.Add(parasitized.PlayerId, modifier2);
            }
            else if (modifier2 != null)
            {
                modifier2.Player = parasitized;
                Modifier.ModifierDictionary.Remove(parasite.PlayerId);
                Modifier.ModifierDictionary.Add(parasitized.PlayerId, modifier2);
            }
            else if (modifier != null)
            {
                modifier.Player = parasite;
                Modifier.ModifierDictionary.Remove(parasitized.PlayerId);
                Modifier.ModifierDictionary.Add(parasite.PlayerId, modifier);
            }

            if (Assassin.IsAssassin(parasitized))
            {
                Modifier assassin = Modifier.GetModifier(parasitized);
                assassin.Player = parasite;
                Assassin.AssassinsDictionary.Remove(parasitized.PlayerId);
                Assassin.AssassinsDictionary.Add(parasite.PlayerId, assassin);

                /*if (MeetingHud.Instance)
                {
                    Assassin newGuesser = Assassin.GetAssassin<Assassin>(parasite);
                    foreach (var voteArea in MeetingHud.Instance.playerStates)
                    {
                        IMeetingGuesser.GenButton(newGuesser, voteArea, playerControl => !AddButton.IsExempt(playerControl), (playerControl, modifier) =>
                        {
                            IMeetingGuesser.KillFromMeetingGuess(newGuesser, playerControl, modifier);
                            newGuesser.RemainingKills--;
                        });
                    }                
                }*/
            }

            List<PlayerTask> tasks = parasitized.myTasks;
            List<GameData.TaskInfo> taskinfos = parasitized.Data.Tasks;
            List<PlayerTask> tasks2 = parasite.myTasks;
            List<GameData.TaskInfo> taskinfos2 = parasite.Data.Tasks;

            parasite.myTasks = tasks;
            parasite.Data.Tasks = taskinfos;
            parasitized.myTasks = tasks2;
            parasitized.Data.Tasks = taskinfos2;
            parasitized.myTasks.ToArray()[0].Cast<ImportantTextTask>().Text = $"{parasiteRole.ColorString}Role: Parasite\nYou are a dead parasitized, you have lost\nFake Tasks:</color>";

            if (parasitizedRole.Faction == Faction.Impostors)
            {
                parasite.Data.SetImpostor(true);
                parasitized.Data.SetImpostor(false);
                RoleEnum role = Utils.GetRole(parasitized);
                
                if (role == RoleEnum.LoverImpostor)
                {
                    Lover lover = Role.GetRole<Lover>(parasite);
                    Lover otherLover = lover.OtherLover;
                    otherLover.RegenTask();
                }

                if (role == RoleEnum.Underdog) parasite.SetKillTimer(PlayerControl.GameOptions.KillCooldown * (PerformKill.LastImp() ? 0.5f : 1.5f));
                else parasite.SetKillTimer(PlayerControl.GameOptions.KillCooldown);        
            }
            else parasite.SetKillTimer(CustomGameOptions.GlitchKillCooldown);
            Parasitized = null;
        }
    }
}