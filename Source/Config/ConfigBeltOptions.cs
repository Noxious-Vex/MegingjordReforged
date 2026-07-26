namespace MegingjordReforged.Source.Config
{
    /// <summary>
    /// Contains configuration categories for all Megingjord Reforged belt variants.
    ///
    /// Each individual belt contains its own enable state,
    /// crafting availability, and recipe override settings.
    /// </summary>
    public class ConfigBeltOptions
    {
        /// <summary>
        /// Configuration settings for Aedigjord.
        ///
        /// Aedigjord:
        /// The Rage Belt variant focused on combat strength and endurance.
        /// </summary>
        public IndividualBeltOptions Aedigjord { get; set; } = new();



        /// <summary>
        /// Configuration settings for Alagjord.
        ///
        /// Alagjord:
        /// The Aquatic Belt variant focused on swimming and water traversal.
        /// </summary>
        public IndividualBeltOptions Alagjord { get; set; } = new();



        /// <summary>
        /// Configuration settings for Fornmegingjord.
        ///
        /// Fornmegingjord:
        /// The Legendary Belt variant representing the ancient reforged Megingjord.
        /// </summary>
        public IndividualBeltOptions Fornmegingjord { get; set; } = new();



        /// <summary>
        /// Configuration settings for Seidgjord.
        ///
        /// Seidgjord:
        /// The Eitr and magic-focused belt variant.
        /// </summary>
        public IndividualBeltOptions Seidgjord { get; set; } = new();



        /// <summary>
        /// Configuration settings for Skadigjord.
        ///
        /// Skadigjord:
        /// The Agility Belt variant focused on speed and mobility.
        /// </summary>
        public IndividualBeltOptions Skadigjord { get; set; } = new();



        /// <summary>
        /// Retrieves individual belt configuration by configuration key.
        ///
        /// Configuration keys correspond to BeltDefinition.ConfigKey values.
        ///
        /// Example:
        /// "Aedigjord" returns the Aedigjord configuration.
        /// </summary>
        /// <param name="configKey">
        /// The belt configuration key.
        /// </param>
        /// <returns>
        /// Matching IndividualBeltOptions.
        /// If no match exists, default options are returned.
        /// </returns>
        public IndividualBeltOptions GetBeltOptions(string configKey)
        {
            return configKey switch
            {
                "Aedigjord" =>
                    Aedigjord,

                "Alagjord" =>
                    Alagjord,

                "Fornmegingjord" =>
                    Fornmegingjord,

                "Seidgjord" =>
                    Seidgjord,

                "Skadigjord" =>
                    Skadigjord,

                _ =>
                    new IndividualBeltOptions()
            };
        }
    }
}