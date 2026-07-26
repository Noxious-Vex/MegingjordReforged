using System;


namespace MegingjordReforged.Source.Definitions
{
    /// <summary>
    /// Defines a configurable effect attached to a Megingjord Reforged belt.
    ///
    /// Controls:
    /// - Whether the effect can be configured.
    /// - Default value when configuration is empty.
    /// - Minimum and maximum allowed values.
    /// - Whether zero is considered valid.
    ///
    /// All values are validated before being applied to gameplay.
    /// </summary>
    public class BeltEffectDefinition
    {
        /// <summary>
        /// Internal Valheim effect property name.
        ///
        /// Examples:
        /// addMaxCarryWeight
        /// addArmor
        /// healthRegenMultiplier
        /// attackStaminaUseModifier
        /// </summary>
        public string EffectName { get; set; } = string.Empty;



        /// <summary>
        /// Determines whether this effect can be modified through configuration.
        /// </summary>
        public bool Configurable { get; set; } = true;



        /// <summary>
        /// Default value used when no configuration override exists.
        /// </summary>
        public float DefaultValue { get; set; }



        /// <summary>
        /// Minimum allowed configuration value.
        /// </summary>
        public float MinimumValue { get; set; }



        /// <summary>
        /// Maximum allowed configuration value.
        /// </summary>
        public float MaximumValue { get; set; }



        /// <summary>
        /// Determines whether zero is a valid value.
        ///
        /// Example:
        /// addArmor = 0 removes the armor bonus.
        /// </summary>
        public bool AllowZero { get; set; } = true;



        /// <summary>
        /// Human-readable explanation of this effect.
        /// </summary>
        public string Description { get; set; } = string.Empty;



        /// <summary>
        /// Validates a configured value.
        ///
        /// If zero is not allowed and the user enters zero,
        /// the default value is restored.
        ///
        /// Values outside the allowed range are clamped.
        /// </summary>
        public float Validate(float value)
        {
            if (!AllowZero && value == 0f)
            {
                return DefaultValue;
            }


            if (value < MinimumValue)
            {
                return MinimumValue;
            }


            if (value > MaximumValue)
            {
                return MaximumValue;
            }


            return value;
        }
    }
}