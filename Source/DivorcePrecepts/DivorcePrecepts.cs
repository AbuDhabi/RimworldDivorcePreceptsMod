using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace DivorcePrecepts
{
    [StaticConstructorOnStartup]
    public static class DivorcePrecepts
    {
        static DivorcePrecepts() //our constructor
        {
            var harmony = new Harmony("AbuDhabi.MiscMods.DivorcePrecepts");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(InteractionWorker_Breakup))]
        [HarmonyPatch(nameof(InteractionWorker_Breakup.RandomSelectionWeight))]
        class Patch
        {
            static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
            {
                if (initiator.relations.DirectRelationExists(PawnRelationDefOf.Spouse, recipient))
                {
                    if (initiator.Ideo != null && initiator.Ideo.HasPrecept(PreceptDefOf.Divorce_Prohibited))
                    {
                        __result = 0f;
                    }
                    else if (initiator.Ideo != null && initiator.Ideo.HasPrecept(PreceptDefOf.Divorce_Disapproved))
                    {
                        var newChance = __result * 0.5f;
                        __result = newChance;
                    }
                }
            }
        }
    }
}
