using RimWorld;
using Verse;

namespace DivorcePrecepts
{
    [DefOf]
    public static class PreceptDefOf
    {
        public static PreceptDef Divorce_Prohibited;

        public static PreceptDef Divorce_Disapproved;

        static PreceptDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PreceptDefOf));
        }
    }
}
