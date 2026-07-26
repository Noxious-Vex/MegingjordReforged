using System;

using BepInEx;

using Jotunn.Managers;

using MegingjordReforged.Source.Items;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Registry;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string ModGUID =
            "NoxiousVex.MegingjordReforged";


        private const string ModName =
            "Megingjord Reforged: Enhanced Belt Variants";


        public const string ModAuthor = 
            "Noxious Vex";


        public const string ModVersion =
            "1.0.0";



        private void Awake()
        {
            try
            {
                ModLogger.LogStart(
                    "================================="
                );


                ModLogger.LogStart(
                    $"{ModName} : v{ModVersion} loading..."
                );



                /*
                 * Configuration loading.
                 */

                ConfigManager.Load(
                    Config
                );



                /*
                 * Internal migration verification.
                 *
                 * Uses the actual BepInEx
                 * configuration file path.
                 */

                VersionManager.Verify(
                    ConfigManager.ConfigPath
                );



                if (!ConfigManager.Current.General.EnableMod)
                {
                    ModLogger.LogWarning(
                        "Megingjord Reforged is disabled in configuration."
                    );

                    return;
                }


                /*
                 * Static definitions.
                 */

                BeltRegistry.RegisterBelts();


                /*
                 * Register synchronization schema.
                 */

                ServerSyncRegistry.RegisterSyncDefinitions();


                ServerSyncManager.Initialize();


                /*
                 * Wait for Jötunn vanilla prefabs.
                 */

                PrefabManager.OnVanillaPrefabsAvailable +=
                    InitializeAfterPrefabs;



                ModLogger.LogDebug(
                    "Waiting for vanilla prefab availability..."
                );
            }
            catch (Exception exception)
            {
                ModLogger.LogError(
                    $"{ModName} failed during initialization: {exception}"
                );


                ModLogger.LogStart(
                    "================================="
                );
            }
        }



        private static void InitializeAfterPrefabs()
        {
            try
            {
                ModLogger.LogDebug(
                    "Vanilla prefabs available. Initializing content..."
                );



                StatusEffectRegistry.RegisterStatusEffects();



                BeltPrefabManager.RegisterBelts();



                BeltItemManager.RegisterRecipes();



                ModLogger.LogStart(
                    $"{ModName} : v{ModVersion} by {ModAuthor} has loaded successfully."
                );


                ModLogger.LogStart(
                    "================================="
                );
            }
            catch (Exception exception)
            {
                ModLogger.LogError(
                    $"Prefab initialization failed: {exception}"
                );
            }
        }
    }
}