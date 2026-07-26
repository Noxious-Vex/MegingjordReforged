using Jotunn.Entities;
using Jotunn.Managers;

using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Items;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.StatusEffects;
using MegingjordReforged.Source.Utilities;

using UnityEngine;


namespace MegingjordReforged.Source.Registry
{
    public static class StatusEffectRegistry
    {
        private static bool _registered;



        public static SE_Aedigjord? Aedigjord { get; private set; }

        public static SE_Seidgjord? Seidgjord { get; private set; }

        public static SE_Skadigjord? Skadigjord { get; private set; }

        public static SE_Alagjord? Alagjord { get; private set; }

        public static SE_Fornmegingjord? Fornmegingjord { get; private set; }



        /// <summary>
        /// Creates and registers all Megingjord Reforged
        /// status effects.
        ///
        /// Called once after vanilla prefabs are available.
        /// </summary>
        public static void RegisterStatusEffects()
        {
            if (_registered)
            {
                ModLogger.LogDebug(
                    "Status effects have already been registered."
                );

                return;
            }



            ModLogger.LogDebug(
                "Registering Megingjord Reforged status effects..."
            );



            Aedigjord =
                CreateEffect<SE_Aedigjord>(
                    "Aedigjord"
                );


            Seidgjord =
                CreateEffect<SE_Seidgjord>(
                    "Seidgjord"
                );


            Skadigjord =
                CreateEffect<SE_Skadigjord>(
                    "Skadigjord"
                );


            Alagjord =
                CreateEffect<SE_Alagjord>(
                    "Alagjord"
                );


            Fornmegingjord =
                CreateEffect<SE_Fornmegingjord>(
                    "Fornmegingjord"
                );



            _registered = true;



            ModLogger.LogDebug(
                "Completed status effect registration."
            );
        }



        /// <summary>
        /// Refreshes active status effect values
        /// after ServerSync changes.
        /// </summary>
        public static void RefreshStatusEffects()
        {
            if (!_registered)
            {
                ModLogger.LogWarning(
                    "Cannot refresh status effects before registration."
                );

                return;
            }



            ModLogger.LogDebug(
                "Refreshing Megingjord Reforged status effects..."
            );



            Aedigjord?
                .ApplyConfiguration();


            Seidgjord?
                .ApplyConfiguration();


            Skadigjord?
                .ApplyConfiguration();


            Alagjord?
                .ApplyConfiguration();


            Fornmegingjord?
                .ApplyConfiguration();



            ModLogger.LogDebug(
                "Finished refreshing status effects."
            );
        }



        /// <summary>
        /// Creates and registers a status effect.
        /// </summary>
        private static T? CreateEffect<T>(
            string configKey)
            where T : StatusEffect
        {
            if (!IsEnabled(configKey))
            {
                ModLogger.LogDebug(
                    $"Status effect disabled: {configKey}"
                );

                return null;
            }



            T effect =
                ScriptableObject.CreateInstance<T>();



            ApplyEffectIcon(
                effect,
                configKey
            );



            RegisterEffect(
                effect
            );



            return effect;
        }



        /// <summary>
        /// Assigns the same icon used by the belt item
        /// before Jötunn registers the status effect.
        /// </summary>
        private static void ApplyEffectIcon(
            StatusEffect effect,
            string configKey)
        {
            BeltDefinition? belt =
                BeltRegistry.GetBelt(
                    $"MR_{configKey}"
                );


            if (belt == null)
            {
                ModLogger.LogWarning(
                    $"Could not locate belt definition for status effect: {effect.name}"
                );

                return;
            }



            Sprite? icon =
                BeltIconManager.LoadIcon(
                    belt.IconName
                );



            if (icon == null)
            {
                ModLogger.LogWarning(
                    $"Could not load icon for status effect: {effect.name}"
                );

                return;
            }



            effect.m_icon =
                icon;



            ModLogger.LogDebug(
                $"Assigned status effect icon: {effect.name}"
            );
        }



        /// <summary>
        /// Registers status effect with Jötunn.
        /// </summary>
        private static void RegisterEffect(
            StatusEffect effect)
        {
            if (effect == null)
            {
                ModLogger.LogWarning(
                    "Attempted to register null status effect."
                );

                return;
            }



            if (effect.m_icon == null)
            {
                ModLogger.LogWarning(
                    $"Status effect {effect.name} registered without an icon."
                );
            }



            ItemManager.Instance.AddStatusEffect(
                new CustomStatusEffect(
                    effect,
                    true
                )
            );



            ModLogger.LogInfo(
                $"Registered status effect: {effect.name}"
            );
        }



        /// <summary>
        /// Determines whether a belt status effect
        /// should exist.
        ///
        /// Currently always enabled.
        /// </summary>
        private static bool IsEnabled(
            string configKey)
        {
            IndividualBeltOptions options =
                ConfigManager.Current.Belts.GetBeltOptions(
                    configKey
                );


            return true;
        }
    }
}