using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.StatusEffects
{
    public class SE_Seidgjord : SE_Stats
    {
        public SE_Seidgjord()
        {
            name = "SE_Seidgjord";

            m_name = "Seidgjord";

            m_tooltip =
                "Carrying the whispers of forgotten runes and arcane power.";


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
                    "Seidgjord"
                ).Effects;



            /*
             * Reset configurable values.
             */

            m_addMaxCarryWeight = 0f;

            m_healthRegenMultiplier = 1f;

            m_staminaRegenMultiplier = 1f;

            m_eitrRegenMultiplier = 1f;



            /*
             * Configurable Effects
             */

            m_addMaxCarryWeight =
                ConfigValueConverter.Flat(
                    effects.CarryWeight,
                    0f,
                    500f
                );



            m_healthRegenMultiplier =
                ConfigValueConverter.RegenMultiplier(
                    effects.HealthRegenModifier
                );


            m_staminaRegenMultiplier =
                ConfigValueConverter.RegenMultiplier(
                    effects.StaminaRegenModifier
                );


            m_eitrRegenMultiplier =
                ConfigValueConverter.RegenMultiplier(
                    effects.EitrRegenModifier
                );



            /*
             * Skill Bonuses
             *
             * Seidgjord:
             *
             * +30 Elemental Magic
             * +20 Blood Magic
             */

            m_skillLevel =
                Skills.SkillType.ElementalMagic;

            m_skillLevelModifier =
                effects.ElementalMagicSkillLevelIncrease;


            m_skillLevel2 =
                Skills.SkillType.BloodMagic;

            m_skillLevelModifier2 =
                effects.BloodMagicSkillLevelIncrease;
        }
    }
}