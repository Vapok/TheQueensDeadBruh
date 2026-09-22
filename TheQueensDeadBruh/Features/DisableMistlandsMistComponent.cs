using System;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Managers;
using TheQueensDeadBruh.Configuration;
using UnityEngine;
using Vapok.Common.Managers.Configuration;

namespace TheQueensDeadBruh.Features;

public class DisableMistlandsMistComponent
{
    private const float QueenCheckIntervalSeconds = 2.0f;
    private const float ZeroMistThreshold = 0.0001f;

    public static bool FeatureInitialized = false;
    public static ConfigEntry<bool> EnableQueensDeadBruh;
    public static ConfigEntry<float> MistlandsTransparencyAmount;

    private static float _nextQueenCheckTime;
    private static bool _isQueenDeadCached;
    private static ParticleMist _lastParticleMist;
    private static ParticleSystemRenderer _cachedRenderer;
    private static Material _cachedMaterial;
    private static ParticleSystem _cachedParticleSystem;

    static DisableMistlandsMistComponent()
    {
        ConfigRegistry.Waiter.StatusChanged += (_, _) => RegisterConfigurationFile();
    }

    private static void RegisterConfigurationFile()
    {
        ConfigSyncBase.SyncedConfig("General Settings", "Enable The Queen's Dead Bruh", true,
            new ConfigDescription("When enabled, will lessen or Remove Mistland's Mist based on settings. This setting turns the mod off or on.",
                null,
                new ConfigurationManagerAttributes { Order = 1 }), ref EnableQueensDeadBruh);
        
        ConfigSyncBase.SyncedConfig<float>("General Settings", "Mistlands Mist Visibility Setting", 0.5f,
            new ConfigDescription("0 will disable Mistland's Mist altogether. 1 will make no changes, like mod is disabled.",
                new AcceptableValueRange<float>(0f, 1f),
                new ConfigurationManagerAttributes { Order = 2 }), ref MistlandsTransparencyAmount);

        if (EnableQueensDeadBruh != null)
        {
            EnableQueensDeadBruh.SettingChanged += (_, _) => OnSettingChanged();
        }

        if (MistlandsTransparencyAmount != null)
        {
            MistlandsTransparencyAmount.SettingChanged += (_, _) => OnSettingChanged();
        }
    }

    public static void Reset()
    {
        _nextQueenCheckTime = 0f;
        _isQueenDeadCached = false;
        _lastParticleMist = null;
        _cachedRenderer = null;
        _cachedMaterial = null;
        _cachedParticleSystem = null;
    }

    private static bool IsQueenDead()
    {
        float now = Time.time;
        if (now < _nextQueenCheckTime)
        {
            return _isQueenDeadCached;
        }

        _nextQueenCheckTime = now + QueenCheckIntervalSeconds;
        _isQueenDeadCached = ZoneSystem.instance != null && ZoneSystem.instance.GetGlobalKey("defeated_queen");
        return _isQueenDeadCached;
    }

    private static void OnSettingChanged()
    {
        if (GUIManager.IsHeadless())
            return;

        if (_lastParticleMist == null || _cachedMaterial == null)
            return;

        float targetAlpha = (EnableQueensDeadBruh != null && EnableQueensDeadBruh.Value && IsQueenDead())
            ? Mathf.Clamp01(MistlandsTransparencyAmount != null ? MistlandsTransparencyAmount.Value : 1.0f)
            : 1.0f;

        Color color = _cachedMaterial.color;
        if (!Mathf.Approximately(color.a, targetAlpha))
        {
            color.a = targetAlpha;
            _cachedMaterial.color = color;
        }

        if (ParticleMist.instance != null && !ParticleMist.instance.gameObject.activeSelf)
        {
            if (EnableQueensDeadBruh == null || !EnableQueensDeadBruh.Value || !IsQueenDead() || (MistlandsTransparencyAmount != null && MistlandsTransparencyAmount.Value > ZeroMistThreshold))
            {
                ParticleMist.instance.gameObject.SetActive(true);
            }
        }
    }

    private static void ApplyTransparency(ParticleMist instance, float targetAlpha)
    {
        if (instance != _lastParticleMist || _cachedRenderer == null)
        {
            _lastParticleMist = instance;
            _cachedRenderer = instance.GetComponent<ParticleSystemRenderer>();
            _cachedMaterial = _cachedRenderer != null ? _cachedRenderer.material : null;
        }

        if (_cachedMaterial != null)
        {
            Color color = _cachedMaterial.color;
            if (!Mathf.Approximately(color.a, targetAlpha))
            {
                color.a = targetAlpha;
                _cachedMaterial.color = color;
            }
        }
    }

    [HarmonyPatch(typeof(EnvMan), nameof(EnvMan.SetEnv))]
    private static class EnvManSetEnvPatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static void Prefix()
        {
            if (EnableQueensDeadBruh == null || !EnableQueensDeadBruh.Value || MistlandsTransparencyAmount == null || MistlandsTransparencyAmount.Value > ZeroMistThreshold)
                return;

            if (IsQueenDead() && ParticleMist.instance != null && ParticleMist.instance.gameObject.activeSelf)
            {
                ParticleMist.instance.gameObject.SetActive(false);
            }
        }
    }

    [HarmonyPatch(typeof(ParticleMist), nameof(ParticleMist.Update))]
    private static class Patch_ParticleMist_Update
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static bool Prefix(ParticleMist __instance)
        {
            if (EnableQueensDeadBruh != null && EnableQueensDeadBruh.Value && MistlandsTransparencyAmount != null && MistlandsTransparencyAmount.Value <= ZeroMistThreshold && IsQueenDead())
            {
                if (_cachedParticleSystem == null || _lastParticleMist != __instance)
                {
                    _cachedParticleSystem = __instance.GetComponent<ParticleSystem>();
                }

                if (_cachedParticleSystem != null && _cachedParticleSystem.particleCount > 0)
                {
                    _cachedParticleSystem.Clear();
                }
                return false;
            }

            return true;
        }

        private static void Postfix(ParticleMist __instance)
        {
            if (EnableQueensDeadBruh == null || !EnableQueensDeadBruh.Value || MistlandsTransparencyAmount == null || MistlandsTransparencyAmount.Value <= ZeroMistThreshold || MistlandsTransparencyAmount.Value >= 1.0f)
                return;

            if (!IsQueenDead())
                return;

            ApplyTransparency(__instance, MistlandsTransparencyAmount.Value);
        }
    }
}
