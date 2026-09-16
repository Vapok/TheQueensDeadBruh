/* NoFogBruh by Vapok */

using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using JetBrains.Annotations;
using Jotunn.Utils;
using TheQueensDeadBruh.Configuration;
using TheQueensDeadBruh.Features;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Managers.LocalizationManager;
using Vapok.Common.Managers.Splash;

namespace TheQueensDeadBruh
{
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInDependency("com.ValheimModding.YamlDotNetDetector")]
    [BepInPlugin(_pluginId, _displayName, _version)]
    [SynchronizationMode(AdminOnlyStrictness.IfOnServer)]
    public class TheQueensDeadBruh : BaseUnityPlugin, IPluginInfo
    {
        //Module Constants
        private const string _pluginId = "vapok.mods.thequeensdeadbruh";
        private const string _displayName = "The Queens Dead Bruh!";
        private const string _version = "2.0.4";
        
        //Interface Properties
        public string PluginId => _pluginId;
        public string DisplayName => _displayName;
        public string Version => _version;
        public BaseUnityPlugin Instance => _instance;
        
        //Class Properties
        public static ILogIt Log => _log;
        public static bool ValheimAwake;
        public static Waiting Waiter;
        
        //Class Privates
        private static TheQueensDeadBruh _instance;
        private static ConfigSyncBase _config;
        private static ILogIt _log;
        private Harmony _harmony;
        
        [UsedImplicitly]
        // This the main function of the mod. BepInEx will call this.
        private void Awake()
        {
            //I'm awake!
            _instance = this;
            
            //Waiting For Startup
            Waiter = new Waiting();
            
            //Jotunn Localization
            var localization = Jotunn.Managers.LocalizationManager.Instance.GetLocalization();

            //Register Logger
            LogManager.Init(PluginId,out _log);
            
            //Initialize Managers
            Localizer.Init(localization);

            //Register Configuration Settings
            _config = new ConfigRegistry(_instance);

            ModSplashManager.Register(new ModSplashDossier(_instance)
            {
                Tagline = "Disables Mistlands mist globally once the Queen boss has been defeated in the world.",
                ShowOnStartup = ConfigRegistry.ShowSplashOnStartup,
                EnableTelemetry = ConfigRegistry.EnableTelemetry,
            });

            Localizer.Waiter.StatusChanged += InitializeModule;
            
            //Register Features
            DisableMistlandsMistComponent.FeatureInitialized = true;
            
            //Patch Harmony
            _harmony = new Harmony(Info.Metadata.GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            //???

            //Profit
        }

        public void InitializeModule(object send, EventArgs args)
        {
            if (ValheimAwake)
                return;
            
            ConfigRegistry.Waiter.ConfigurationComplete(true);

            ValheimAwake = true;
        }
        
        private void OnDestroy()
        {
            _instance = null;
        }

        public class Waiting
        {
            public void ValheimIsAwake(bool awakeFlag)
            {
                if (awakeFlag)
                    StatusChanged?.Invoke(this, EventArgs.Empty);
            }
            public event EventHandler StatusChanged;            
        }
    }
}
