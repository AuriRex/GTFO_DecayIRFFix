# Decay IRF NRE Fix

Fixes invalid IRF (InstancedRenderFeature) components on enemy prefabs (specifically on `tank_boss`) spamming NREs (NullReferenceExceptions) into the console whenever the ragdoll body starts decaying/despawning by removing said invalid components after the enemy prefab is generated for the first time.