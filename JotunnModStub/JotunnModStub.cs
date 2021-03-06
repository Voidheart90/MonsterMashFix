// JotunnModStub
// a Valheim mod skeleton using Jötunn
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using BepInEx;
using Jotunn.Managers;
using UnityEngine;

namespace MonsterMashFix
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInDependency("Monsterzz")]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class JotunnModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.monstermashfix";
        public const string PluginName = "MonsterMashFix";
        public const string PluginVersion = "0.0.1";

        private void Awake()
        {
            //// Do all your init stuff here
            //// Acceptable value ranges can be defined to allow configuration via a slider in the BepInEx ConfigurationManager: https://github.com/BepInEx/BepInEx.ConfigurationManager
            //Config.Bind<int>("Main Section", "Example configuration integer", 1, new ConfigDescription("This is an example config, using a range limitation for ConfigurationManager", new AcceptableValueRange<int>(0, 100)));

            //// Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("ModStub has landed");
            PrefabManager.OnPrefabsRegistered += PrefabManager_OnPrefabsRegistered;
        }

        private void PrefabManager_OnPrefabsRegistered()
        {
            FixEarthTroll();
        }

        private void FixEarthTroll()
        {
            var prefab = PrefabManager.Instance.GetPrefab("EarthTroll");
            if (prefab != null)
            {
                Jotunn.Logger.LogMessage("Patching EarthTroll");
                prefab.AddComponent<CharacterDrop>();
            }
        }

#if DEBUG
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F6))
            { // Set a breakpoint here to break on F6 key press
            }
        }
#endif
    }
}