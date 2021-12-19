using HarmonyLib;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.Patches.ImpostorRoles.ConcealerMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.SetTarget))]
    public class SetTarget
    {
        public static void Postfix(KillButton __instance, [HarmonyArgument(0)] PlayerControl target)
        {
            if (
                PlayerControl.AllPlayerControls.Count <= 1
                || PlayerControl.LocalPlayer == null
                || PlayerControl.LocalPlayer.Data == null
                || !PlayerControl.LocalPlayer.Is(RoleEnum.Concealer)
                || target == null
            )
            {
                return;
            }
            Concealer role = Role.GetRole<Concealer>(PlayerControl.LocalPlayer);
            if (__instance != role.ConcealButton)
            {
                return;
            }

            if (target.Is(Faction.Impostors))
            {
                __instance.graphic.color = Palette.DisabledClear;
                __instance.graphic.material.SetFloat("_Desat", 1f);
            }
        }
    }
}
