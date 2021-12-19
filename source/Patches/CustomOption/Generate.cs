using System;
using System.Diagnostics.CodeAnalysis;
using BetterTownOfUs.Patches;
using UnityEngine.UIElements;

namespace BetterTownOfUs.CustomOption
{
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class Generate
    {
        private static CustomHeaderOption CrewmateRoles;
        public static CustomNumberOption MayorOn;
        public static CustomNumberOption LoversOn;
        public static CustomNumberOption SheriffOn;
        public static CustomNumberOption EngineerOn;
        public static CustomNumberOption SwapperOn;
        public static CustomNumberOption InvestigatorOn;
        public static CustomNumberOption TimeLordOn;
        public static CustomNumberOption MedicOn;
        public static CustomNumberOption SeerOn;
        public static CustomNumberOption SpyOn;
        public static CustomNumberOption SnitchOn;
        public static CustomNumberOption AltruistOn;
        public static CustomNumberOption ProphetOn;
        public static CustomNumberOption CovertOn;
        public static CustomNumberOption RetributionistOn;
        public static CustomNumberOption HaunterOn;


        private static CustomHeaderOption NeutralRoles;
        public static CustomNumberOption JesterOn;
        public static CustomNumberOption ShifterOn;
        public static CustomNumberOption ParasiteOn;
        public static CustomNumberOption GlitchOn;
        public static CustomNumberOption ExecutionerOn;
        public static CustomNumberOption MentalistOn;
        public static CustomNumberOption ArsonistOn;
        public static CustomNumberOption CannibalOn;
        public static CustomNumberOption PhantomOn;

        private static CustomHeaderOption ImpostorRoles;
        public static CustomNumberOption JanitorOn;
        public static CustomNumberOption MorphlingOn;
        public static CustomNumberOption CamouflagerOn;
        public static CustomNumberOption MinerOn;
        public static CustomNumberOption SwooperOn;
        public static CustomNumberOption UndertakerOn;
        public static CustomNumberOption AssassinOn;
        public static CustomNumberOption UnderdogOn;
        public static CustomNumberOption LycanOn;
        public static CustomNumberOption TeleporterOn;
        public static CustomNumberOption ConcealerOn;
        public static CustomNumberOption GrenadierOn;


        private static CustomHeaderOption Modifiers;
        public static CustomNumberOption TorchOn;
        public static CustomNumberOption DiseasedOn;
        public static CustomNumberOption FlashOn;
        public static CustomNumberOption TiebreakerOn;
        public static CustomNumberOption DrunkOn;
        public static CustomNumberOption BigBoiOn;
        public static CustomNumberOption ButtonBarryOn;
        public static CustomNumberOption AnthropomancerOn;
        public static CustomNumberOption CarnivoreOn;


        private static CustomHeaderOption CustomGameSettings;
        public static CustomHeaderOption Polus;
        public static CustomToggleOption BetterPolus;
        public static CustomToggleOption SwitchTask;
        public static CustomToggleOption PolusVents;
        public static CustomNumberOption InitialCooldowns;
        public static CustomToggleOption ColourblindComms;
        public static CustomToggleOption MeetingColourblind;
        public static CustomToggleOption SGAfterVote;
        public static CustomToggleOption KillVent;
        public static CustomStringOption ImpostorsKnowTeam;
        public static CustomToggleOption DeadSeeRoles;
        public static CustomNumberOption MaxImpostorRoles;
        public static CustomNumberOption MaxNeutralRoles;
        public static CustomToggleOption RoleUnderName;
        public static CustomHeaderOption Guesser;
        public static CustomNumberOption GuesserKills;
        public static CustomToggleOption GuesserMultiKill;
        public static CustomToggleOption GuesserKillNoRole;
        public static CustomToggleOption CanGuessNeutrals;
        public static CustomToggleOption GuessSnitchViaCrewmate;
        public static CustomToggleOption GuesserMissKill;
        public static CustomStringOption GuesserMissKillNotif;
        public static CustomNumberOption MaxAssassins;

        public static CustomNumberOption VanillaGame;

        private static CustomHeaderOption Mayor;
        public static CustomNumberOption MayorVoteBank;
        public static CustomToggleOption MayorAnonymous;
        public static CustomToggleOption MayorButton;

        private static CustomHeaderOption Lovers;
        public static CustomToggleOption BothLoversDie;
        public static CustomNumberOption LovingImpostorOn;
        public static CustomToggleOption LoverKill;
        public static CustomToggleOption VotedLover;

        private static CustomHeaderOption Sheriff;
        public static CustomToggleOption ShowSheriff;
        public static CustomToggleOption SheriffKillOther;
        public static CustomToggleOption SheriffKillsJester;
        public static CustomToggleOption SheriffKillsShifter;
        public static CustomToggleOption SheriffKillsParasite;
        public static CustomToggleOption SheriffKillsGlitch;
        public static CustomToggleOption SheriffKillsExecutioner;
        public static CustomToggleOption SheriffKillsMentalist;
        public static CustomToggleOption SheriffKillsArsonist;
        public static CustomToggleOption SheriffKillsCannibal;
        public static CustomNumberOption SheriffKillCd;
        public static CustomToggleOption SheriffBodyReport;

        private static CustomHeaderOption Shifter;
        public static CustomNumberOption ShifterCd;
        public static CustomStringOption WhoShifts;
        public static CustomToggleOption ShifterSuicide;
        public static CustomStringOption ShiftedBecomes;
        public static CustomToggleOption ShifterCrewmate;

        private static CustomHeaderOption Parasite;
        public static CustomToggleOption ParasiteKill;

        private static CustomHeaderOption Engineer;
        public static CustomStringOption EngineerPer;
        public static CustomToggleOption IsEngineerCd;
        public static CustomNumberOption EngineerCd;
        public static CustomNumberOption FixesPerRound;
        public static CustomNumberOption FixesNumber;

        private static CustomHeaderOption Investigator;
        public static CustomNumberOption FootprintSize;
        public static CustomNumberOption FootprintInterval;
        public static CustomNumberOption FootprintDuration;
        public static CustomToggleOption AnonymousFootPrint;
        public static CustomToggleOption VentFootprintVisible;

        private static CustomHeaderOption TimeLord;
        public static CustomToggleOption RewindRevive;
        public static CustomNumberOption RewindDuration;
        public static CustomNumberOption RewindCooldown;
        public static CustomToggleOption TimeLordVitals;

        private static CustomHeaderOption Medic;
        public static CustomStringOption ShowShielded;
        public static CustomToggleOption MedicReportSwitch;
        public static CustomNumberOption MedicReportNameDuration;
        public static CustomNumberOption MedicReportColorDuration;
        public static CustomStringOption WhoGetsNotification;
        public static CustomToggleOption ShieldBreaks;

        private static CustomHeaderOption Seer;
        public static CustomNumberOption SeerCooldown;
        public static CustomStringOption SeerInfo;
        public static CustomStringOption SeeReveal;
        public static CustomToggleOption NeutralRed;
        public static CustomNumberOption SeerCrewmateChance;
        public static CustomNumberOption SeerNeutralChance;
        public static CustomNumberOption SeerImpostorChance;

        private static CustomHeaderOption Snitch;
        public static CustomToggleOption SnitchOnLaunch;
        public static CustomToggleOption SnitchSeesNeutrals;
        public static CustomToggleOption SnitchSeesInMeetings;
        public static CustomNumberOption SnitchTasksRemaining;
        public static CustomToggleOption SnitchSeesImpInMeeting;

        private static CustomHeaderOption Altruist;
        public static CustomNumberOption ReviveDuration;
        public static CustomToggleOption AltruistTargetBody;

        private static CustomHeaderOption Prophet;
        public static CustomNumberOption ProphetCooldown;
        public static CustomToggleOption ProphetInitialReveal;

        private static CustomHeaderOption Covert;
        public static CustomNumberOption CovertCooldown;
        public static CustomNumberOption CovertDuration;

        public static CustomHeaderOption Swapper;
        public static CustomToggleOption SwapperButton;

        public static CustomHeaderOption Haunter;
        public static CustomNumberOption HaunterTasksRemainingClicked;
        public static CustomNumberOption HaunterTasksRemainingAlert;
        public static CustomToggleOption HaunterRevealsNeutrals;
        public static CustomStringOption HaunterCanBeClickedBy;

        public static CustomHeaderOption Jester;
        public static CustomToggleOption JesterVent;
        public static CustomToggleOption JesterButton;

        private static CustomHeaderOption TheGlitch;
        public static CustomNumberOption MimicCooldownOption;
        public static CustomNumberOption MimicDurationOption;
        public static CustomNumberOption HackCooldownOption;
        public static CustomNumberOption HackDurationOption;
        public static CustomNumberOption GlitchKillCooldownOption;
        public static CustomStringOption GlitchHackDistanceOption;
        public static CustomToggleOption GlitchVent;

        private static CustomHeaderOption Executioner;
        public static CustomStringOption OnTargetDead;
        public static CustomToggleOption ExecutionerButton;

        private static CustomHeaderOption Mentalist;
        public static CustomStringOption GuessNeed;
        public static CustomToggleOption MentalistButton;

        private static CustomHeaderOption Arsonist;
        public static CustomNumberOption DouseCooldown;
        public static CustomToggleOption ArsonistGameEnd;
        public static CustomToggleOption ArsonistButton;

        private static CustomHeaderOption Cannibal;
        public static CustomNumberOption CannibalCd;
        public static CustomStringOption EatNeed;

        public static CustomHeaderOption Phantom;
        public static CustomNumberOption PhantomTasksRemaining;

        private static CustomHeaderOption Camouflager;
        public static CustomNumberOption CamouflagerCooldown;
        public static CustomNumberOption CamouflagerDuration;

        private static CustomHeaderOption Morphling;
        public static CustomNumberOption MorphlingCooldown;
        public static CustomNumberOption MorphlingDuration;
        public static CustomToggleOption MorphlingVent;

        private static CustomHeaderOption Miner;
        public static CustomNumberOption MineCooldown;

        private static CustomHeaderOption Swooper;
        public static CustomNumberOption SwoopCooldown;
        public static CustomNumberOption SwoopDuration;
        public static CustomToggleOption SwooperVent;

        private static CustomHeaderOption Undertaker;
        public static CustomNumberOption DragCooldown;
        public static CustomToggleOption UndertakerVent;
        public static CustomToggleOption UndertakerVentWithBody;

        public static CustomHeaderOption Underdog;
        public static CustomNumberOption UnderdogKillBonus;
        public static CustomToggleOption UnderdogIncreasedKC;
        
        public static CustomHeaderOption Lycan;
        public static CustomNumberOption WolfCooldown;
        public static CustomNumberOption WolfDuration;
        public static CustomToggleOption LycanVent;
        public static CustomToggleOption LycanWolfVent;

        private static CustomHeaderOption Teleporter;
        public static CustomNumberOption TeleporterCooldown;
        public static CustomToggleOption TeleportSelf;
        public static CustomToggleOption TeleportOccupiedVents;

        private static CustomHeaderOption Concealer;
        public static CustomNumberOption ConcealCooldown;
        public static CustomNumberOption TimeToConceal;
        public static CustomNumberOption ConcealDuration;

        public static CustomHeaderOption Grenadier;
        public static CustomNumberOption GrenadeCooldown;
        public static CustomNumberOption GrenadeDuration;
        public static CustomToggleOption GrenadierVent;

        private static Func<object, string> PercentFormat { get; } = value => $"{value:0}%";
        private static Func<object, string> CooldownFormat { get; } = value => $"{value:0.0#}s";


        public static void GenerateAll()
        {
            var num = 0;

            Patches.ExportButton = new Export(num++);
            Patches.ImportButton = new Import(num++);


            #region Probabilities
            CrewmateRoles = new CustomHeaderOption(num++, "Crewmate Roles");
            MayorOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Mayor).GetColoredName()}", 100f, 0f, 100f, 10f,
                PercentFormat);
            LoversOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Lover).WrapTextInColor("Lovers")}", 20f, 0f, 100f, 10f,
                PercentFormat);
            SheriffOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Sheriff).GetColoredName()}", 100f, 0f, 100f, 10f,
                PercentFormat);
            EngineerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Engineer).GetColoredName()}", 100f, 0f, 100f, 10f,
                PercentFormat);
            SwapperOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Swapper).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            InvestigatorOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Investigator).GetColoredName()}", 0f, 0f, 100f,
                10f, PercentFormat);
            TimeLordOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.TimeLord).GetColoredName()}", 0f, 0f, 100f, 10f,
                PercentFormat);
            MedicOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Medic).GetColoredName()}", 100f, 0f, 100f, 10f,
                PercentFormat);
            SeerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Seer).GetColoredName()}", 20f, 0f, 100f, 10f,
                PercentFormat);
            SpyOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Spy).GetColoredName()}", 40f, 0f, 100f, 10f,
                PercentFormat);
            SnitchOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Snitch).GetColoredName()}", 40f, 0f, 100f, 10f,
                PercentFormat);
            AltruistOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Altruist).GetColoredName()}", 60f, 0f, 100f, 10f,
                PercentFormat);
            ProphetOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Prophet).GetColoredName()}", 20f, 0f, 100f, 10f,
                PercentFormat);
            CovertOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Covert).GetColoredName()}", 20f, 0f, 100f, 10f,
                PercentFormat);
            RetributionistOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Retributionist).GetColoredName()}", 60f, 0f, 100f, 10f,
                PercentFormat);
            HaunterOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Haunter).GetColoredName()}", 100f, 0f, 100f, 10f,
                PercentFormat);


            NeutralRoles = new CustomHeaderOption(num++, "Neutral Roles");
            JesterOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Jester).GetColoredName()}", 60f, 0f, 100f, 10f,
                PercentFormat);
            ShifterOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Shifter).GetColoredName()}", 40f, 0f, 100f, 10f,
                PercentFormat);
            ParasiteOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Parasite).GetColoredName()}", 40f, 0f, 100f, 10f,
                PercentFormat);
            GlitchOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Glitch).GetColoredName()}", 70f, 0f, 100f, 10f,
                PercentFormat);
            ExecutionerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Executioner).GetColoredName()}", 10f, 0f, 100f,
                10f, PercentFormat);
            MentalistOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Mentalist).GetColoredName()}", 40f, 0f, 100f,
                10f, PercentFormat);
            ArsonistOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Arsonist).GetColoredName()}", 40f, 0f, 100f, 10f,
                PercentFormat);
            CannibalOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Cannibal).GetColoredName()}", 40f, 0f, 100f, 10f,
                PercentFormat);
            PhantomOn = new CustomNumberOption(true, num++,
                $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Phantom).GetColoredName()}", 100f, 0f, 100f, 10f,
                PercentFormat);


            ImpostorRoles = new CustomHeaderOption(num++, "Impostor Roles");
            JanitorOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Janitor).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            MorphlingOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Morphling).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            CamouflagerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Camouflager).GetColoredName()}", 0f, 0f, 100f,
                10f, PercentFormat);
            MinerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Miner).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            SwooperOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Swooper).GetColoredName()}", 20f, 0f, 100f, 10f,
                PercentFormat);
            UndertakerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Undertaker).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            UnderdogOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Underdog).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            LycanOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Lycan).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            TeleporterOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Teleporter).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            ConcealerOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Concealer).GetColoredName()}", 50f, 0f, 100f, 10f,
                PercentFormat);
            GrenadierOn = new CustomNumberOption(true, num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Grenadier).GetColoredName()}", 0f, 0f, 100f, 10f,
                PercentFormat);


            Modifiers = new CustomHeaderOption(num++, "Modifiers");
            AssassinOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Assassin</color>", 100f, 0f, 100f, 10f,
                PercentFormat);
            TorchOn = new CustomNumberOption(true, num++, "<color=#FFFF99FF>Torch</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            DiseasedOn =
                new CustomNumberOption(true, num++, "<color=#808080FF>Diseased</color>", 20f, 0f, 100f, 10f,
                    PercentFormat);
            FlashOn = new CustomNumberOption(true, num++, "<color=#FF8080FF>Flash</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            TiebreakerOn = new CustomNumberOption(true, num++, "<color=#99E699FF>Tiebreaker</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            DrunkOn = new CustomNumberOption(true, num++, "<color=#758000FF>Drunk</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            BigBoiOn = new CustomNumberOption(true, num++, "<color=#FF8080FF>Giant</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            ButtonBarryOn =
                new CustomNumberOption(true, num++, "<color=#E600FFFF>Button Barry</color>", 20f, 0f, 100f, 10f,
                    PercentFormat);
            AnthropomancerOn =
                new CustomNumberOption(true, num++, "<color=#336629>Anthropomancer</color>", 20f, 0f, 100f, 10f,
                    PercentFormat);
            CarnivoreOn =
                new CustomNumberOption(true, num++, "<color=#640000>Carnivore</color>", 20f, 0f, 100f, 10f, PercentFormat);
            #endregion


            #region GameSettings    
            Polus = new CustomHeaderOption(num++, "Better Polus");
            BetterPolus = new CustomToggleOption(num++, "Vitals In Laboratory", true);
            PolusVents = new CustomToggleOption(num++, "Reactor Vents Are Connected To Buildings", true);
            SwitchTask = new CustomToggleOption(num++, "New Tasks Positions", true);
            CustomGameSettings =
                new CustomHeaderOption(num++, "Custom Game Settings");
            InitialCooldowns = new CustomNumberOption(num++, "Game Start Cooldowns", 10f, 10f, 30f,
                2.5f, CooldownFormat);
            ColourblindComms = new CustomToggleOption(num++, "Camouflaged Comms", true);
            MeetingColourblind = new CustomToggleOption(num++, "Camouflaged Meetings", false);
            KillVent = new CustomToggleOption(num++, "Can't Kill Players In Vent", true);
            ImpostorsKnowTeam =
                new CustomStringOption(num++, "Anon Imp", new[] {"Impostors Know Roles Of Their Team", "Impostors Don't Know Roles Of Their Team", "Impostors Don't Know Their Team", "Impostors Can Win Alone"});
            DeadSeeRoles =
                new CustomToggleOption(num++, "Dead can see everyone's roles", true);
            MaxImpostorRoles =
                new CustomNumberOption(num++, "Max Impostor Roles", 3f, 1f, 3f, 1f);
            MaxNeutralRoles =
                new CustomNumberOption(num++, "Max Neutral Roles", 4f, 1f, 5f, 1f);
            RoleUnderName = new CustomToggleOption(num++, "Role Appears Under Name", true);
            SGAfterVote = new CustomToggleOption(num++, "Swapper & Guesser Can Swap/Guess After Voting", true);
            VanillaGame = new CustomNumberOption(num++, "Probability of a completely vanilla game", 0f, 0f, 100f, 5f,
                PercentFormat);
            Guesser = new CustomHeaderOption(num++, "Guesser");
            GuesserKills = new CustomNumberOption(num++, "Number Of Guesser Kills", 15, 1, 15, 1);
            GuesserKillNoRole = new CustomToggleOption(num++, "Guesser can Guess Player Without Role", true);
            CanGuessNeutrals = new CustomToggleOption(num++, "Guesser Can Guess Neutral Roles", true);
            GuessSnitchViaCrewmate = new CustomToggleOption(num++, "Can Guess Snitch Via \"Crewmate\"", false);
            GuesserMultiKill = new CustomToggleOption(num++, "Guesser Can Kill More Than Once Per Meeting", true);
            GuesserMissKill = new CustomToggleOption(num++, "Guesser Can Missing Guess 1 Time", true);
            GuesserMissKillNotif = new CustomStringOption(num++, "Who Gets Missing Guess Indicator", new[] {"Everyone", "Target+Guesser", "Guesser"});
            MaxAssassins =
                new CustomNumberOption(num++, "Max Assassins Modifiers", 3f, 0f, 3f, 1f);
            #endregion


            #region CrewConfiguration
            Mayor =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Mayor).GetColoredName()}");
            MayorVoteBank =
                new CustomNumberOption(num++, "Initial Mayor Vote Bank", 3, 1, 7, 1);
            MayorAnonymous =
                new CustomToggleOption(num++, "Mayor Votes Show Anonymous", false);
            MayorButton =
                new CustomToggleOption(num++, "Mayor Can Button", true);

            Lovers =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Lover).WrapTextInColor("Lovers")}");
            BothLoversDie = new CustomToggleOption(num++, "Both Lovers Die", true);
            LovingImpostorOn = new CustomNumberOption(num++, "Allow Loving Impostor",50f, 0f, 100f, 10f,
                PercentFormat);
            LoverKill = new CustomToggleOption(num++, "Loving Impostor Can't Kill His Lover", true);
            VotedLover =
                new CustomToggleOption(num++, "Can't Report Voted Lover.", true);

            Sheriff =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Sheriff).GetColoredName()}");
            ShowSheriff = new CustomToggleOption(num++, "Show Sheriff", false);
            SheriffKillOther =
                new CustomToggleOption(num++, "Sheriff Miskill Kills Crewmate", false);
            SheriffKillsJester =
                new CustomToggleOption(num++, "Sheriff Kills Jester", true);
            SheriffKillsShifter =
                new CustomToggleOption(num++, "Sheriff Kills Shifter", false);SheriffKillsParasite =
                new CustomToggleOption(num++, "Sheriff Kills Parasite", true);
            SheriffKillsGlitch =
                new CustomToggleOption(num++, "Sheriff Kills The Glitch", true);
            SheriffKillsExecutioner =
                new CustomToggleOption(num++, "Sheriff Kills Executioner", true);
            SheriffKillsMentalist =
                new CustomToggleOption(num++, "Sheriff Kills Mentalist", true);
            SheriffKillsArsonist =
                new CustomToggleOption(num++, "Sheriff Kills Arsonist", true);
            SheriffKillsCannibal =
                new CustomToggleOption(num++, "Sheriff Kills Cannibal", true);
            SheriffKillCd =
                new CustomNumberOption(num++, "Sheriff Kill Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            SheriffBodyReport = new CustomToggleOption(num++, "Sheriff can report who they've killed");

            Engineer =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Engineer).GetColoredName()}");
            EngineerPer =
                new CustomStringOption(num++, "Engineer Fix Per", new[] {"Custom", "Round", "Game"});
            IsEngineerCd = 
                new CustomToggleOption(num++, "Engineer Have Cooldown", false);
            EngineerCd =
                new CustomNumberOption(num++, "Engineer Cooldown", 40, 32.5f, 90f, 2.5f, CooldownFormat); 
            FixesPerRound =
                new CustomNumberOption(num++, "Max Fixes Per Round",  2, 1, 5, 1);
            FixesNumber =
                new CustomNumberOption(num++, "Max Fixes Per Game",  3, 0, 30, 1);

            Swapper =
                new CustomHeaderOption(num++, "<color=#66E666FF>Swapper</color>");
            SwapperButton =
                new CustomToggleOption(num++, "Swapper Can Button", true);

            Investigator =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Investigator).GetColoredName()}");
            FootprintSize = new CustomNumberOption(num++, "Footprint Size", 1f, 0.5f, 10f, 0.25f);
            FootprintInterval =
                new CustomNumberOption(num++, "Footprint Interval", 1f, 0.25f, 5f, 0.25f, CooldownFormat);
            FootprintDuration = new CustomNumberOption(num++, "Footprint Duration", 8f, 1f, 10f, 0.5f, CooldownFormat);
            AnonymousFootPrint = new CustomToggleOption(num++, "Anonymous Footprint", false);
            VentFootprintVisible = new CustomToggleOption(num++, "Footprint Vent Visible", true);

            TimeLord =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.TimeLord).GetColoredName()}");
            RewindRevive = new CustomToggleOption(num++, "Revive During Rewind", true);
            RewindDuration = new CustomNumberOption(num++, "Rewind Duration", 3f, 2f, 15f, 0.5f, CooldownFormat);
            RewindCooldown = new CustomNumberOption(num++, "Rewind Cooldown", 40f, 10f, 60f, 2.5f, CooldownFormat);
            TimeLordVitals =
                new CustomToggleOption(num++, "Time Lord can use Vitals", false);

            Medic =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Medic).GetColoredName()}");
            ShowShielded =
                new CustomStringOption(num++, "Show Shielded Player",
                    new[] {"Medic", "Self", "Self+Medic", "Everyone"});
            MedicReportSwitch = new CustomToggleOption(num++, "Show Medic Reports", true);
            MedicReportNameDuration =
                new CustomNumberOption(num++, "Time Where Medic Reports Will Have Name", 3, 0, 60, 0.5f,
                    CooldownFormat);
            MedicReportColorDuration =
                new CustomNumberOption(num++, "Time Where Medic Reports Will Have Color Type", 15, 0, 120, 0.5f,
                    CooldownFormat);
            WhoGetsNotification =
                new CustomStringOption(num++, "Who gets murder attempt indicator",
                    new[] {"Medic", "Shielded", "Everyone", "Nobody"});
            ShieldBreaks = new CustomToggleOption(num++, "Shield breaks on murder attempt", true);

            Seer =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Seer).GetColoredName()}");
            SeerCooldown =
                new CustomNumberOption(num++, "Seer Cooldown", 45f, 10f, 100f, 2.5f, CooldownFormat);
            SeerInfo =
                new CustomStringOption(num++, "Info that Seer sees", new[] {"Team", "Role"});
            SeeReveal =
                new CustomStringOption(num++, "Who Sees That They Are Revealed",
                    new[] {"Imps+Neut", "Crew", "All", "Nobody"});
            NeutralRed =
                new CustomToggleOption(num++, "Neutrals show up as Impostors", false);
            SeerCrewmateChance = new CustomNumberOption(num++,
                "Chance to successfully reveal a Crewmate", 80f, 0f, 100f, 10f, PercentFormat);
            SeerNeutralChance = new CustomNumberOption(num++,
                "Chance to successfully reveal a Neutral role", 80f, 0f, 100f, 10f, PercentFormat);
            SeerImpostorChance = new CustomNumberOption(num++,
                "Chance to successfully reveal an Impostor", 80f, 0f, 100f, 10f, PercentFormat);

            Snitch = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Snitch).GetColoredName()}");
            SnitchOnLaunch =
                new CustomToggleOption(num++, "Snitch knows who they are on Game Start", false);
            SnitchSeesNeutrals = new CustomToggleOption(num++, "Snitch sees neutral roles", false);
            SnitchTasksRemaining =
                 new CustomNumberOption(num++, "Tasks Remaining When Revealed", 1, 1, 5, 1);
            SnitchSeesInMeetings = new CustomToggleOption(num++, "Snitch sees in meetings", true);

            Altruist = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Altruist).GetColoredName()}");
            ReviveDuration =
                new CustomNumberOption(num++, "Altruist Revive Duration", 4, 1, 30, 1f, CooldownFormat);
            AltruistTargetBody =
                new CustomToggleOption(num++, "Target's body disappears on beginning of revive", false);

            Prophet = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Prophet).GetColoredName()}");
            ProphetCooldown = new CustomNumberOption(num++, "Prophet Cooldown", 40f, 10f, 120f, 2.5f, CooldownFormat);
            ProphetInitialReveal =
                new CustomToggleOption(num++, "Prophet starts the game with a player revealed", false);

            Covert = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Covert).GetColoredName()}");
            CovertCooldown = new CustomNumberOption(num++, "Covert Cooldown", 30f, 10f, 120f, 2.5f, CooldownFormat);
            CovertDuration = new CustomNumberOption(num++, "Covert Duration", 15f, 5f, 30f, 2.5f, CooldownFormat);

            Haunter =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Haunter).GetColoredName()}");
            HaunterTasksRemainingClicked =
                 new CustomNumberOption(num++, "Tasks Remaining When Haunter Can Be Clicked", 5, 1, 10, 1);
            HaunterTasksRemainingAlert =
                 new CustomNumberOption(num++, "Tasks Remaining When Alert Is Sent", 1, 1, 5, 1);
            HaunterRevealsNeutrals = new CustomToggleOption(num++, "Haunter Reveals Neutral Roles", false);
            HaunterCanBeClickedBy = new CustomStringOption(num++, "Who Can Click Haunter", new[] { "Non-Crew", "Imps Only", "All" });
            #endregion


            #region NeutralConfiguration
            Jester = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Jester).GetColoredName()}");
            JesterVent =
                new CustomToggleOption(num++, "Jester Can Vent", true);
            JesterButton =
                new CustomToggleOption(num++, "Jester Can Button", true);

            Shifter =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Shifter).GetColoredName()}");
            ShifterCd =
                new CustomNumberOption(num++, "Shifter Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat);
            WhoShifts = new CustomStringOption(num++,
                "Who gets the Shifter role on Shift", new[] {"Nobody", "RegCrew", "NoImps"});
            ShifterSuicide =
                new CustomToggleOption(num++, "Shifter Suicide On Sheriff Kills", true);
            ShifterCrewmate =
                new CustomToggleOption(num++, "Shifter Wins With Crew", false);

            Parasite =
                new CustomHeaderOption(num++, "<color=#473204FF>Parasite</color>");
            ParasiteKill =
                new CustomToggleOption(num++, "Parasitized Can't Kill Parasite", true);

            TheGlitch =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Glitch).GetColoredName()}");
            MimicCooldownOption = new CustomNumberOption(num++, "Mimic Cooldown", 30, 10, 120, 2.5f, CooldownFormat);
            MimicDurationOption = new CustomNumberOption(num++, "Mimic Duration", 10, 1, 30, 1f, CooldownFormat);
            HackCooldownOption = new CustomNumberOption(num++, "Hack Cooldown", 30, 10, 120, 2.5f, CooldownFormat);
            HackDurationOption = new CustomNumberOption(num++, "Hack Duration", 10, 1, 30, 1f, CooldownFormat);
            GlitchKillCooldownOption =
                new CustomNumberOption(num++, "Glitch Kill Cooldown", 27.5f, 10, 120, 2.5f, CooldownFormat);
            GlitchHackDistanceOption =
                new CustomStringOption(num++, "Glitch Hack Distance", new[] {"Short", "Normal", "Long"});
            GlitchVent =
                new CustomToggleOption(num++, "Glitch Can Vent", false);

            Executioner =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Executioner).GetColoredName()}");
            OnTargetDead = new CustomStringOption(num++, "Executioner becomes on Target Dead",
                new[] {"Jester", "Crew", "Shifter"});
            ExecutionerButton =
                new CustomToggleOption(num++, "Executioner Can Button", true);

            Mentalist =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Mentalist).GetColoredName()}");
            GuessNeed = new CustomStringOption(num++, "Number Of Crewmates The Mentalist Must Guess",
                new[] {"Players/3", "1", "2", "3", "4", "5", "6"});
            MentalistButton =
                new CustomToggleOption(num++, "Mentalist Can Button", true);

            Arsonist = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Arsonist).GetColoredName()}");
            DouseCooldown =
                new CustomNumberOption(num++, "Douse Cooldown", 32.5f, 10, 40, 2.5f, CooldownFormat);
            ArsonistGameEnd = new CustomToggleOption(num++, "Game keeps going so long as Arsonist is alive", false);
            ArsonistButton =
                new CustomToggleOption(num++, "Arsonist Can Button", true);

            Cannibal =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Cannibal).GetColoredName()}");
            CannibalCd =
                new CustomNumberOption(num++, "Cannibal Cooldown", 20f, 10f, 60f, 2.5f, CooldownFormat);
            EatNeed =
                new CustomStringOption(num++, "Number Of Bodies The Cannibal Must Eat", new[] {"Players/3", "1", "2", "3", "4", "5", "6"});

            Phantom =
                new CustomHeaderOption(num++, "<color=#662962FF>Phantom</color>");
            PhantomTasksRemaining =
                 new CustomNumberOption(num++, "Tasks Remaining When Phantom Can Be Clicked", 5, 1, 10, 1);
            #endregion


            #region ImpostorConfiguration
            Morphling =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Morphling).GetColoredName()}");
            MorphlingCooldown =
                new CustomNumberOption(num++, "Morphling Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            MorphlingDuration =
                new CustomNumberOption(num++, "Morphling Duration", 10, 5, 15, 1f, CooldownFormat);
            MorphlingVent =
                new CustomToggleOption(num++, "Morphling Can Vent", false);

            Camouflager =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Camouflager).GetColoredName()}");
            CamouflagerCooldown =
                new CustomNumberOption(num++, "Camouflager Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            CamouflagerDuration =
                new CustomNumberOption(num++, "Camouflager Duration", 10, 5, 15, 1f, CooldownFormat);

            Miner = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Miner).GetColoredName()}");
            MineCooldown =
                new CustomNumberOption(num++, "Mine Cooldown", 30, 10, 40, 2.5f, CooldownFormat);

            Swooper = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Swooper).GetColoredName()}");
            SwoopCooldown =
                new CustomNumberOption(num++, "Swoop Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            SwoopDuration =
                new CustomNumberOption(num++, "Swoop Duration", 10, 5, 15, 1f, CooldownFormat);
            SwooperVent =
                new CustomToggleOption(num++, "Swooper Can Vent", false);

            Undertaker = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Undertaker).GetColoredName()}");
            DragCooldown = new CustomNumberOption(num++, "Drag Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            UndertakerVent =
                new CustomToggleOption(num++, "Undertaker Can Vent", true);
            UndertakerVentWithBody =
                new CustomToggleOption(num++, "Undertaker Can Vent While Dragging", false);

            Lycan = new CustomHeaderOption(num++, "<color=#FF0000FF>Lycan</color>");
            WolfCooldown = new CustomNumberOption(num++, "Lycanthropy Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            WolfDuration = new CustomNumberOption(num++, "Lycanthropy Duration", 10, 5, 15, 1f, CooldownFormat);
            LycanVent =
                new CustomToggleOption(num++, "Lycan Can Vent", true);
            LycanWolfVent =
                new CustomToggleOption(num++, "Lycan Can Vent When Wolfed", false);

            Teleporter = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Teleporter).GetColoredName()}");
            TeleporterCooldown =
                new CustomNumberOption(num++, "Teleporter Cooldown", 30, 10, 120, 2.5f, CooldownFormat);
            TeleportSelf = new CustomToggleOption(num++, "Teleport Teleports Themself", true);
            TeleportOccupiedVents = new CustomToggleOption(num++, "Allow Occupied Vents", true);

            Concealer = new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Concealer).GetColoredName()}");
            ConcealCooldown = new CustomNumberOption(num++, "Conceal Cooldown", 30, 10, 60, 2.5f, CooldownFormat);
            TimeToConceal = new CustomNumberOption(num++, "Delay Before Concealing", 5, 2.5f, 15, 2.5f, CooldownFormat);
            ConcealDuration = new CustomNumberOption(num++, "Conceal Duration", 10, 2.5f, 20f, 2.5f, CooldownFormat);

            Grenadier =
                new CustomHeaderOption(num++, $"{RoleDetailsAttribute.GetRoleDetails(RoleEnum.Grenadier).GetColoredName()}");
            GrenadeCooldown =
                new CustomNumberOption(num++, "Flash Grenade Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            GrenadeDuration =
                new CustomNumberOption(num++, "Flash Grenade Duration", 10, 5, 15, 1f, CooldownFormat);
            GrenadierVent =
                new CustomToggleOption(num++, "Grenadier Can Vent", false);
            #endregion
        }
    }
}
