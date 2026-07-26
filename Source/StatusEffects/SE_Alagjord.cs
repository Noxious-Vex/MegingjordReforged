using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.StatusEffects
{
    public class SE_Alagjord : SE_Stats
    {
        public SE_Alagjord()
        {
            name = "SE_Alagjord";

            m_name = "Alagjord";

            m_tooltip =
                "Its wearer moves as freely as the waves themselves.";


            ApplyConfiguration();
        }



        /// <summary>
        /// Applies active runtime configuration.
        ///
        /// Called during creation and after
        /// ServerSync updates.
        /// </summary>
        public void ApplyConfiguration()
        {
            BeltEffectOptions effects =
                ConfigResolveManager.GetBeltOptions(
                    "Alagjord"
                ).Effects;



            /*
             * Reset configurable values.
             */

            m_addMaxCarryWeight = 0f;

            m_staminaRegenMultiplier = 1f;

            m_swimStaminaUseModifier = 0f;



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
             * Stamina Regeneration
             */

            m_staminaRegenMultiplier =
                ConfigValueConverter.RegenMultiplier(
                    effects.StaminaRegenModifier
                );



            /*
             * Swimming stamina usage.
             */

            m_swimStaminaUseModifier =
                ConfigValueConverter.Multiplier(
                    effects.SwimStaminaUseModifier
                );



            /*
             * Permanent Alagjord Effects
             */

            m_swimSpeedModifier =
                0.30f;



            /*
             * Skill Bonuses
             *
             * Alagjord:
             *
             * +35 Swim
             * +20 Fishing
             */

            m_skillLevel =
                Skills.SkillType.Swim;

            m_skillLevelModifier =
                35f;


            m_skillLevel2 =
                Skills.SkillType.Fishing;

            m_skillLevelModifier2 =
                20f;
        }
    }
}