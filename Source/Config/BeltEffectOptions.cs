namespace MegingjordReforged.Source.Config
{
    /// <summary>
    /// Configurable effects for an individual belt.
    ///
    /// Values are exposed using player-friendly configuration values.
    ///
    /// Flat values:
    /// Stored as direct values.
    ///
    /// Percentage values:
    /// Stored as whole percentages.
    ///
    /// Example:
    ///
    /// 25  = +25%
    /// -25 = -25%
    /// 0   = no modifier
    ///
    /// Individual belts determine which effects
    /// are exposed through configuration.
    /// </summary>
    public class BeltEffectOptions
    {
        public float CarryWeight { get; set; } = 0f;


        public float Armor { get; set; } = 0f;


        public float HealthRegenModifier { get; set; } = 0f;


        public float StaminaRegenModifier { get; set; } = 0f;


        public float EitrRegenModifier { get; set; } = 0f;


        public float AttackStaminaUseModifier { get; set; } = 0f;


        public float SwimStaminaUseModifier { get; set; } = 0f;


        public float RunStaminaUseModifier { get; set; } = 0f;


        public float JumpStaminaUseModifier { get; set; } = 0f;


        public float DodgeStaminaUseModifier { get; set; } = 0f;


        public float SneakStaminaUseModifier { get; set; } = 0f;

    }
}