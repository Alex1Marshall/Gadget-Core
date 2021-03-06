using HarmonyLib;
using GadgetCore.API;
using UnityEngine;
using System.IO;
using UModFramework.API;
using System.Collections;

namespace GadgetCore.Patches
{
    [HarmonyPatch(typeof(GameScript))]
    [HarmonyPatch("Awake")]
    static class Patch_GameScript_Awake
    {
        [HarmonyPrefix]
        public static void Prefix(GameScript __instance)
        {
            InstanceTracker.GameScript = __instance;
            GadgetCore.GenerateSpriteSheet();
            GadgetUtils.SafeCopyTexture(__instance.TileManager.GetComponent<ChunkWorld>().Texture, 0, 0, 0, 0, 128, 128, GadgetCoreAPI.spriteSheet, 0, 0, 0, 0);
            __instance.TileManager.GetComponent<ChunkWorld>().Texture = GadgetCoreAPI.spriteSheet;
            __instance.WallManager.GetComponent<ChunkWorld>().Texture = GadgetCoreAPI.spriteSheet;
            foreach (GadgetModInfo mod in GadgetMods.ListAllModInfos())
            {
                __instance.gameObject.AddComponent<GadgetModHookScript>().Mod = mod;
            }
        }
    }
}