using System;

using BepInEx.Configuration;

using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.Managers
{
    public static class ConfigManager
    {
        public static MegingjordConfig Current { get; private set; } = new();


        public static string ConfigPath { get; private set; } = string.Empty;



        public static void Load(
            ConfigFile configFile)
        {
            try
            {
                ConfigPath =
                    configFile.ConfigFilePath;



                configFile.Bind(
                    "General",
                    "Enable Mod",
                    true
                );


                configFile.Bind(
                    "Logging",
                    "Logging Mode",
                    ConfigLoggingMode.Standard
                );


                string[] beltOrder =
                {
                    "Aedigjord",
                    "Seidgjord",
                    "Skadigjord",
                    "Alagjord",
                    "Fornmegingjord"
                };


                foreach (string belt in beltOrder)
                {
                    configFile.Bind(
                        $"Belts - {belt}",
                        "Crafting Station",
                        CraftingStationType.GaldrTable
                    );
                }


                configFile.Bind(
                    "Advanced",
                    "Experimental Features",
                    false
                );



                Current =
                    new MegingjordConfig
                    {
                        General =
                            LoadGeneral(
                                configFile
                            ),

                        Logging =
                            LoadLogging(
                                configFile
                            ),

                        Belts =
                            LoadBelts(
                                configFile
                            ),

                        Advanced =
                            LoadAdvanced(
                                configFile
                            )
                    };


                ModLogger.LogDebug(
                    "Configuration loaded successfully."
                );
            }
            catch (Exception exception)
            {
                ModLogger.LogWarning(
                    $"Configuration failed to load. {exception.Message}"
                );


                Current =
                    new MegingjordConfig();
            }
        }



        private static ConfigGeneralOptions LoadGeneral(
            ConfigFile configFile)
        {
            return new ConfigGeneralOptions
            {
                EnableMod =
                    configFile.Bind(
                        "General",
                        "Enable Mod",
                        true
                    ).Value,


                EnableServerSync =
                    configFile.Bind(
                        "General",
                        "Enable Server Sync",
                        true
                    ).Value
            };
        }



        private static ConfigLoggingMode LoadLogging(
            ConfigFile configFile)
        {
            return configFile.Bind(
                "Logging",
                "Logging Mode",
                ConfigLoggingMode.Standard
            ).Value;
        }



        private static ConfigBeltOptions LoadBelts(
            ConfigFile configFile)
        {
            return new ConfigBeltOptions
            {
                Aedigjord =
                    LoadIndividualBelt(configFile, "Aedigjord"),

                Seidgjord =
                    LoadIndividualBelt(configFile, "Seidgjord"),

                Skadigjord =
                    LoadIndividualBelt(configFile, "Skadigjord"),

                Alagjord =
                    LoadIndividualBelt(configFile, "Alagjord"),

                Fornmegingjord =
                    LoadIndividualBelt(configFile, "Fornmegingjord")
            };
        }



        private static IndividualBeltOptions LoadIndividualBelt(
            ConfigFile configFile,
            string beltName)
        {
            return new IndividualBeltOptions
            {
                CraftingStation =
                    configFile.Bind(
                        $"Belts - {beltName}",
                        "Crafting Station",
                        CraftingStationType.GaldrTable
                    ).Value,


                CraftingStationLevel =
                    configFile.Bind(
                        $"Belts - {beltName}",
                        "Crafting Station Level",
                        4
                    ).Value,


                Recipe =
                    configFile.Bind(
                        $"Belts - {beltName}",
                        "Recipe",
                        string.Empty
                    ).Value,


                Effects =
                    LoadBeltEffects(
                        configFile,
                        beltName
                    )
            };
        }



        private static BeltEffectOptions LoadBeltEffects(
            ConfigFile configFile,
            string beltName)
        {
            return beltName switch
            {
                "Aedigjord" =>
                    LoadAedigjordEffects(configFile),

                "Seidgjord" =>
                    LoadSeidgjordEffects(configFile),

                "Skadigjord" =>
                    LoadSkadigjordEffects(configFile),

                "Alagjord" =>
                    LoadAlagjordEffects(configFile),

                "Fornmegingjord" =>
                    LoadFornmegingjordEffects(configFile),

                _ =>
                    LoadDefaultEffects()
            };
        }



        private static BeltEffectOptions LoadFornmegingjordEffects(
            ConfigFile configFile)
        {
            return new BeltEffectOptions
            {
                CarryWeight =
                    configFile.Bind(
                        "Belts - Fornmegingjord - Effects",
                        "Carry Weight",
                        450f
                    ).Value
            };
        }



        private static BeltEffectOptions LoadAedigjordEffects(
            ConfigFile configFile)
        {
            string section =
                "Belts - Aedigjord - Effects";


            return new BeltEffectOptions
            {
                CarryWeight =
                    LoadCarryWeight(
                        configFile,
                        section
                    ),

                Armor =
                    LoadArmor(
                        configFile,
                        section
                    ),

                HealthRegenModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Health Regen Modifier",
                        50f
                    ),

                AttackStaminaUseModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Attack Stamina Use Modifier",
                        -30f
                    )
            };
        }



        private static BeltEffectOptions LoadSeidgjordEffects(
            ConfigFile configFile)
        {
            string section =
                "Belts - Seidgjord - Effects";


            return new BeltEffectOptions
            {
                CarryWeight =
                    LoadCarryWeight(
                        configFile,
                        section
                    ),

                HealthRegenModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Health Regen Modifier",
                        25f
                    ),

                StaminaRegenModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Stamina Regen Modifier",
                        25f
                    ),

                EitrRegenModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Eitr Regen Modifier",
                        100f
                    )
            };
        }



        private static BeltEffectOptions LoadSkadigjordEffects(
            ConfigFile configFile)
        {
            string section =
                "Belts - Skadigjord - Effects";


            return new BeltEffectOptions
            {
                CarryWeight =
                    LoadCarryWeight(
                        configFile,
                        section
                    ),

                StaminaRegenModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Stamina Regen Modifier",
                        100f
                    ),

                RunStaminaUseModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Run Stamina Use Modifier",
                        -20f
                    ),

                JumpStaminaUseModifier =
                    LoadPercentage(
                        configFile,
                        section,
                        "Jump Stamina Use Modifier",
                        -10f
                    )
            };
        }



        private static BeltEffectOptions LoadAlagjordEffects(
            ConfigFile configFile)
        {
            return new BeltEffectOptions();
        }



        private static BeltEffectOptions LoadDefaultEffects()
        {
            return new BeltEffectOptions();
        }



        private static float LoadCarryWeight(
            ConfigFile configFile,
            string section)
        {
            return configFile.Bind(
                section,
                "Carry Weight",
                150f
            ).Value;
        }



        private static float LoadArmor(
            ConfigFile configFile,
            string section)
        {
            return configFile.Bind(
                section,
                "Armor",
                25f
            ).Value;
        }



        private static float LoadPercentage(
            ConfigFile configFile,
            string section,
            string key,
            float defaultValue)
        {
            return configFile.Bind(
                section,
                key,
                defaultValue
            ).Value;
        }



        private static ConfigAdvancedOptions LoadAdvanced(
            ConfigFile configFile)
        {
            return new ConfigAdvancedOptions
            {
                ExperimentalFeatures =
                    configFile.Bind(
                        "Advanced",
                        "Experimental Features",
                        false
                    ).Value
            };
        }
    }
}