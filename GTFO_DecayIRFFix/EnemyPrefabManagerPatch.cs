using Enemies;
using GameData;
using HarmonyLib;
using IRF;
using UnityEngine;

namespace DecayIRFFix;

[HarmonyPatch(typeof(EnemyPrefabManager), nameof(EnemyPrefabManager.BuildEnemyPrefab))]
public static class EnemyPrefabManagerPatch
{
    public static void Postfix(EnemyDataBlock data, ref GameObject __result)
    {
        var generatedEnemyPrefab = __result;
        
        var irfs = generatedEnemyPrefab.GetComponentsInChildren<InstancedRenderFeature>(includeInactive: true);

        foreach (var irf in irfs)
        {
            if (irf.Descriptor != null)
                continue;
            
            Plugin.L.LogDebug($"Found invalid IRF on enemy '{data.name}' (pID: {data.persistentID}), removing ...");
            UnityEngine.Object.Destroy(irf);
        }
    }
}