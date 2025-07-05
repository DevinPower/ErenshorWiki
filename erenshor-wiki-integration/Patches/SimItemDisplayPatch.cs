using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace erenshor_wiki_integration.Patches
{
    [HarmonyPatch(typeof(SimItemDisplay))]
    [HarmonyPatch("OnPointerEnter")]
    class SimItemDispaly_OnPointerEnter
    {
        static void Prefix(SimItemDisplay __instance)
        {
            Mod.Instance.SetHoveredItem(__instance.MyItem);
        }
    }

    [HarmonyPatch(typeof(SimItemDisplay))]
    [HarmonyPatch("OnPointerExit")]
    class SimItemDisplay_OnPointerExit
    {
        static void Prefix(SimItemDisplay __instance)
        {
            Mod.Instance.ClearHoveredItem();
        }
    }
}
