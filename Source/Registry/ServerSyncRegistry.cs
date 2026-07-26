using System.Collections.Generic;

using MegingjordReforged.Source.Definitions;


namespace MegingjordReforged.Source.Registry
{
    /// <summary>
    /// Defines all configuration values allowed to synchronize
    /// from server to connected clients.
    ///
    /// This registry is the authoritative list of synchronized
    /// configuration identifiers.
    ///
    /// Values not registered here remain client-local.
    /// </summary>
    public static class ServerSyncRegistry
    {
        private static readonly List<ServerSyncDefinition> Definitions =
            new();



        /// <summary>
        /// Returns all registered synchronization definitions.
        /// </summary>
        public static IReadOnlyList<ServerSyncDefinition> SyncDefinitions =>
            Definitions;



        /// <summary>
        /// Returns all enabled synchronization identifiers.
        ///
        /// This replaces the previous ServerSyncDataManager
        /// GetSyncedKeys() functionality.
        ///
        /// Only definitions marked Enabled are transmitted.
        /// </summary>
        public static IReadOnlyCollection<string> GetSyncedKeys()
        {
            List<string> keys =
                new();


            foreach (
                ServerSyncDefinition definition
                in Definitions)
            {
                if (!definition.Enabled)
                {
                    continue;
                }


                keys.Add(
                    definition.Identifier
                );
            }


            return keys;
        }



        /// <summary>
        /// Registers all configuration values that may synchronize.
        /// </summary>
        public static void RegisterSyncDefinitions()
        {
            Definitions.Clear();


            RegisterGeneral();


            RegisterBelts();


            RegisterBeltEffects();


            RegisterAdvanced();
        }



        /// <summary>
        /// Registers general server controlled settings.
        /// </summary>
        private static void RegisterGeneral()
        {
            Register(
                "General",
                "Enable Mod",
                "General.EnableMod"
            );


            Register(
                "General",
                "Enable Server Sync",
                "General.EnableServerSync"
            );
        }



        /// <summary>
        /// Registers belt configuration values.
        ///
        /// Belt existence is not synchronized.
        /// Prefabs are always registered.
        ///
        /// Server controls:
        ///
        /// - Recipe availability
        /// - Crafting location
        /// - Crafting station level
        /// </summary>
        private static void RegisterBelts()
        {
            string[] belts =
            {
                "Aedigjord",
                "Seidgjord",
                "Skadigjord",
                "Alagjord",
                "Fornmegingjord"
            };



            foreach (string belt in belts)
            {
                Register(
                    $"Belts - {belt}",
                    "Recipe",
                    $"Belts.{belt}.Recipe"
                );


                Register(
                    $"Belts - {belt}",
                    "Crafting Station",
                    $"Belts.{belt}.CraftingStation"
                );


                Register(
                    $"Belts - {belt}",
                    "Crafting Station Level",
                    $"Belts.{belt}.CraftingStationLevel"
                );
            }
        }



        /// <summary>
        /// Registers individual belt effect values.
        ///
        /// Individual keys are used intentionally.
        ///
        /// This allows selective synchronization
        /// using ServerSyncDefinition.Enabled.
        /// </summary>
        private static void RegisterBeltEffects()
        {
            string[] belts =
            {
                "Aedigjord",
                "Seidgjord",
                "Skadigjord",
                "Alagjord",
                "Fornmegingjord"
            };



            foreach (string belt in belts)
            {
                RegisterEffect(
                    belt,
                    "Carry Weight",
                    "CarryWeight"
                );


                RegisterEffect(
                    belt,
                    "Armor",
                    "Armor"
                );


                RegisterEffect(
                    belt,
                    "Health Regen Modifier",
                    "HealthRegenModifier"
                );


                RegisterEffect(
                    belt,
                    "Stamina Regen Modifier",
                    "StaminaRegenModifier"
                );


                RegisterEffect(
                    belt,
                    "Eitr Regen Modifier",
                    "EitrRegenModifier"
                );


                RegisterEffect(
                    belt,
                    "Attack Stamina Use Modifier",
                    "AttackStaminaUseModifier"
                );


                RegisterEffect(
                    belt,
                    "Swim Stamina Use Modifier",
                    "SwimStaminaUseModifier"
                );


                RegisterEffect(
                    belt,
                    "Run Stamina Use Modifier",
                    "RunStaminaUseModifier"
                );


                RegisterEffect(
                    belt,
                    "Jump Stamina Use Modifier",
                    "JumpStaminaUseModifier"
                );


                RegisterEffect(
                    belt,
                    "Dodge Stamina Use Modifier",
                    "DodgeStaminaUseModifier"
                );


                RegisterEffect(
                    belt,
                    "Sneak Stamina Use Modifier",
                    "SneakStaminaUseModifier"
                );
            }
        }



        /// <summary>
        /// Registers a single belt effect synchronization value.
        /// </summary>
        private static void RegisterEffect(
            string belt,
            string displayName,
            string effectKey)
        {
            Register(
                $"Belts - {belt} - Effects",
                displayName,
                $"Belts.{belt}.Effects.{effectKey}"
            );
        }



        /// <summary>
        /// Registers advanced server options.
        /// </summary>
        private static void RegisterAdvanced()
        {
            Register(
                "Advanced",
                "Experimental Features",
                "Advanced.ExperimentalFeatures"
            );
        }



        /// <summary>
        /// Creates a synchronization definition.
        ///
        /// Enabled controls whether this specific value
        /// participates in synchronization.
        /// </summary>
        private static void Register(
            string section,
            string key,
            string identifier)
        {
            Definitions.Add(
                new ServerSyncDefinition
                {
                    Section = section,

                    Key = key,

                    Identifier = identifier,

                    Enabled = true
                }
            );
        }
    }
}