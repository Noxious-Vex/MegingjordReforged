using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;

using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Registry;
using MegingjordReforged.Source.Utilities;

using System.Collections.Generic;


namespace MegingjordReforged.Source.Items
{
    public static class BeltItemManager
    {
        private static readonly Dictionary<string, CustomRecipe> RegisteredRecipes =
            new();



        private static bool _registered;



        /// <summary>
        /// Registers all belt recipes.
        ///
        /// Recipes are separate from prefab creation.
        /// This allows server synchronization
        /// to rebuild recipes safely.
        /// </summary>
        public static void RegisterRecipes()
        {
            if (_registered)
            {
                ModLogger.LogDebug(
                    "Recipes have already been registered."
                );

                return;
            }



            _registered = true;



            ModLogger.LogDebug(
                "Registering Megingjord Reforged recipes..."
            );



            foreach (
                BeltDefinition belt
                in BeltRegistry.Belts.Values)
            {
                RegisterRecipe(
                    belt
                );
            }



            ModLogger.LogDebug(
                "Finished registering belt recipes."
            );
        }



        /// <summary>
        /// Refreshes recipes after:
        ///
        /// - ServerSync changes
        /// - Leaving a server
        /// - Returning to local config
        ///
        /// </summary>
        public static void RefreshRecipes()
        {
            ModLogger.LogDebug(
                "Refreshing belt recipes..."
            );



            ClearRecipes();


            RegisterRecipes();



            ModLogger.LogDebug(
                "Finished refreshing belt recipes."
            );
        }



        /// <summary>
        /// Removes only recipes created
        /// by this mod.
        /// </summary>
        private static void ClearRecipes()
        {
            foreach (
                CustomRecipe recipe
                in RegisteredRecipes.Values)
            {
                ItemManager.Instance.RemoveRecipe(
                    recipe
                );
            }



            RegisteredRecipes.Clear();


            _registered = false;



            ModLogger.LogDebug(
                "Cleared Megingjord Reforged recipes."
            );
        }



        private static void RegisterRecipe(
            BeltDefinition belt)
        {
            IndividualBeltOptions options =
                ConfigResolveManager.GetBeltOptions(
                    belt.ConfigKey
                );



            if (options.CraftingStation ==
                CraftingStationType.Disabled)
            {
                ModLogger.LogDebug(
                    $"Recipe disabled: {belt.PrefabName}"
                );

                return;
            }



            string recipeName =
                $"Recipe_{belt.PrefabName}";



            RequirementConfig[] requirements =
                GetRequirements(
                    belt,
                    options
                );



            RecipeConfig config =
                new()
                {
                    Name =
                        recipeName,

                    Item =
                        belt.PrefabName,

                    Amount =
                        belt.Amount,

                    CraftingStation =
                        GetCraftingStation(
                            options
                        ),

                    MinStationLevel =
                        GetStationLevel(
                            options
                        ),

                    Requirements =
                        requirements
                };



            CustomRecipe recipe =
                new CustomRecipe(
                    config
                );



            if (!ItemManager.Instance.AddRecipe(recipe))
            {
                ModLogger.LogWarning(
                    $"Failed adding recipe: {recipeName}"
                );

                return;
            }



            RegisteredRecipes.Add(
                recipeName,
                recipe
            );



            ModLogger.LogInfo(
                $"Registered recipe: {recipeName}"
            );
        }



        private static RequirementConfig[] GetRequirements(
            BeltDefinition belt,
            IndividualBeltOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Recipe))
            {
                return belt.Requirements;
            }



            RequirementConfig[]? parsed =
                ConfigRecipeParser.ParseRecipe(
                    options.Recipe
                );



            if (parsed != null &&
                parsed.Length > 0)
            {
                ModLogger.LogDebug(
                    $"Using custom recipe for {belt.PrefabName}"
                );

                return parsed;
            }



            ModLogger.LogWarning(
                $"Invalid recipe override for {belt.PrefabName}. Using default."
            );



            return belt.Requirements;
        }



        private static string GetCraftingStation(
            IndividualBeltOptions options)
        {
            return options.CraftingStation switch
            {
                CraftingStationType.None =>
                    "",

                CraftingStationType.Workbench =>
                    "piece_workbench",

                CraftingStationType.Forge =>
                    "forge",

                CraftingStationType.Stonecutter =>
                    "piece_stonecutter",

                CraftingStationType.ArtisanTable =>
                    "piece_artisanstation",

                CraftingStationType.BlackForge =>
                    "blackforge",

                CraftingStationType.GaldrTable =>
                    "piece_magetable",

                _ =>
                    "piece_magetable"
            };
        }



        private static int GetStationLevel(
            IndividualBeltOptions options)
        {
            return options.CraftingStationLevel > 0
                ? options.CraftingStationLevel
                : 4;
        }
    }
}