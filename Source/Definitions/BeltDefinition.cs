using System;

using Jotunn.Configs;

namespace MegingjordReforged.Source.Definitions
{
    /// <summary>
    /// Defines a Megingjord Reforged belt variant.
    ///
    /// Contains all static information required to register
    /// the belt prefab, recipe, and associated systems.
    /// </summary>
    public class BeltDefinition
    {
        /// <summary>
        /// Configuration key used to locate this belt's settings.
        ///
        /// Example:
        /// Aedigjord
        ///
        /// Maps to:
        /// ConfigManager.Current.Belts.Aedigjord
        /// </summary>
        public string ConfigKey { get; set; } = string.Empty;



        /// <summary>
        /// Internal prefab name.
        /// </summary>
        public string PrefabName { get; set; } = string.Empty;



        /// <summary>
        /// Display name shown in-game.
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;



        /// <summary>
        /// Belt description shown in item information.
        /// </summary>
        public string Description { get; set; } = string.Empty;



        /// <summary>
        /// Icon asset name.
        /// </summary>
        public string IconName { get; set; } = string.Empty;



        /// <summary>
        /// Texture asset name.
        /// </summary>
        public string TextureName { get; set; } = string.Empty;



        /// <summary>
        /// Belt classification.
        /// </summary>
        public BeltType Type { get; set; }



        /// <summary>
        /// Default crafting requirements.
        ///
        /// These may later be overridden by configuration.
        /// </summary>
        public RequirementConfig[] Requirements { get; set; } =
            Array.Empty<RequirementConfig>();



        /// <summary>
        /// Default crafting amount.
        /// </summary>
        public int Amount { get; set; } = 1;
    }



    /// <summary>
    /// Identifies the type of Megingjord Reforged belt.
    /// </summary>
    public enum BeltType
    {
        BeltAedigjord,

        BeltAlagjord,

        BeltFornmegingjord,

        BeltSeidgjord,

        BeltSkadigjord
    }
}