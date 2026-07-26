using System.Collections.Generic;

using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Registry;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.Managers
{
    /// <summary>
    /// Provides synchronized configuration values
    /// from the authoritative server configuration.
    ///
    /// This manager does not perform networking.
    ///
    /// Responsibilities:
    ///
    /// - Read current server configuration.
    /// - Convert values into transferable strings.
    /// - Populate ServerSyncPackage.
    /// - Provide fallback values when required.
    ///
    /// Client-side application is handled separately
    /// through RuntimeConfigOverride.
    /// </summary>
    public static class ServerSyncDataProvider
    {
        private static readonly string[] BeltNames =
        {
            "Aedigjord",
            "Seidgjord",
            "Skadigjord",
            "Alagjord",
            "Fornmegingjord"
        };



        /// <summary>
        /// Creates a complete synchronization package.
        /// </summary>
        public static ServerSyncPackage CreatePackage()
        {
            ServerSyncPackage package =
                new ServerSyncPackage
                {
                    Version =
                        Plugin.ModVersion,

                    SchemaVersion =
                        VersionManager.SchemaVersion
                };



            Dictionary<string, string> values =
                GetServerValues();



            foreach (
                KeyValuePair<string, string> entry
                in values)
            {
                package.Values[entry.Key] =
                    entry.Value;
            }



            return package;
        }



        /// <summary>
        /// Generates all enabled synchronized values
        /// registered in ServerSyncRegistry.
        /// </summary>
        private static Dictionary<string, string> GetServerValues()
        {
            Dictionary<string, string> values =
                new();



            foreach (
                ServerSyncDefinition definition
                in ServerSyncRegistry.SyncDefinitions)
            {
                if (!definition.Enabled)
                {
                    continue;
                }



                if (TryGetValue(
                        definition.Identifier,
                        out string value))
                {
                    values[definition.Identifier] =
                        value;
                }
                else
                {
                    ModLogger.LogWarning(
                        $"Unable to resolve synchronized key '{definition.Identifier}'."
                    );


                    if (TryGetDefaultValue(
                            definition.Identifier,
                            out string defaultValue))
                    {
                        values[definition.Identifier] =
                            defaultValue;
                    }
                }
            }



            return values;
        }



        private static bool TryGetValue(
            string key,
            out string value)
        {
            value =
                string.Empty;



            switch (key)
            {
                case "General.EnableMod":

                    value =
                        ConfigManager.Current.General.EnableMod
                        .ToString();

                    return true;



                case "General.EnableServerSync":

                    value =
                        ConfigManager.Current.General.EnableServerSync
                        .ToString();

                    return true;



                case "Advanced.ExperimentalFeatures":

                    value =
                        ConfigManager.Current.Advanced.ExperimentalFeatures
                        .ToString();

                    return true;
            }



            foreach (
                string belt
                in BeltNames)
            {
                IndividualBeltOptions options =
                    ConfigManager.Current.Belts
                        .GetBeltOptions(
                            belt
                        );



                if (options == null)
                {
                    continue;
                }



                if (key ==
                    $"Belts.{belt}.Recipe")
                {
                    value =
                        options.Recipe;

                    return true;
                }



                if (key ==
                    $"Belts.{belt}.CraftingStation")
                {
                    value =
                        options.CraftingStation
                        .ToString();

                    return true;
                }



                if (key ==
                    $"Belts.{belt}.CraftingStationLevel")
                {
                    value =
                        options.CraftingStationLevel
                        .ToString();

                    return true;
                }



                foreach (
                    KeyValuePair<string, string> effect
                    in GetEffectValues(
                        belt,
                        options))
                {
                    if (key == effect.Key)
                    {
                        value =
                            effect.Value;

                        return true;
                    }
                }
            }



            return false;
        }



        private static Dictionary<string, string> GetEffectValues(
            string belt,
            IndividualBeltOptions options)
        {
            Dictionary<string, string> values =
                new();



            BeltEffectOptions effects =
                options.Effects;



            if (effects == null)
            {
                return values;
            }



            string prefix =
                $"Belts.{belt}.Effects.";



            values[$"{prefix}CarryWeight"] =
                effects.CarryWeight.ToString();


            values[$"{prefix}Armor"] =
                effects.Armor.ToString();


            values[$"{prefix}HealthRegenModifier"] =
                effects.HealthRegenModifier.ToString();


            values[$"{prefix}StaminaRegenModifier"] =
                effects.StaminaRegenModifier.ToString();


            values[$"{prefix}EitrRegenModifier"] =
                effects.EitrRegenModifier.ToString();


            values[$"{prefix}AttackStaminaUseModifier"] =
                effects.AttackStaminaUseModifier.ToString();


            values[$"{prefix}RunStaminaUseModifier"] =
                effects.RunStaminaUseModifier.ToString();


            values[$"{prefix}JumpStaminaUseModifier"] =
                effects.JumpStaminaUseModifier.ToString();


            values[$"{prefix}DodgeStaminaUseModifier"] =
                effects.DodgeStaminaUseModifier.ToString();


            values[$"{prefix}SneakStaminaUseModifier"] =
                effects.SneakStaminaUseModifier.ToString();


            values[$"{prefix}SwimStaminaUseModifier"] =
                effects.SwimStaminaUseModifier.ToString();



            return values;
        }



        private static bool TryGetDefaultValue(
            string key,
            out string value)
        {
            value =
                string.Empty;



            if (key.Contains(
                    "CraftingStationLevel"))
            {
                value =
                    "4";

                return true;
            }



            if (key.Contains(
                    "CraftingStation"))
            {
                value =
                    CraftingStationType.GaldrTable
                    .ToString();

                return true;
            }



            if (key.Contains(
                    "ExperimentalFeatures"))
            {
                value =
                    "false";

                return true;
            }



            return false;
        }
    }
}