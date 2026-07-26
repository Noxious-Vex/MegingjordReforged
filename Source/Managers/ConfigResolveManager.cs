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
        /// <summary>
        /// Determines whether runtime server overrides exist.
        /// </summary>
        public static bool HasServerOverrides =>
            RuntimeConfigOverride.Contains(
                "General.EnableMod"
            );



        /// <summary>
        /// Gets a runtime configuration value.
        ///
        /// Server values override local values.
        /// </summary>
        public static T Get<T>(
            string key,
            T localValue)
        {
            return ServerSyncManager.GetValue(
                key,
                localValue
            );
        }



        /// <summary>
        /// Gets active belt configuration.
        ///
        /// Supports:
        ///
        /// - Local configuration
        /// - Server synchronized overrides
        ///
        /// Effects are resolved individually so
        /// multiplayer servers can enforce balance.
        /// </summary>
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
                    )
            };
        }
    }
}