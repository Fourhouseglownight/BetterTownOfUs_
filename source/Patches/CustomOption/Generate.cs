using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace BetterTownOfUs.CustomOption
{
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class Generate
    {
        public static CustomHeaderOption Polus;
        public static CustomToggleOption BetterPolus;
        public static CustomToggleOption SwitchTask;
        public static CustomToggleOption PolusVents;
        public static CustomToggleOption SGAfterVote;
        public static CustomToggleOption KillVent;
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

        private static CustomHeaderOption NeutralRoles;
        public static CustomNumberOption JesterOn;
        public static CustomNumberOption ShifterOn;
        public static CustomNumberOption ParasiteOn;
        public static CustomNumberOption GlitchOn;
        public static CustomNumberOption ExecutionerOn;
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

        private static CustomHeaderOption Modifiers;
        public static CustomNumberOption TorchOn;
        public static CustomNumberOption DiseasedOn;
        public static CustomNumberOption FlashOn;
        public static CustomNumberOption TiebreakerOn;
        public static CustomNumberOption DrunkOn;
        public static CustomNumberOption BigBoiOn;
        public static CustomNumberOption ButtonBarryOn;

        private static CustomHeaderOption CustomGameSettings;
        public static CustomNumberOption InitialImpostorKillCooldown;
        public static CustomToggleOption ColourblindComms;
        public static CustomToggleOption MeetingColourblind;
        public static CustomStringOption ImpostorsKnowTeam;
        public static CustomToggleOption DeadSeeRoles;
        public static CustomNumberOption MaxImpostorRoles;
        public static CustomNumberOption MaxNeutralRoles;
        public static CustomToggleOption RoleUnderName;
        public static CustomNumberOption VanillaGame;

        private static CustomHeaderOption Mayor;
        public static CustomNumberOption MayorVoteBank;
        public static CustomToggleOption MayorAnonymous;

        private static CustomHeaderOption Lovers;
        public static CustomNumberOption LovingImpostorOn;
        public static CustomToggleOption BothLoversDie;
        public static CustomToggleOption LoverKill;
        public static CustomToggleOption LoverVoted;

        private static CustomHeaderOption Sheriff;
        public static CustomToggleOption ShowSheriff;
        public static CustomToggleOption SheriffKillOther;
        public static CustomToggleOption SheriffKillsJester;
        public static CustomToggleOption SheriffKillsShifter;
        public static CustomToggleOption SheriffKillsParasite;
        public static CustomToggleOption SheriffKillsGlitch;
        public static CustomToggleOption SheriffKillsExecutioner;
        public static CustomToggleOption SheriffKillsArsonist;
        public static CustomToggleOption SheriffKillsCannibal;
        public static CustomNumberOption InitialSheriffKillCd;
        public static CustomNumberOption SheriffKillCd;
        public static CustomToggleOption SheriffBodyReport;

        private static CustomHeaderOption Shifter;
        public static CustomNumberOption ShifterCd;
        public static CustomStringOption WhoShifts;
        public static CustomToggleOption ShifterSuicide;

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

        private static CustomHeaderOption Altruist;
        public static CustomNumberOption ReviveDuration;
        public static CustomToggleOption AltruistTargetBody;

        private static CustomHeaderOption Prophet;
        public static CustomNumberOption ProphetCooldown;
        public static CustomToggleOption ProphetInitialReveal;

        private static CustomHeaderOption Covert;
        public static CustomNumberOption CovertCooldown;
        public static CustomNumberOption CovertDuration;
        
        public static CustomHeaderOption Jester;
        public static CustomToggleOption JesterVent;

        private static CustomHeaderOption TheGlitch;
        public static CustomNumberOption MimicCooldownOption;
        public static CustomNumberOption MimicDurationOption;
        public static CustomNumberOption HackCooldownOption;
        public static CustomNumberOption HackDurationOption;
        public static CustomNumberOption GlitchKillCooldownOption;
        public static CustomNumberOption InitialGlitchKillCooldownOption;
        public static CustomStringOption GlitchHackDistanceOption;

        private static CustomHeaderOption Arsonist;
        public static CustomNumberOption DouseCooldown;
        public static CustomToggleOption ArsonistGameEnd;

        private static CustomHeaderOption Cannibal;
        public static CustomNumberOption CannibalCd;

        private static CustomHeaderOption Executioner;
        public static CustomStringOption OnTargetDead;

        private static CustomHeaderOption Camouflager;
        public static CustomNumberOption CamouflagerCooldown;
        public static CustomNumberOption CamouflagerDuration;

        private static CustomHeaderOption Morphling;
        public static CustomNumberOption MorphlingCooldown;
        public static CustomNumberOption MorphlingDuration;

        private static CustomHeaderOption Miner;
        public static CustomNumberOption MineCooldown;

        private static CustomHeaderOption Swooper;
        public static CustomNumberOption SwoopCooldown;
        public static CustomNumberOption SwoopDuration;

        private static CustomHeaderOption Undertaker;
        public static CustomNumberOption DragCooldown;

        private static CustomHeaderOption Assassin;
        public static CustomNumberOption AssassinKills;
        public static CustomToggleOption AssassinGuessNeutrals;
        public static CustomToggleOption AssassinCrewmateGuess;
        public static CustomToggleOption AssassinMultiKill;
        public static CustomToggleOption MissKill;
        public static CustomStringOption MissKillNotif;
        
        public static CustomHeaderOption Lycan;
        public static CustomNumberOption WolfCooldown;
        public static CustomNumberOption WolfDuration;

        private static CustomHeaderOption Teleporter;
        public static CustomNumberOption TeleporterCooldown;
        public static CustomToggleOption TeleportSelf;
        public static CustomToggleOption TeleportOccupiedVents;

        private static CustomHeaderOption Concealer;
        public static CustomNumberOption ConcealCooldown;
        public static CustomNumberOption TimeToConceal;
        public static CustomNumberOption ConcealDuration;

        private static Func<object, string> PercentFormat { get; } = value => $"{value:0}%";
        private static Func<object, string> CooldownFormat { get; } = value => $"{value:0.0#}s";


        public static void GenerateAll()
        {
            var num = 0;

            Patches.ExportButton = new Export(num++);
            Patches.ImportButton = new Import(num++);


            #region Probabilities
            CrewmateRoles = new CustomHeaderOption(num++, "Crewmate Roles");
            MayorOn = new CustomNumberOption(true, num++, "<color=#704FA8FF>Mayor</color>", 100f, 0f, 100f, 10f,
                PercentFormat);
            LoversOn = new CustomNumberOption(true, num++, "<color=#FF66CCFF>Lovers</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            SheriffOn = new CustomNumberOption(true, num++, "<color=#FFFF00FF>Sheriff</color>", 100f, 0f, 100f, 10f,
                PercentFormat);
            EngineerOn = new CustomNumberOption(true, num++, "<color=#FFA60AFF>Engineer</color>", 100f, 0f, 100f, 10f,
                PercentFormat);
            SwapperOn = new CustomNumberOption(true, num++, "<color=#66E666FF>Swapper</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            InvestigatorOn = new CustomNumberOption(true, num++, "<color=#00B3B3FF>Investigator</color>", 0f, 0f, 100f,
                10f, PercentFormat);
            TimeLordOn = new CustomNumberOption(true, num++, "<color=#0000FFFF>Time Lord</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            MedicOn = new CustomNumberOption(true, num++, "<color=#006600FF>Medic</color>", 100f, 0f, 100f, 10f,
                PercentFormat);
            SeerOn = new CustomNumberOption(true, num++, "<color=#FFCC80FF>Seer</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            SpyOn = new CustomNumberOption(true, num++, "<color=#CCA3CCFF>Spy</color>", 40f, 0f, 100f, 10f,
                PercentFormat);
            SnitchOn = new CustomNumberOption(true, num++, "<color=#D4AF37FF>Snitch</color>", 40f, 0f, 100f, 10f,
                PercentFormat);
            AltruistOn = new CustomNumberOption(true, num++, "<color=#660000FF>Altruist</color>", 60f, 0f, 100f, 10f,
                PercentFormat);
            ProphetOn = new CustomNumberOption(true, num++, "<color=#B026FF>Prophet</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            CovertOn = new CustomNumberOption(true, num++, "<color=#7B7F1A>Covert</color>", 20f, 0f, 100f, 10f,
                PercentFormat);


            NeutralRoles = new CustomHeaderOption(num++, "Neutral Roles");
            JesterOn = new CustomNumberOption(true, num++, "<color=#FFBFCCFF>Jester</color>", 60f, 0f, 100f, 10f,
                PercentFormat);
            ShifterOn = new CustomNumberOption(true, num++, "<color=#999999FF>Shifter</color>", 40f, 0f, 100f, 10f,
                PercentFormat);
            ParasiteOn = new CustomNumberOption(true, num++, "<color=#473204FF>Parasite</color>", 40f, 0f, 100f, 10f,
                PercentFormat);
            GlitchOn = new CustomNumberOption(true, num++, "<color=#00FF00FF>The Glitch</color>", 70f, 0f, 100f, 10f,
                PercentFormat);
            ExecutionerOn = new CustomNumberOption(true, num++, "<color=#8C4005FF>Executioner</color>", 10f, 0f, 100f,
                10f, PercentFormat);
            ArsonistOn = new CustomNumberOption(true, num++, "<color=#FF4D00FF>Arsonist</color>", 40f, 0f, 100f, 10f,
                PercentFormat);
            CannibalOn = new CustomNumberOption(true, num++, "<color=#1e300bFF>Cannibal</color>", 40f, 0f, 100f, 10f,
                PercentFormat);
            PhantomOn = new CustomNumberOption(true, num++, "<color=#662962>Phantom</color>", 100f, 0f, 100f, 10f,
                PercentFormat);


            ImpostorRoles = new CustomHeaderOption(num++, "Impostor Roles");
            AssassinOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Assassin</color>", 100f, 0f, 100f, 10f,
                PercentFormat);
            JanitorOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Janitor</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            MorphlingOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Morphling</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            CamouflagerOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Camouflager</color>", 0f, 0f, 100f,
                10f, PercentFormat);
            MinerOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Miner</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            SwooperOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Swooper</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            UndertakerOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Undertaker</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            UnderdogOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Underdog</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            LycanOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Lycan</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            TeleporterOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Teleporter</color>", 50f, 0f, 100f, 10f,
                PercentFormat);
            ConcealerOn = new CustomNumberOption(true, num++, "<color=#FF0000FF>Concealer</color>", 50f, 0f, 100f, 10f,
                PercentFormat);


            Modifiers = new CustomHeaderOption(num++, "Modifiers");
            TorchOn = new CustomNumberOption(true, num++, "<color=#FFFF99FF>Torch</color>", 20f, 0f, 100f, 10f,
                PercentFormat);
            DiseasedOn =
                new CustomNumberOption(true, num++, "<color=#808080FF>Diseased</color>", 20f, 0f, 100f, 10f,
                    PercentFormat);
            FlashOn = new CustomNumberOption(true, num++, "<color=#FF8080FF>Flash</color>", 0f, 0f, 100f, 10f,
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
            #endregion


            #region GameSettings    
            Polus = new CustomHeaderOption(num++, "Better Polus");
            BetterPolus = new CustomToggleOption(num++, "Vitals in Laboratory", true);
            PolusVents = new CustomToggleOption(num++, "Reactor vents are connected to buildings", true);
            SwitchTask = new CustomToggleOption(num++, "New Tasks Positions", true);
            CustomGameSettings =
                new CustomHeaderOption(num++, "Custom Game Settings");
            InitialImpostorKillCooldown = new CustomNumberOption(num++, "Initial Impostor Kill Cooldown", 10f, 10f, 60f,
                2.5f, CooldownFormat);
            ColourblindComms = new CustomToggleOption(num++, "Camouflaged Comms", true);
            MeetingColourblind = new CustomToggleOption(num++, "Camouflaged Meetings", false);
            SGAfterVote = new CustomToggleOption(num++, "Swapper & Assassin can swap/guess after voting", true);
            KillVent = new CustomToggleOption(num++, "Can't kill players in vent", true);
            ImpostorsKnowTeam =
                new CustomStringOption(num++, "Anon Imp", new[] {"Impostors know roles of their team", "Impostors don't know roles of their team", "Impostors don't know their team", "Impostors can win alone"});
            DeadSeeRoles =
                new CustomToggleOption(num++, "Dead can see everyone's roles", true);
            MaxImpostorRoles =
                new CustomNumberOption(num++, "Max Impostor Roles", 3f, 1f, 3f, 1f);
            MaxNeutralRoles =
                new CustomNumberOption(num++, "Max Neutral Roles", 4f, 1f, 5f, 1f);
            RoleUnderName = new CustomToggleOption(num++, "Role Appears Under Name", true);
            VanillaGame = new CustomNumberOption(num++, "Probability of a completely vanilla game", 0f, 0f, 100f, 5f,
                PercentFormat);
            #endregion


            #region CrewConfiguration
            Mayor =
                new CustomHeaderOption(num++, "<color=#704FA8FF>Mayor</color>");
            MayorVoteBank =
                new CustomNumberOption(num++, "Initial Mayor Vote Bank", 3, 1, 7, 1);
            MayorAnonymous =
                new CustomToggleOption(num++, "Mayor Votes Show Anonymous", false);

            Lovers =
                new CustomHeaderOption(num++, "<color=#FF66CCFF>Lovers</color>");
            LovingImpostorOn = new CustomNumberOption(num++, "Allow Loving Impostor",50f, 0f, 100f, 10f,
                PercentFormat);
            BothLoversDie = new CustomToggleOption(num++, "Both Lovers Die", true);
            LoverKill = new CustomToggleOption(num++, "Loving Impostor can't kill his Lover", true);
            LoverVoted =
                new CustomToggleOption(num++, "Can't Report Voted Lover.", true);

            Sheriff =
                new CustomHeaderOption(num++, "<color=#FFFF00FF>Sheriff</color>");
            ShowSheriff = new CustomToggleOption(num++, "Show Sheriff", false);
            SheriffKillOther =
                new CustomToggleOption(num++, "Sheriff Miskill Kills Crewmate", false);
            SheriffKillsJester =
                new CustomToggleOption(num++, "Sheriff Kills Jester", true);
            SheriffKillsShifter =
                new CustomToggleOption(num++, "Sheriff Kills Shifter", false);
            SheriffKillsParasite =
                new CustomToggleOption(num++, "Sheriff Kills Parasite", true);
            SheriffKillsGlitch =
                new CustomToggleOption(num++, "Sheriff Kills The Glitch", true);
            SheriffKillsExecutioner =
                new CustomToggleOption(num++, "Sheriff Kills Executioner", true);
            SheriffKillsArsonist =
                new CustomToggleOption(num++, "Sheriff Kills Arsonist", true);
            SheriffKillsCannibal =
                new CustomToggleOption(num++, "Sheriff Kills Cannibal", true);
            InitialSheriffKillCd =
                new CustomNumberOption(num++, "Initial Sheriff Kill Cooldown", 10f, 10f, 40f, 2.5f, CooldownFormat);
            SheriffKillCd =
                new CustomNumberOption(num++, "Sheriff Kill Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            SheriffBodyReport = new CustomToggleOption(num++, "Sheriff can report who they've killed", true);

            Engineer =
                new CustomHeaderOption(num++, "<color=#FFA60AFF>Engineer</color>");
            EngineerPer =
                new CustomStringOption(num++, "Engineer Fix Per", new[] {"Custom", "Round", "Game"});
            IsEngineerCd = 
                new CustomToggleOption(num++, "Engineer Have Cooldown", false);
            EngineerCd =
                new CustomNumberOption(num++, "Engineer Cooldown", 40, 32.5f, 90f, 2.5f, CooldownFormat); 
            FixesPerRound =
                new CustomNumberOption(num++, "Max fixes per round",  2, 1, 5, 1);
            FixesNumber =
                new CustomNumberOption(num++, "Max fixes per game",  3, 0, 30, 1);

            Investigator =
                new CustomHeaderOption(num++, "<color=#00B3B3FF>Investigator</color>");
            FootprintSize = new CustomNumberOption(num++, "Footprint Size", 1f, 0.5f, 10f, 0.25f);
            FootprintInterval =
                new CustomNumberOption(num++, "Footprint Interval", 1f, 0.25f, 5f, 0.25f, CooldownFormat);
            FootprintDuration = new CustomNumberOption(num++, "Footprint Duration", 8f, 1f, 10f, 0.5f, CooldownFormat);
            AnonymousFootPrint = new CustomToggleOption(num++, "Anonymous Footprint", false);
            VentFootprintVisible = new CustomToggleOption(num++, "Footprint Vent Visible", true);

            TimeLord =
                new CustomHeaderOption(num++, "<color=#0000FFFF>Time Lord</color>");
            RewindRevive = new CustomToggleOption(num++, "Revive During Rewind", true);
            RewindDuration = new CustomNumberOption(num++, "Rewind Duration", 4f, 3f, 15f, 0.5f, CooldownFormat);
            RewindCooldown = new CustomNumberOption(num++, "Rewind Cooldown", 40f, 10f, 40f, 2.5f, CooldownFormat);
            TimeLordVitals =
                new CustomToggleOption(num++, "Time Lord can use Vitals", false);

            Medic =
                new CustomHeaderOption(num++, "<color=#006600FF>Medic</color>");
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
                new CustomHeaderOption(num++, "<color=#FFCC80FF>Seer</color>");
            SeerCooldown =
                new CustomNumberOption(num++, "Seer Cooldown", 50f, 10f, 100f, 2.5f, CooldownFormat);
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

                Snitch = new CustomHeaderOption(num++, "<color=#D4AF37FF>Snitch</color>");
            SnitchOnLaunch =
                new CustomToggleOption(num++, "Snitch knows who they are on Game Start", false);
            SnitchSeesNeutrals = new CustomToggleOption(num++, "Snitch sees neutral roles", false);
            SnitchSeesInMeetings = new CustomToggleOption(num++, "Snitch sees in meetings", true);

            Altruist = new CustomHeaderOption(num++, "<color=#660000FF>Altruist</color>");
            ReviveDuration =
                new CustomNumberOption(num++, "Altruist Revive Duration", 4, 1, 30, 1, CooldownFormat);
            AltruistTargetBody =
                new CustomToggleOption(num++, "Target's body disappears on beginning of revive", false);

            Prophet = new CustomHeaderOption(num++, "<color=#B026FF>Prophet</color>");
            ProphetCooldown = new CustomNumberOption(num++, "Prophet Cooldown", 40f, 10f, 120f, 2.5f, CooldownFormat);
            ProphetInitialReveal =
                new CustomToggleOption(num++, "Prophet starts the game with a player revealed.", false);

            Covert = new CustomHeaderOption(num++, "<color=#7B7F1A>Covert</color>");
            CovertCooldown = new CustomNumberOption(num++, "Covert Cooldown", 30f, 10f, 120f, 2.5f, CooldownFormat);
            CovertDuration = new CustomNumberOption(num++, "Covert Duration", 15f, 5f, 30f, 2.5f, CooldownFormat);
            #endregion


            #region NeutralConfiguration
            Jester = new CustomHeaderOption(num++, "<color=#FFBFCCFF>Jester</color>");
            JesterVent =
                new CustomToggleOption(num++, "Jester Can Take Vent", true);

            Shifter =
                new CustomHeaderOption(num++, "<color=#999999FF>Shifter</color>");
            ShifterCd =
                new CustomNumberOption(num++, "Shifter Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat);
            WhoShifts = new CustomStringOption(num++,
                "Who gets the Shifter role on Shift", new[] {"Nobody", "RegCrew", "NoImps"});
            ShifterSuicide =
                new CustomToggleOption(num++, "Shifter Suicide on Sheriff Kills", true);

            Parasite =
                new CustomHeaderOption(num++, "<color=#473204FF>Parasite</color>");
            ParasiteKill =
                new CustomToggleOption(num++, "Parasitized Can't Kill Parasite", true);

            TheGlitch =
                new CustomHeaderOption(num++, "<color=#00FF00FF>The Glitch</color>");
            MimicCooldownOption = new CustomNumberOption(num++, "Mimic Cooldown", 30, 10, 120, 2.5f, CooldownFormat);
            MimicDurationOption = new CustomNumberOption(num++, "Mimic Duration", 10, 1, 30, 1f, CooldownFormat);
            HackCooldownOption = new CustomNumberOption(num++, "Hack Cooldown", 30, 10, 120, 2.5f, CooldownFormat);
            HackDurationOption = new CustomNumberOption(num++, "Hack Duration", 10, 1, 30, 1f, CooldownFormat);
            GlitchKillCooldownOption =
                new CustomNumberOption(num++, "Glitch Kill Cooldown", 27.5f, 10, 120, 2.5f, CooldownFormat);
            InitialGlitchKillCooldownOption =
                new CustomNumberOption(num++, "Initial Glitch Kill Cooldown", 10, 10, 120, 2.5f, CooldownFormat);
            GlitchHackDistanceOption =
                new CustomStringOption(num++, "Glitch Hack Distance", new[] {"Short", "Normal", "Long"});

            Executioner =
                new CustomHeaderOption(num++, "<color=#8C4005FF>Executioner</color>");
            OnTargetDead = new CustomStringOption(num++, "Executioner becomes on Target Dead",
                new[] {"Jester", "Crew"});

            Arsonist = new CustomHeaderOption(num++, "<color=#FF4D00FF>Arsonist</color>");
            DouseCooldown =
                new CustomNumberOption(num++, "Douse Cooldown", 32.5f, 10, 40, 2.5f, CooldownFormat);
            ArsonistGameEnd = new CustomToggleOption(num++, "Game keeps going so long as Arsonist is alive", false);

            Cannibal =
                new CustomHeaderOption(num++, "<color=#1e300bFF>Cannibal</color>");
            CannibalCd =
                new CustomNumberOption(num++, "Cannibal Cooldown", 20f, 10f, 60f, 2.5f, CooldownFormat);
            #endregion

            #region ImpostorConfiguration
            Morphling =
                new CustomHeaderOption(num++, "<color=#FF0000FF>Morphling</color>");
            MorphlingCooldown =
                new CustomNumberOption(num++, "Morphling Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            MorphlingDuration =
                new CustomNumberOption(num++, "Morphling Duration", 10, 5, 15, 1f, CooldownFormat);

            Camouflager =
                new CustomHeaderOption(num++, "<color=#FF0000FF>Camouflager</color>");
            CamouflagerCooldown =
                new CustomNumberOption(num++, "Camouflager Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            CamouflagerDuration =
                new CustomNumberOption(num++, "Camouflager Duration", 10, 5, 15, 1f, CooldownFormat);

            Miner = new CustomHeaderOption(num++, "<color=#FF0000FF>Miner</color>");
            MineCooldown =
                new CustomNumberOption(num++, "Mine Cooldown", 30, 10, 40, 2.5f, CooldownFormat);

            Swooper = new CustomHeaderOption(num++, "<color=#FF0000FF>Swooper</color>");
            SwoopCooldown =
                new CustomNumberOption(num++, "Swoop Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            SwoopDuration =
                new CustomNumberOption(num++, "Swoop Duration", 10, 5, 15, 1f, CooldownFormat);

            Undertaker = new CustomHeaderOption(num++, "<color=#FF0000FF>Undertaker</color>");
            DragCooldown = new CustomNumberOption(num++, "Drag Cooldown", 30, 10, 40, 2.5f, CooldownFormat);

            Assassin = new CustomHeaderOption(num++, "<color=#FF0000FF>Assassin</color>");
            AssassinKills = new CustomNumberOption(num++, "Number of Assassin Kills", 15, 1, 15, 1);
            AssassinCrewmateGuess = new CustomToggleOption(num++, "Assassin can Guess \"Crewmate\"", true);
            AssassinGuessNeutrals = new CustomToggleOption(num++, "Assassin can Guess Neutral roles", true);
            AssassinMultiKill = new CustomToggleOption(num++, "Assassin can kill more than once per meeting", true);
            MissKill = new CustomToggleOption(num++, "Can Missing Guess 1 Time", true);
            MissKillNotif = new CustomStringOption(num++, "Who gets Assassin miss kill indicator", new[] {"Everyone", "Target+Assassin", "Assassin"});

            Lycan = new CustomHeaderOption(num++, "<color=#FF0000FF>Lycan</color>");
            WolfCooldown = new CustomNumberOption(num++, "Lycanthropy Cooldown", 30, 10, 40, 2.5f, CooldownFormat);
            WolfDuration = new CustomNumberOption(num++, "Lycanthropy Duration", 10, 5, 15, 1f, CooldownFormat);

            Teleporter = new CustomHeaderOption(num++, "<color=#FF0000FF>Teleporter</color>");
            TeleporterCooldown =
                new CustomNumberOption(num++, "Teleporter Cooldown", 45, 10, 120, 2.5f, CooldownFormat);
            TeleportSelf = new CustomToggleOption(num++, "Teleport Teleports Themself", true);
            TeleportOccupiedVents = new CustomToggleOption(num++, "Allow Occupied Vents", true);

            Concealer = new CustomHeaderOption(num++, "<color=#FF0000FF>Concealer</color>");
            ConcealCooldown = new CustomNumberOption(num++, "Conceal Cooldown", 30, 10, 60, 2.5f, CooldownFormat);
            TimeToConceal = new CustomNumberOption(num++, "Delay Before Concealing", 5, 2.5f, 15, 2.5f, CooldownFormat);
            ConcealDuration = new CustomNumberOption(num++, "Conceal Duration", 10, 2.5f, 20f, 2.5f, CooldownFormat);
            #endregion
        }
    }
}
