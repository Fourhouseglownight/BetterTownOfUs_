using System;
using System.Collections.Generic;

namespace BetterTownOfUs.CrewmateRoles.MedicMod
{
    public class DeadPlayer
    {
        public byte KillerId { get; set; }
        public byte PlayerId { get; set; }
        public DateTime KillTime { get; set; }
    }

    //body report class for when medic reports a body
    public class BodyReport
    {
        public PlayerControl Killer { get; set; }
        public PlayerControl Reporter { get; set; }
        public PlayerControl Body { get; set; }
        public float KillAge { get; set; }
        public enum ColorsEnum
        {
            Darker,
            Lighter
        }
        public static readonly Dictionary<int, ColorsEnum> Colors = new Dictionary<int, ColorsEnum>
        {
            {0, ColorsEnum.Darker},// red
            {1, ColorsEnum.Darker},// blue
            {2, ColorsEnum.Darker},// green
            {3, ColorsEnum.Lighter},// pink
            {4, ColorsEnum.Lighter},// orange
            {5, ColorsEnum.Lighter},// yellow
            {6, ColorsEnum.Darker},// black
            {7, ColorsEnum.Lighter},// white
            {8, ColorsEnum.Darker},// purple
            {9, ColorsEnum.Darker},// brown
            {10, ColorsEnum.Lighter},// cyan
            {11, ColorsEnum.Lighter},// lime
            {12, ColorsEnum.Darker},// maroon
            {13, ColorsEnum.Lighter},// rose
            {14, ColorsEnum.Lighter},// banana
            {15, ColorsEnum.Darker},// gray
            {16, ColorsEnum.Darker},// tan
            {17, ColorsEnum.Lighter},// coral
            {18, ColorsEnum.Darker},// watermelon
            {19, ColorsEnum.Darker},// chocolate
            {20, ColorsEnum.Lighter},// sky blue
            {21, ColorsEnum.Darker},// beige
            {22, ColorsEnum.Lighter},// hot pink
            {23, ColorsEnum.Lighter},// turquoise
            {24, ColorsEnum.Lighter},// lilac
            {25, ColorsEnum.Darker},// rainbow
            {26, ColorsEnum.Lighter},// azure
            {27, ColorsEnum.Darker},// panda
        };

        public static string ParseBodyReport(BodyReport br)
        {
            //System.Console.WriteLine(br.KillAge);
            if (br.KillAge > CustomGameOptions.MedicReportColorDuration * 1000)
                return
                    $"Body Report: The corpse is too old to gain information from. (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            if (br.Killer.PlayerId == br.Body.PlayerId)
                return
                    $"Body Report: The kill appears to have been a suicide! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            if (br.KillAge < CustomGameOptions.MedicReportNameDuration * 1000)
                return
                    $"Body Report: The killer appears to be {br.Killer.Data.PlayerName}! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            var typeOfColor = Colors[br.Killer.CurrentOutfit.ColorId] == ColorsEnum.Darker ? "Darker" : "Lighter";
            return
                $"Body Report: The killer appears to be a {typeOfColor} color. (Killed {Math.Round(br.KillAge / 1000)}s ago)";
        }
    }
}
