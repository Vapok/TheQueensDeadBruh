using System;
using BepInEx.Configuration;
using HarmonyLib;
using TheQueensDeadBruh.Configuration;
using UnityEngine;
using Vapok.Common.Managers.Configuration;

namespace TheQueensDeadBruh.Features;

public class DisableMistlandsMistComponent
{
    public static bool FeatureInitialized = false;
    public static ConfigEntry<bool> EnableQueensDeadBruh;
    public static ConfigEntry<float> MistlandsTransparencyAmount;

    static DisableMistlandsMistComponent()
    {
        ConfigRegistry.Waiter.StatusChanged += (_, _) => RegisterConfigurationFile();
    }

    private static void RegisterConfigurationFile()
    {
        ConfigSyncBase.SyncedConfig("General Settings", "Enable The Queen's Dead Bruh", true,
            new ConfigDescription("When enabled, will lessen or Remove Mistland's Mist based on settings. This setting turns the mod off or on.",
                null,
                new ConfigurationManagerAttributes { Order = 1 }),ref EnableQueensDeadBruh);
        
        ConfigSyncBase.SyncedConfig<float>("General Settings", "Mistlands Mist Visibility Setting", 0.5f,
            new ConfigDescription("0 will disable Mistland's Mist altogether. 1 will make no changes, like mod is disabled.",
                new AcceptableValueRange<float>(0f, 1f),
                new ConfigurationManagerAttributes { Order = 2 }),ref MistlandsTransparencyAmount);
        
    }

    [HarmonyPatch(typeof(EnvMan), nameof(EnvMan.SetEnv))]
    public static class EnvManSetEnvPatch
    {
        private static void Prefix(ref EnvMan __instance, ref EnvSetup env)
        {
            if (EnableQueensDeadBruh.Value && MistlandsTransparencyAmount.Value <= 0.0001f)
            {
                if (ZoneSystem.instance == null || EnvMan.instance == null) return;

                if (ZoneSystem.instance.GetGlobalKey("defeated_queen"))
                {
                    SafeExecute("Mistlands_Globalmist",() =>GameObject.Find("_LocationList_Mistlands(Clone)/environment_effects/FollowPlayer/Mistlands_Globalmist").SetActive(false));
                    SafeExecute("Mistlands_Globalmist",() =>GameObject.Find("_LocationList_Mistlands/environment_effects/FollowPlayer/Mistlands_Globalmist").SetActive(false));
                }
            }
        }
    }

    [HarmonyPatch(typeof(ParticleMist), nameof(ParticleMist.Update))]
    public static class Patch_ParticleMist_Update
    {
        private static void Postfix(ParticleMist __instance)
        {
            if (EnableQueensDeadBruh.Value && MistlandsTransparencyAmount.Value > 0f && MistlandsTransparencyAmount.Value < 1f )
            {
                var mist = __instance.GetComponent<ParticleSystemRenderer>();

                if (mist != null)
                {
                    var material = mist.material;
                    var color = material.color;
                    color.a = MistlandsTransparencyAmount.Value;
                    material.color = color;
                }
            }
        }
    }
    
    private static void SafeExecute(string name, Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            TheQueensDeadBruh.Log.Debug($"Safe Execution Error Handled: for {name} - {ex.Message}\r\nStack Trace: {ex.StackTrace}");
        }
    }
}