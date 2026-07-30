using MegingjordReforged.Source.Config;


namespace MegingjordReforged.Source.Managers
{
    /// <summary>
    /// Resolves active runtime configuration values.
    ///
    /// Resolution order:
    ///
    /// 1. Server synchronization overrides.
    /// 2. Local BepInEx configuration.
    ///
    /// This is the only layer gameplay systems should
    /// query for runtime configuration.
    /// </summary>
    public static class ConfigResolveManager
    {
        public static bool HasServerOverrides =>
            RuntimeConfigOverride.Contains(
                "General.EnableMod"
            );



        public static T Get<T>(
            string key,
            T localValue)
        {
            return ServerSyncManager.GetValue(
                key,
                localValue
            );
        }



        public static IndividualBeltOptions GetBeltOptions(
            string beltName)
        {
            IndividualBeltOptions localOptions =
                ConfigManager.Current.Belts.GetBeltOptions(
                    beltName
                );


            return new IndividualBeltOptions
            {
                CraftingStation =
                    Get(
                        $"Belts.{beltName}.CraftingStation",
                        localOptions.CraftingStation
                    ),


                CraftingStationLevel =
                    Get(
                        $"Belts.{beltName}.CraftingStationLevel",
                        localOptions.CraftingStationLevel
                    ),


                Recipe =
                    Get(
                        $"Belts.{beltName}.Recipe",
                        localOptions.Recipe
                    ),


                Effects =
                    GetEffects(
                        beltName,
                        localOptions.Effects
                    )
            };
        }



        private static BeltEffectOptions GetEffects(
            string beltName,
            BeltEffectOptions localEffects)
        {
            return new BeltEffectOptions
            {
                CarryWeight =
                    Get(
                        $"Belts.{beltName}.Effects.CarryWeight",
                        localEffects.CarryWeight
                    ),


                Armor =
                    Get(
                        $"Belts.{beltName}.Effects.Armor",
                        localEffects.Armor
                    ),


                HealthRegenModifier =
                    Get(
                        $"Belts.{beltName}.Effects.HealthRegenModifier",
                        localEffects.HealthRegenModifier
                    ),


                StaminaRegenModifier =
                    Get(
                        $"Belts.{beltName}.Effects.StaminaRegenModifier",
                        localEffects.StaminaRegenModifier
                    ),


                EitrRegenModifier =
                    Get(
                        $"Belts.{beltName}.Effects.EitrRegenModifier",
                        localEffects.EitrRegenModifier
                    ),


                AttackStaminaUseModifier =
                    Get(
                        $"Belts.{beltName}.Effects.AttackStaminaUseModifier",
                        localEffects.AttackStaminaUseModifier
                    ),


                SwimStaminaUseModifier =
                    Get(
                        $"Belts.{beltName}.Effects.SwimStaminaUseModifier",
                        localEffects.SwimStaminaUseModifier
                    ),


                RunStaminaUseModifier =
                    Get(
                        $"Belts.{beltName}.Effects.RunStaminaUseModifier",
                        localEffects.RunStaminaUseModifier
                    ),


                JumpStaminaUseModifier =
                    Get(
                        $"Belts.{beltName}.Effects.JumpStaminaUseModifier",
                        localEffects.JumpStaminaUseModifier
                    ),


                DodgeStaminaUseModifier =
                    Get(
                        $"Belts.{beltName}.Effects.DodgeStaminaUseModifier",
                        localEffects.DodgeStaminaUseModifier
                    ),


                SneakStaminaUseModifier =
                    Get(
                        $"Belts.{beltName}.Effects.SneakStaminaUseModifier",
                        localEffects.SneakStaminaUseModifier
                    ),



                /*
                 * Skill Level Bonuses
                 */

                SwordSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.SwordSkillLevelIncrease",
                        localEffects.SwordSkillLevelIncrease
                    ),


                ClubSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.ClubSkillLevelIncrease",
                        localEffects.ClubSkillLevelIncrease
                    ),


                ElementalMagicSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.ElementalMagicSkillLevelIncrease",
                        localEffects.ElementalMagicSkillLevelIncrease
                    ),


                BloodMagicSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.BloodMagicSkillLevelIncrease",
                        localEffects.BloodMagicSkillLevelIncrease
                    ),


                BowSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.BowSkillLevelIncrease",
                        localEffects.BowSkillLevelIncrease
                    ),


                CrossbowSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.CrossbowSkillLevelIncrease",
                        localEffects.CrossbowSkillLevelIncrease
                    ),


                SwimmingSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.SwimmingSkillLevelIncrease",
                        localEffects.SwimmingSkillLevelIncrease
                    ),


                FishingSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.FishingSkillLevelIncrease",
                        localEffects.FishingSkillLevelIncrease
                    ),


                WoodcuttingSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.WoodcuttingSkillLevelIncrease",
                        localEffects.WoodcuttingSkillLevelIncrease
                    ),


                PickaxeSkillLevelIncrease =
                    Get(
                        $"Belts.{beltName}.Effects.PickaxeSkillLevelIncrease",
                        localEffects.PickaxeSkillLevelIncrease
                    ),


                AdrenalineGainModifier =
                    Get(
                        $"Belts.{beltName}.Effects.AdrenalineGainModifier",
                        localEffects.AdrenalineGainModifier
                    )
            };
        }
    }
}