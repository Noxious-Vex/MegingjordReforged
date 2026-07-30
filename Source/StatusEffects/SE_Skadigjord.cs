using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.StatusEffects
{
    public class SE_Skadigjord : SE_Stats
    {
        public SE_Skadigjord()
        {
            name = "SE_Skadigjord";

            m_name = "Skadigjord";

            m_tooltip =
                "Light as the wind, granting unmatched speed and agility.";


            ApplyConfiguration();
        }



        /// <summary>
        /// Applies active runtime configuration.
        ///
        /// Called on creation and after
        /// server synchronization.
        /// </summary>
        public void ApplyConfiguration()
        {
            BeltEffectOptions effects =
                ConfigResolveManager.GetBeltOptions(
                    "Skadigjord"
                ).Effects;



            /*
             * Reset configurable values.
             */

            m_addMaxCarryWeight = 0f;

            m_staminaRegenMultiplier = 1f;

            m_runStaminaUseModifier = 0f;

            m_jumpStaminaUseModifier = 0f;

            m_dodgeStaminaUseModifier = 0f;

            m_sneakStaminaUseModifier = 0f;



            /*
             * Flat Effects
             */

            m_addMaxCarryWeight =
                ConfigValueConverter.Flat(
                    effects.CarryWeight,
                    0f,
                    500f
                );



            /*
             * Regeneration Effects
             */

            m_staminaRegenMultiplier =
                ConfigValueConverter.RegenMultiplier(
                    effects.StaminaRegenModifier
                );



            /*
             * Stamina Usage Effects
             */

            m_runStaminaUseModifier =
                ConfigValueConverter.PercentageToMultiplier(
                    effects.RunStaminaUseModifier
                );


            m_jumpStaminaUseModifier =
                ConfigValueConverter.PercentageToMultiplier(
                    effects.JumpStaminaUseModifier
                );


            m_dodgeStaminaUseModifier =
                ConfigValueConverter.PercentageToMultiplier(
                    effects.DodgeStaminaUseModifier
                );


            m_sneakStaminaUseModifier =
                ConfigValueConverter.PercentageToMultiplier(
                    effects.SneakStaminaUseModifier
                );



            /*
             * Permanent Skadigjord Effects
             */

            m_percentigeDamageModifiers.m_pierce =
                0.30f;



            /*
             * Skill Bonuses
             *
             * Skadigjord:
             *
             * +20 Bows
             * +35 Crossbows
             */

            m_skillLevel =
                Skills.SkillType.Bows;

            m_skillLevelModifier =
                effects.BowSkillLevelIncrease;


            m_skillLevel2 =
                Skills.SkillType.Crossbows;

            m_skillLevelModifier2 =
                effects.CrossbowSkillLevelIncrease;
        }
    }
}