using UnityEngine;


namespace MegingjordReforged.Source.Utilities
{
    /// <summary>
    /// Handles conversion and validation of user-defined
    /// configuration values before they are applied
    /// to Valheim systems.
    ///
    /// Configuration values are stored as readable
    /// percentage values.
    ///
    /// Example:
    ///
    /// Config:
    /// Health Regen Modifier = -25
    ///
    /// Converted:
    /// 0.75f
    ///
    /// Valheim regeneration systems use multipliers:
    ///
    /// 1.00 = Normal
    /// 1.50 = +50%
    /// 3.50 = +250%
    /// 0.75 = -25%
    ///
    /// Stamina consumption systems use direct
    /// percentage modifiers:
    ///
    /// -35 = -35% usage
    /// </summary>
    public static class ConfigValueConverter
    {



        /*
         * Regen Conversion
         *
         * Used for:
         *
         * - Health regeneration
         * - Stamina regeneration
         * - Eitr regeneration
         *
         * Examples:
         *
         * -25 -> 0.75
         * 50  -> 1.50
         * 250 -> 3.50
         *
         */

        public static float RegenMultiplier(
            float percentage)
        {
            return 1f + (percentage / 100f);
        }



        /*
         * Regen Conversion
         *
         * With balance limits.
         */

        public static float RegenMultiplier(
            float percentage,
            float minimum,
            float maximum)
        {
            float clampedValue =
                Mathf.Clamp(
                    percentage,
                    minimum,
                    maximum
                );


            return RegenMultiplier(
                clampedValue
            );
        }



        /*
         * Usage Conversion
         *
         * Used for:
         *
         * - Attack stamina
         * - Run stamina
         * - Jump stamina
         * - Dodge stamina
         * - Sneak stamina
         *
         * Examples:
         *
         * -35 -> -0.35
         * 0   -> 0
         *
         */

        public static float PercentageToMultiplier(
            float percentage)
        {
            return percentage / 100f;
        }



        /*
         * Generic compatibility wrapper.
         *
         * Existing code using Multiplier()
         * continues to compile.
         *
         * Intended for usage modifiers.
         */

        public static float Multiplier(
            float percentage)
        {
            return PercentageToMultiplier(
                percentage
            );
        }



        /*
         * Generic compatibility wrapper
         * with limits.
         */

        public static float Multiplier(
            float percentage,
            float minimum,
            float maximum)
        {
            float clampedValue =
                Mathf.Clamp(
                    percentage,
                    minimum,
                    maximum
                );


            return PercentageToMultiplier(
                clampedValue
            );
        }



        /*
         * Flat value conversion.
         *
         * Used for:
         *
         * - Carry weight
         * - Armor
         * - Flat bonuses
         */

        public static float Flat(
            float value,
            float minimum,
            float maximum)
        {
            return Mathf.Clamp(
                value,
                minimum,
                maximum
            );
        }
    }
}