using Hazel;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Cannibal : Role
    {
        public DeadBody CurrentTarget { get; set; }
        public int EatNeed;
        public bool CannibalWin;
        
        public Cannibal(PlayerControl player) : base(player)
        {
            Name = "Cannibal";
            ImpostorText = () => "Eat Dead";
            Color = new Color(0.30f, 0.48f, 0.11f, 1f);
            RoleType = RoleEnum.Cannibal;
            Faction = Faction.Neutral;
            EatNeed = PlayerControl.AllPlayerControls._size / 3;
            var body = EatNeed == 1 ? "Body" : "Bodies";
            TaskText = () => $"Eat {EatNeed} Dead {body} to Win\nFake Tasks:";
        }
        
        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            if (EatNeed == 0)
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.CannibalWin, SendOption.Reliable, -1);
                writer.Write(Player.PlayerId);
                Wins();
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Utils.EndGame();
                return false;
            }
            
            return true;
        }

        public void Wins()
        {
            CannibalWin = true;
        }

        public void Loses()
        {
            Player.Data.IsImpostor = true;
        }

        protected override void IntroPrefix(IntroCutscene._CoBegin_d__14 __instance)
        {
            var cannibalteam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            cannibalteam.Add(PlayerControl.LocalPlayer);
            __instance.yourTeam = cannibalteam;
        }
    }
}