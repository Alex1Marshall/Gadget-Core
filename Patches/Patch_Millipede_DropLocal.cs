using HarmonyLib;
using GadgetCore.API;
using GadgetCore;
using UnityEngine;
using System.Reflection;

namespace GadgetCore.Patches
{
    [HarmonyPatch(typeof(Millipede))]
    [HarmonyPatch("DropLocal")]
    static class Patch_Millipede_DropLocal
    {
        [HarmonyPostfix]
        public static void Postfix(Millipede __instance)
        {
            LootTables.DropLoot("entity:" + __instance.name.Split(' ', '(')[0], __instance.transform.position);
        }
    }
}