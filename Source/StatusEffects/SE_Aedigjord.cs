using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Utilities;
using UnityEngine;


namespace MegingjordReforged.Source.StatusEffects
{
    public class SE_Aedigjord : SE_Stats
    {
        public SE_Aedigjord()
        {
            name = "SE_Aedigjord";

            m_name = "Aedigjord";

            m_tooltip =
                "Fueled by fury and the strength of forgotten heroes.";


            ApplyConfiguration();
        }



        /// <summary>
        /// Applies active runtime configuration.
        ///
        /// This can be called after ServerSync updates
        /// so server-authoritative values are applied
        /// without recreating the status effect.
        /// </summary>
        public void ApplyConfiguration()
        {
            BeltEffectOptions effects =
                ConfigResolveManager.GetBeltOptions(
                    "Aedigjord"
                ).Effects;



            /*
             * Reset configurable values first.
             *
             * Prevents stale values after switching
             * servers or clearing overrides.
             */

            m_addMaxCarryWeight = 0f;

            m_addArmor = 0f;

            m_healthRegenMultiplier = 1f;

            m_attackStaminaUseModifier = 0f;



            /*
             * Configurable Effects
             */

            m_addMaxCarryWeight =
                ConfigValueConverter.Flat(
                    effects.CarryWeight,
                    0f,
                    500f
                );


            m_addArmor =
                ConfigValueConverter.Flat(
                    effects.Armor,
                    0f,
                    25f
                );


            m_healthRegenMultiplier =
                ConfigValueConverter.RegenMultiplier(
                    effects.HealthRegenModifier
                );


            m_attackStaminaUseModifier =
                ConfigValueConverter.PercentageToMultiplier(
                    effects.AttackStaminaUseModifier
                );



            /*
             * Permanent Aedigjord Effects
             */

            m_percentigeDamageModifiers.m_slash =
                0.20f;


            m_percentigeDamageModifiers.m_blunt =
                0.30f;



            /*
             * Skill Bonuses
             */

            m_skillLevel =
                Skills.SkillType.Clubs;

            m_skillLevelModifier =
                effects.ClubSkillLevelIncrease;


            m_skillLevel2 =
                Skills.SkillType.Swords;

            m_skillLevelModifier2 =
                effects.SwordSkillLevelIncrease;



            /*
             * Adrenaline Gain
             *
             * +100%
             */

            m_adrenalineModifier =
                ConfigValueConverter.PercentageToMultiplier(Mathf.Clamp(effects.AdrenalineGainModifier,
                    -50f,
                    500f
                )
            );
        }
    }
}