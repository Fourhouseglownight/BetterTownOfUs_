﻿using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Executioner : Role
    {
        public PlayerControl target;
        public bool TargetVotedOut;

        public Executioner(PlayerControl player) : base(player, RoleEnum.Executioner)
        {
            ImpostorText = () =>
                target == null ? "You don't have a target for some reason... weird..." : $"Vote {target.name} out";
            TaskText = () =>
                target == null
                    ? "You don't have a target for some reason... weird..."
                    : $"Vote {target.name} out\nFake Tasks:";
        }

        protected override void IntroPrefix(IntroCutscene._CoBegin_d__18 __instance)
        {
            var executionerteam = new List<PlayerControl>();
            executionerteam.Add(PlayerControl.LocalPlayer);
            __instance.yourTeam = executionerteam;
        }

        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            if (Player.Data.IsDead) return true;
            if (!TargetVotedOut || !target.Data.IsDead) return true;
            Utils.EndGame();
            return false;
        }

        public void Wins()
        {
            if (Player.Data.IsDead || Player.Data.Disconnected) return;
            TargetVotedOut = true;
        }

        public void Loses()
        {
            LostByRPC = true;
        }
    }
}
