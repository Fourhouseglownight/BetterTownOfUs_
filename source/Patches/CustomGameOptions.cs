using BetterTownOfUs.CrewmateRoles.EngineerMod;
using BetterTownOfUs.CrewmateRoles.MedicMod;
using BetterTownOfUs.CrewmateRoles.SeerMod;
using BetterTownOfUs.CustomOption;
using BetterTownOfUs.NeutralRoles.ExecutionerMod;
using BetterTownOfUs.NeutralRoles.ShifterMod;
using BetterTownOfUs.CrewmateRoles.HaunterMod;
using System.Collections.Generic;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs
{
    public static class CustomGameOptions
    {
        public static int MayorOn => (int) Generate.MayorOn.Get();
        public static int JesterOn => (int) Generate.JesterOn.Get();
        public static int LoversOn => (int) Generate.LoversOn.Get();
        public static int SheriffOn => (int) Generate.SheriffOn.Get();
        public static int JanitorOn => (int) Generate.JanitorOn.Get();
        public static int EngineerOn => (int) Generate.EngineerOn.Get();
        public static int SwapperOn => (int) Generate.SwapperOn.Get();
        public static int ShifterOn => (int) Generate.ShifterOn.Get();
        public static int ParasiteOn => (int) Generate.ParasiteOn.Get();
        public static int InvestigatorOn => (int) Generate.InvestigatorOn.Get();
        public static int TimeLordOn => (int) Generate.TimeLordOn.Get();
        public static int MedicOn => (int) Generate.MedicOn.Get();
        public static int SeerOn => (int) Generate.SeerOn.Get();
        public static int RetributionistOn => (int) Generate.RetributionistOn.Get();
        public static int HaunterOn => (int) Generate.HaunterOn.Get();
        public static int GlitchOn => (int) Generate.GlitchOn.Get();
        public static int MorphlingOn => (int) Generate.MorphlingOn.Get();
        public static int CamouflagerOn => (int) Generate.CamouflagerOn.Get();
        public static int ExecutionerOn => (int) Generate.ExecutionerOn.Get();
        public static int MentalistOn => (int) Generate.MentalistOn.Get();
        public static int SpyOn => (int) Generate.SpyOn.Get();
        public static int SnitchOn => (int) Generate.SnitchOn.Get();
        public static int MinerOn => (int) Generate.MinerOn.Get();
        public static int SwooperOn => (int) Generate.SwooperOn.Get();
        public static int ArsonistOn => (int) Generate.ArsonistOn.Get();
        public static int CannibalOn => (int) Generate.CannibalOn.Get();
        public static int AltruistOn => (int) Generate.AltruistOn.Get();
        public static int ProphetOn => (int) Generate.ProphetOn.Get();
        public static int CovertOn => (int) Generate.CovertOn.Get();
        public static int UndertakerOn => (int) Generate.UndertakerOn.Get();
        public static int AssassinOn => (int) Generate.AssassinOn.Get();
        public static int UnderdogOn => (int) Generate.UnderdogOn.Get();
        public static int LycanOn => (int) Generate.LycanOn.Get();
        public static int TeleporterOn => (int) Generate.TeleporterOn.Get();
        public static int ConcealerOn => (int) Generate.ConcealerOn.Get();
        public static int GrenadierOn => (int) Generate.GrenadierOn.Get();
        public static int PhantomOn => (int) Generate.PhantomOn.Get();
        public static int TorchOn => (int) Generate.TorchOn.Get();
        public static int DiseasedOn => (int) Generate.DiseasedOn.Get();
        public static int FlashOn => (int) Generate.FlashOn.Get();
        public static int TiebreakerOn => (int) Generate.TiebreakerOn.Get();
        public static int DrunkOn => (int) Generate.DrunkOn.Get();
        public static int BigBoiOn => (int) Generate.BigBoiOn.Get();
        public static int ButtonBarryOn => (int) Generate.ButtonBarryOn.Get();
        public static int AnthropomancerOn => (int) Generate.AnthropomancerOn.Get();
        public static int CarnivoreOn => (int) Generate.CarnivoreOn.Get();
        public static bool GuesserKillNoRole => Generate.GuesserKillNoRole.Get();
        public static bool CanGuessNeutrals => Generate.CanGuessNeutrals.Get();
        public static int VanillaGame => (int) Generate.VanillaGame.Get();
        public static bool BothLoversDie => Generate.BothLoversDie.Get();
        public static bool LoverKill => Generate.LoverKill.Get();
        public static bool VotedLover => Generate.VotedLover.Get();
        public static int LovingImpostorOn => (int) Generate.LovingImpostorOn.Get();
        public static bool ShowSheriff => Generate.ShowSheriff.Get();
        public static bool SheriffKillOther => Generate.SheriffKillOther.Get();
        public static bool SheriffKillsJester => Generate.SheriffKillsJester.Get();
        public static bool SheriffKillsShifter => Generate.SheriffKillsShifter.Get();
        public static bool SheriffKillsParasite => Generate.SheriffKillsParasite.Get();
        public static bool SheriffKillsGlitch => Generate.SheriffKillsGlitch.Get();
        public static bool SheriffKillsExecutioner => Generate.SheriffKillsExecutioner.Get();
        public static bool SheriffKillsMentalist => Generate.SheriffKillsMentalist.Get();
        public static bool SheriffKillsArsonist => Generate.SheriffKillsArsonist.Get();
        public static bool SheriffKillsCannibal => Generate.SheriffKillsCannibal.Get();
        public static float SheriffKillCd => Generate.SheriffKillCd.Get();
        public static int MayorVoteBank => (int) Generate.MayorVoteBank.Get();
        public static bool MayorAnonymous => Generate.MayorAnonymous.Get();
        public static bool MayorButton => Generate.MayorButton.Get();
        public static bool SwapperButton => Generate.SwapperButton.Get();
        public static float ShifterCd => Generate.ShifterCd.Get();
        public static ShiftEnum WhoShifts => (ShiftEnum) Generate.WhoShifts.Get();
        public static bool ShifterSuicide => Generate.ShifterSuicide.Get();
        public static bool ShifterCrewmate => Generate.ShifterCrewmate.Get();
        public static bool ParasiteKill => Generate.ParasiteKill.Get();
        public static float FootprintSize => Generate.FootprintSize.Get();
        public static float FootprintInterval => Generate.FootprintInterval.Get();
        public static float FootprintDuration => Generate.FootprintDuration.Get();
        public static bool AnonymousFootPrint => Generate.AnonymousFootPrint.Get();
        public static bool VentFootprintVisible => Generate.VentFootprintVisible.Get();

        public static bool RewindRevive => Generate.RewindRevive.Get();
        public static float RewindDuration => Generate.RewindDuration.Get();
        public static float RewindCooldown => Generate.RewindCooldown.Get();
        public static bool TimeLordVitals => Generate.TimeLordVitals.Get();
        public static ShieldOptions ShowShielded => (ShieldOptions) Generate.ShowShielded.Get();

        public static NotificationOptions NotificationShield =>
            (NotificationOptions) Generate.WhoGetsNotification.Get();

        public static bool ShieldBreaks => Generate.ShieldBreaks.Get();
        public static float MedicReportNameDuration => Generate.MedicReportNameDuration.Get();
        public static float MedicReportColorDuration => Generate.MedicReportColorDuration.Get();
        public static bool ShowReports => Generate.MedicReportSwitch.Get();
        public static float SeerCd => Generate.SeerCooldown.Get();
        public static SeerInfo SeerInfo => (SeerInfo) Generate.SeerInfo.Get();
        public static SeeReveal SeeReveal => (SeeReveal) Generate.SeeReveal.Get();
        public static float SeerCrewmateChance => Generate.SeerCrewmateChance.Get();
        public static float SeerNeutralChance => Generate.SeerNeutralChance.Get();
        public static float SeerImpostorChance => Generate.SeerImpostorChance.Get();
        public static float ProphetCooldown => Generate.ProphetCooldown.Get();
        public static bool ProphetInitialReveal => Generate.ProphetInitialReveal.Get();
        public static float CovertCooldown => Generate.CovertCooldown.Get();
        public static float CovertDuration => Generate.CovertDuration.Get();
        public static bool NeutralRed => Generate.NeutralRed.Get();
        public static int HaunterTasksRemainingClicked => (int)Generate.HaunterTasksRemainingClicked.Get();
        public static int HaunterTasksRemainingAlert => (int)Generate.HaunterTasksRemainingAlert.Get();
        public static bool HaunterRevealsNeutrals => Generate.HaunterRevealsNeutrals.Get();
        public static HaunterCanBeClickedBy HaunterCanBeClickedBy => (HaunterCanBeClickedBy) Generate.HaunterCanBeClickedBy.Get();
        public static bool JesterVent => Generate.JesterVent.Get();
        public static bool JesterButton => Generate.JesterButton.Get();
        public static bool SGAfterVote => Generate.SGAfterVote.Get();
        public static int GuesserKills => (int)Generate.GuesserKills.Get();
        public static bool GuesserMultiKill => Generate.GuesserMultiKill.Get();
        public static bool GuesserMissKill => Generate.GuesserMissKill.Get();
        public static MissKillNotifEnum GuesserMissKillNotif => (MissKillNotifEnum) Generate.GuesserMissKillNotif.Get();
        public static bool KillVent => Generate.KillVent.Get();
        public static bool BetterPolus => Generate.BetterPolus.Get();
        public static bool PolusVents => Generate.PolusVents.Get();
        public static bool SwitchTask => Generate.SwitchTask.Get();
        public static float MimicCooldown => Generate.MimicCooldownOption.Get();
        public static float MimicDuration => Generate.MimicDurationOption.Get();
        public static float HackCooldown => Generate.HackCooldownOption.Get();
        public static float HackDuration => Generate.HackDurationOption.Get();
        public static float GlitchKillCooldown => Generate.GlitchKillCooldownOption.Get();
        public static bool GlitchVent => Generate.GlitchVent.Get();
        public static int GlitchHackDistance => Generate.GlitchHackDistanceOption.Get();
        public static float MorphlingCd => Generate.MorphlingCooldown.Get();
        public static float MorphlingDuration => Generate.MorphlingDuration.Get();
        public static bool MorphlingVent => Generate.MorphlingVent.Get();
        public static float CamouflagerCd => Generate.CamouflagerCooldown.Get();
        public static float CamouflagerDuration => Generate.CamouflagerDuration.Get();
        public static float InitialCooldowns => Generate.InitialCooldowns.Get();
        public static bool ColourblindComms => Generate.ColourblindComms.Get();
        public static bool MeetingColourblind => Generate.MeetingColourblind.Get();
        public static OnTargetDead OnTargetDead => (OnTargetDead) Generate.OnTargetDead.Get();
        public static bool ExecutionerButton => Generate.ExecutionerButton.Get();
        public static int GuessNeed => (int) Generate.GuessNeed.Get();
        public static bool MentalistButton => Generate.MentalistButton.Get();
        public static bool SnitchOnLaunch => Generate.SnitchOnLaunch.Get();
        public static bool SnitchSeesNeutrals => Generate.SnitchSeesNeutrals.Get();
        public static bool SnitchSeesInMeetings => Generate.SnitchSeesInMeetings.Get();
        public static int SnitchTasksRemaining => (int)Generate.SnitchTasksRemaining.Get();
        public static bool SnitchSeesImpInMeeting => Generate.SnitchSeesImpInMeeting.Get();
        public static float MineCd => Generate.MineCooldown.Get();
        public static float SwoopCd => Generate.SwoopCooldown.Get();
        public static float SwoopDuration => Generate.SwoopDuration.Get();
        public static bool SwooperVent => Generate.SwooperVent.Get();
        public static int ImpostorsKnowTeam => (int) Generate.ImpostorsKnowTeam.Get();
        public static bool DeadSeeRoles => Generate.DeadSeeRoles.Get();
        public static float DouseCd => Generate.DouseCooldown.Get();
        public static bool ArsonistGameEnd => Generate.ArsonistGameEnd.Get();
        public static bool ArsonistButton => Generate.ArsonistButton.Get();
        public static float CannibalCd => Generate.CannibalCd.Get();
        public static int EatNeed => (int) Generate.EatNeed.Get();
        public static int PhantomTasksRemaining => (int)Generate.PhantomTasksRemaining.Get();
        public static int MaxImpostorRoles => (int) Generate.MaxImpostorRoles.Get();
        public static int MaxNeutralRoles => (int) Generate.MaxNeutralRoles.Get();
        public static int MaxAssassins => (int) Generate.MaxAssassins.Get();
        public static bool RoleUnderName => Generate.RoleUnderName.Get();
        public static Engineer.EngineerFixPer EngineerFixPer => (Engineer.EngineerFixPer) Generate.EngineerPer.Get();
        public static bool IsCdEngineer => Generate.IsEngineerCd.Get();
        public static float EngineerCd => Generate.EngineerCd.Get();
        public static int FixesPerRound => (int) Generate.FixesPerRound.Get();
        public static int FixesNumber => (int) Generate.FixesNumber.Get();
        public static float ReviveDuration => Generate.ReviveDuration.Get();
        public static bool AltruistTargetBody => Generate.AltruistTargetBody.Get();
        public static bool SheriffBodyReport => Generate.SheriffBodyReport.Get();
        public static float DragCd => Generate.DragCooldown.Get();
        public static bool UndertakerVent => Generate.UndertakerVent.Get();
        public static bool UndertakerVentWithBody => Generate.UndertakerVentWithBody.Get();
        public static float WolfCd => Generate.WolfCooldown.Get();
        public static float WolfDuration => Generate.WolfDuration.Get();
        public static bool LycanVent => Generate.LycanVent.Get();
        public static bool LycanWolfVent => Generate.LycanWolfVent.Get();
        public static float TeleporterCooldown => Generate.TeleporterCooldown.Get();
        public static bool TeleportSelf => Generate.TeleportSelf.Get();
        public static bool TeleportOccupiedVents => Generate.TeleportOccupiedVents.Get();
        public static float ConcealCooldown => Generate.ConcealCooldown.Get();
        public static float TimeToConceal => Generate.TimeToConceal.Get();
        public static float ConcealDuration => Generate.ConcealDuration.Get();
        public static bool GuessSnitchViaCrewmate => Generate.GuessSnitchViaCrewmate.Get();
        public static float UnderdogKillBonus => Generate.UnderdogKillBonus.Get();
        public static bool UnderdogIncreasedKC => Generate.UnderdogIncreasedKC.Get();
        public static float GrenadeCd => Generate.GrenadeCooldown.Get();
        public static float GrenadeDuration => Generate.GrenadeDuration.Get();
        public static bool GrenadierVent => Generate.GrenadierVent.Get();

        public static List<RoleEnum> GetEnabledRoles(params Faction[] factions)
        {
            bool On(int role) => role > 0;
            var enabledRoles = new List<RoleEnum>();
            foreach (Faction faction in factions)
            {
                if (faction == Faction.Crewmates)
                {
                    if (On(SheriffOn)) enabledRoles.Add(RoleEnum.Sheriff);
                    if (On(EngineerOn)) enabledRoles.Add(RoleEnum.Engineer);
                    if (On(LoversOn)) enabledRoles.Add(RoleEnum.Lover);
                    if (On(MayorOn)) enabledRoles.Add(RoleEnum.Mayor);
                    if (On(SwapperOn)) enabledRoles.Add(RoleEnum.Swapper);
                    if (On(InvestigatorOn)) enabledRoles.Add(RoleEnum.Investigator);
                    if (On(TimeLordOn)) enabledRoles.Add(RoleEnum.TimeLord);
                    if (On(MedicOn)) enabledRoles.Add(RoleEnum.Medic);
                    if (On(SeerOn)) enabledRoles.Add(RoleEnum.Seer);
                    if (On(SpyOn)) enabledRoles.Add(RoleEnum.Spy);
                    if (On(SnitchOn)) enabledRoles.Add(RoleEnum.Snitch);
                    if (On(AltruistOn)) enabledRoles.Add(RoleEnum.Altruist);
                    if (On(ProphetOn)) enabledRoles.Add(RoleEnum.Prophet);
                    if (On(CovertOn)) enabledRoles.Add(RoleEnum.Covert);
                    if (On(RetributionistOn)) enabledRoles.Add(RoleEnum.Retributionist);
                    if (On(HaunterOn)) enabledRoles.Add(RoleEnum.Haunter);
                }
                else if (faction == Faction.Neutral)
                {
                    if (On(JesterOn)) enabledRoles.Add(RoleEnum.Jester);
                    if (On(ShifterOn)) enabledRoles.Add(RoleEnum.Shifter);
                    if (On(ParasiteOn)) enabledRoles.Add(RoleEnum.Parasite);
                    if (On(ExecutionerOn)) enabledRoles.Add(RoleEnum.Executioner);
                    if (On(MentalistOn)) enabledRoles.Add(RoleEnum.Mentalist);
                    if (On(ArsonistOn)) enabledRoles.Add(RoleEnum.Arsonist);
                    if (On(CannibalOn)) enabledRoles.Add(RoleEnum.Cannibal);
                    if (On(GlitchOn)) enabledRoles.Add(RoleEnum.Glitch);
                }
                else if (faction == Faction.Impostors)
                {
                    if (On(LoversOn) && On(LovingImpostorOn)) enabledRoles.Add(RoleEnum.LoverImpostor);
                    if (On(MinerOn)) enabledRoles.Add(RoleEnum.Miner);
                    if (On(SwooperOn)) enabledRoles.Add(RoleEnum.Swooper);
                    if (On(MorphlingOn)) enabledRoles.Add(RoleEnum.Morphling);
                    if (On(CamouflagerOn)) enabledRoles.Add(RoleEnum.Camouflager);
                    if (On(JanitorOn)) enabledRoles.Add(RoleEnum.Janitor);
                    if (On(UndertakerOn)) enabledRoles.Add(RoleEnum.Undertaker);
                    if (On(UnderdogOn)) enabledRoles.Add(RoleEnum.Underdog);
                    if (On(LycanOn)) enabledRoles.Add(RoleEnum.Lycan);
                    if (On(TeleporterOn)) enabledRoles.Add(RoleEnum.Teleporter);
                    if (On(ConcealerOn)) enabledRoles.Add(RoleEnum.Concealer);
                    if (On(GrenadierOn)) enabledRoles.Add(RoleEnum.Grenadier);
                }
            }

            return enabledRoles;
        }
    }
}
