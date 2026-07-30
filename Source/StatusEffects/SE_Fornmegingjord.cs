using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Managers;
using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.StatusEffects
{
    public class SE_Fornmegingjord : SE_Stats
    {
        public SE_Fornmegingjord()
        {
            name = "SE_Fornmegingjord";

            m_name = "Fornmegingjord";

            m_tooltip =
                "A treasure worthy of heroes and kings.";


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
                    "Fornmegingjord"
                ).Effects;



            /*
             * Reset configurable values.
             */

            m_addMaxCarryWeight = 0f;



            /*
             * Flat Effects
             */

            m_addMaxCarryWeight =
                ConfigValueConverter.Flat(
                    effects.CarryWeight,
                    0f,
                    1000f
                );



            /*
             * Permanent Damage Effects
             */

            m_percentigeDamageModifiers.m_spirit =
                0.40f;


            m_percentigeDamageModifiers.m_lightning =
                0.30f;



            /*
             * Skill Bonuses
             *
             * Fornmegingjord:
             *
             * +25 Woodcutting
             * +25 Pickaxes
             */

            m_skillLevel =
                Skills.SkillType.WoodCutting;

            m_skillLevelModifier =
                effects.WoodcuttingSkillLevelIncrease;


            m_skillLevel2 =
                Skills.SkillType.Pickaxes;

            m_skillLevelModifier2 =
                effects.PickaxeSkillLevelIncrease;
        }
    }
}