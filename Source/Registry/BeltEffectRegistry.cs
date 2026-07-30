using System.Collections.Generic;

using MegingjordReforged.Source.Definitions;


namespace MegingjordReforged.Source.Registry
{
    /// <summary>
    /// Stores all configurable effects available for each belt.
    ///
    /// Effects not registered here cannot be modified through configuration.
    /// Hard-coded effects remain controlled by their StatusEffect classes.
    /// </summary>
    public static class BeltEffectRegistry
    {
        private static readonly Dictionary<string, List<BeltEffectDefinition>> Effects =
            new();



        /// <summary>
        /// Registers all configurable belt effects.
        /// </summary>
        public static void RegisterEffects()
        {
            Effects.Clear();


            RegisterAedigjordEffects();


            RegisterAlagjordEffects();


            RegisterFornmegingjordEffects();


            RegisterSeidgjordEffects();


            RegisterSkadigjordEffects();
        }



        /// <summary>
        /// Retrieves configurable effects for a belt.
        /// </summary>
        public static IReadOnlyList<BeltEffectDefinition> GetEffects(
            string beltName)
        {
            if (Effects.TryGetValue(
                    beltName,
                    out List<BeltEffectDefinition>? effects))
            {
                return effects;
            }


            return new List<BeltEffectDefinition>();
        }



        private static void RegisterAedigjordEffects()
        {
            Effects["Aedigjord"] =
                new List<BeltEffectDefinition>
                {
                    new BeltEffectDefinition
                    {
                        EffectName = "addMaxCarryWeight",

                        DefaultValue = 250f,

                        MinimumValue = 0f,

                        MaximumValue = 500f,

                        AllowZero = true,

                        Description =
                            "Additional maximum carry weight."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "addArmor",

                        DefaultValue = 25f,

                        MinimumValue = 0f,

                        MaximumValue = 25f,

                        AllowZero = true,

                        Description =
                            "Additional armor granted by the belt."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "healthRegenMultiplier",

                        DefaultValue = -0.25f,

                        MinimumValue = -1.00f,

                        MaximumValue = 3.00f,

                        AllowZero = true,

                        Description =
                            "Health regeneration modifier."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "attackStaminaUseModifier",

                        DefaultValue = -0.50f,

                        MinimumValue = -0.01f,

                        MaximumValue = 1.00f,

                        AllowZero = true,

                        Description =
                            "Attack stamina consumption modifier."
                    },
                    ///
                    ///
                    new BeltEffectDefinition
                    {
                        EffectName = "SwordSkillLevelIncrease",

                        DefaultValue = 20f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Swords Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "ClubSkillLevelIncrease",

                        DefaultValue = 30f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Clubs Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "ElementalMagicSkillLevelIncrease",

                        DefaultValue = 30f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Elemental Magic Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "BloodMagicSkillLevelIncrease",

                        DefaultValue = 20f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Blood Magic Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "SwimmingSkillLevelIncrease",

                        DefaultValue = 35f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Swimming Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "FishingSkillLevelIncrease",

                        DefaultValue = 20f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Fishing Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "BowSkillLevelIncrease",

                        DefaultValue = 20f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Bows Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "CrossbowSkillLevelIncrease",

                        DefaultValue = 35f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Crossbows Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "WoodcuttingSkillLevelIncrease",

                        DefaultValue = 25f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Woodcutting Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "PickaxeSkillLevelIncrease",

                        DefaultValue = 25f,

                        MinimumValue = 0f,

                        MaximumValue = 99f,

                        AllowZero = true,

                        Description =
                            "Increases the Pickaxes (Mining) Skill level."
                    },


                    new BeltEffectDefinition
                    {
                        EffectName = "AdrenalineGainModifier",

                        DefaultValue = 100f,

                        MinimumValue = -100f,

                        MaximumValue = 500f,

                        AllowZero = true,

                        Description =
                            "Modifies the Adrenaline gain by percentage."
                    }
                };
        }



        private static void RegisterAlagjordEffects()
        {
            Effects["Alagjord"] =
                new List<BeltEffectDefinition>();
        }



        private static void RegisterFornmegingjordEffects()
        {
            Effects["Fornmegingjord"] =
                new List<BeltEffectDefinition>();
        }



        private static void RegisterSeidgjordEffects()
        {
            Effects["Seidgjord"] =
                new List<BeltEffectDefinition>();
        }



        private static void RegisterSkadigjordEffects()
        {
            Effects["Skadigjord"] =
                new List<BeltEffectDefinition>();
        }
    }
}