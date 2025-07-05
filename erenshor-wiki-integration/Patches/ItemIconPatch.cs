using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace erenshor_wiki_integration.Patches
{
    [HarmonyPatch(typeof(ItemIcon))]
    [HarmonyPatch("OnPointerEnter")]
    class ItemIcon_OnPointerEnter
    {
        static void Prefix(ItemIcon __instance)
        {
            Mod.Instance.SetHoveredItem(__instance.MyItem);
        }
    }

    [HarmonyPatch(typeof(ItemIcon))]
    [HarmonyPatch("OnPointerExit")]
    class ItemIcon_OnPointerExit
    {
        static void Prefix(ItemIcon __instance)
        {
            Mod.Instance.ClearHoveredItem();
        }
    }
}
