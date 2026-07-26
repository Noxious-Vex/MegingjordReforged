using Jotunn.Configs;

using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Utilities;

using System.Collections.Generic;


namespace MegingjordReforged.Source.Registry
{
    public static class BeltRegistry
    {
        public static readonly Dictionary<string, BeltDefinition> Belts = new();



        public static void RegisterBelts()
        {
            ModLogger.LogDebug(
                "Registering belt definitions..."
            );


            Belts.Clear();



            AddBelt(new BeltDefinition
            {
                ConfigKey = "Aedigjord",

                PrefabName = "MR_Aedigjord",

                DisplayName = "Aedigjord",

                Description =
                    "A reforged warrior's girdle infused with the fury of battle rage.",

                IconName = "Aedigjord.png",

                TextureName = "Aedigjord_d.png",

                Type = BeltType.BeltAedigjord,

                Requirements = new[]
                {
                    new RequirementConfig
                    {
                        Item = "BeltStrength",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneRed",
                        Amount = 3
                    }
                }
            });



            AddBelt(new BeltDefinition
            {
                ConfigKey = "Seidgjord",

                PrefabName = "MR_Seidgjord",

                DisplayName = "Seidgjord",

                Description =
                    "A mystical girdle empowered by ancient seiðr magic.",

                IconName = "Seidgjord.png",

                TextureName = "Seidgjord_d.png",

                Type = BeltType.BeltSeidgjord,

                Requirements = new[]
                {
                    new RequirementConfig
                    {
                        Item = "BeltStrength",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneRed",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneBlue",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "Eitr",
                        Amount = 20
                    }
                }
            });



            AddBelt(new BeltDefinition
            {
                ConfigKey = "Skadigjord",

                PrefabName = "MR_Skadigjord",

                DisplayName = "Skadigjord",

                Description =
                    "A hunter's girdle blessed with the swiftness of the wild.",

                IconName = "Skadigjord.png",

                TextureName = "Skadigjord_d.png",

                Type = BeltType.BeltSkadigjord,

                Requirements = new[]
                {
                    new RequirementConfig
                    {
                        Item = "BeltStrength",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneGreen",
                        Amount = 3
                    }
                }
            });



            AddBelt(new BeltDefinition
            {
                ConfigKey = "Alagjord",

                PrefabName = "MR_Alagjord",

                DisplayName = "Alagjord",

                Description =
                    "A sea-forged girdle granting mastery over the waves.",

                IconName = "Alagjord.png",

                TextureName = "Alagjord_d.png",

                Type = BeltType.BeltAlagjord,

                Requirements = new[]
                {
                    new RequirementConfig
                    {
                        Item = "BeltStrength",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneBlue",
                        Amount = 3
                    }
                }
            });



            AddBelt(new BeltDefinition
            {
                ConfigKey = "Fornmegingjord",

                PrefabName = "MR_Fornmegingjord",

                DisplayName = "Fornmegingjord",

                Description =
                    "An ancient relic containing the forgotten strength of Thor's Megingjord.",

                IconName = "Fornmegingjord.png",

                TextureName = "Fornmegingjord_d.png",

                Type = BeltType.BeltFornmegingjord,

                Requirements = new[]
                {
                    new RequirementConfig
                    {
                        Item = "BeltStrength",
                        Amount = 1
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneRed",
                        Amount = 3
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneBlue",
                        Amount = 3
                    },

                    new RequirementConfig
                    {
                        Item = "GemstoneGreen",
                        Amount = 3
                    }
                }
            });



            ModLogger.LogDebug(
                $"Registered {Belts.Count} belt definitions."
            );
        }



        private static void AddBelt(
            BeltDefinition belt)
        {
            Belts[belt.PrefabName] = belt;


            ModLogger.LogDebug(
                $"Added belt definition: {belt.PrefabName}"
            );
        }



        public static bool IsBelt(
            string prefabName)
        {
            return Belts.ContainsKey(
                prefabName
            );
        }



        public static BeltDefinition? GetBelt(
            string prefabName)
        {
            if (Belts.TryGetValue(
                    prefabName,
                    out BeltDefinition belt))
            {
                return belt;
            }


            return null;
        }
    }
}