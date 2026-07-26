using System;
using System.Collections.Generic;

using Jotunn.Configs;

using MegingjordReforged.Source.Utilities;

namespace MegingjordReforged.Source.Config
{
    /// <summary>
    /// Parses custom crafting recipe overrides supplied through
    /// Megingjord Reforged configuration.
    ///
    /// Format:
    ///
    /// ItemPrefab:Amount,ItemPrefab:Amount
    ///
    /// Example:
    ///
    /// BeltStrength:1,GemstoneRed:5
    ///
    /// </summary>
    public static class ConfigRecipeParser
    {
        /// <summary>
        /// Attempts to parse a custom recipe override.
        ///
        /// Returns null when:
        /// - No recipe override exists.
        /// - No valid ingredients were found.
        ///
        /// </summary>
        public static RequirementConfig[]? ParseRecipe(
            string recipeString)
        {
            if (string.IsNullOrWhiteSpace(recipeString))
            {
                return null;
            }


            List<RequirementConfig> requirements =
                new List<RequirementConfig>();


            string[] entries =
                recipeString.Split(
                    new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries
                );


            foreach (string rawEntry in entries)
            {
                string entry =
                    rawEntry.Trim();


                string[] values =
                    entry.Split(
                        new[] { ':' },
                        StringSplitOptions.RemoveEmptyEntries
                    );


                if (values.Length != 2)
                {
                    ModLogger.LogWarning(
                        $"Invalid recipe entry '{entry}'. Expected ItemPrefab:Amount."
                    );

                    continue;
                }


                string item =
                    values[0].Trim();


                string amountString =
                    values[1].Trim();


                if (string.IsNullOrWhiteSpace(item))
                {
                    ModLogger.LogWarning(
                        $"Invalid recipe entry '{entry}'. Item name cannot be empty."
                    );

                    continue;
                }


                if (!int.TryParse(
                        amountString,
                        out int amount))
                {
                    ModLogger.LogWarning(
                        $"Invalid recipe entry '{entry}'. Amount must be numeric."
                    );

                    continue;
                }


                if (amount <= 0)
                {
                    ModLogger.LogWarning(
                        $"Invalid recipe entry '{entry}'. Amount must be greater than zero."
                    );

                    continue;
                }


                requirements.Add(
                    new RequirementConfig
                    {
                        Item = item,
                        Amount = amount
                    }
                );
            }


            if (requirements.Count == 0)
            {
                ModLogger.LogWarning(
                    "Recipe override contained no valid ingredients. Default recipe will be used."
                );

                return null;
            }


            ModLogger.LogDebug(
                $"Parsed custom recipe with {requirements.Count} ingredient(s)."
            );


            return requirements.ToArray();
        }
    }
}