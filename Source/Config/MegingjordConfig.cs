using MegingjordReforged.Source.Config;


namespace MegingjordReforged.Source.Definitions
{
    public class MegingjordConfig
    {
        /// <summary>
        /// Internal path to the active BepInEx configuration file.
        ///
        /// This is runtime metadata only.
        /// It is not written to the user configuration file.
        /// </summary>
        public string ConfigPath { get; set; } = string.Empty;



        /// <summary>
        /// General mod behavior settings.
        /// </summary>
        public ConfigGeneralOptions General { get; set; } = new();



        /// <summary>
        /// Logging behavior and verbosity settings.
        /// </summary>
        public ConfigLoggingMode Logging { get; set; } =
            ConfigLoggingMode.Standard;



        /// <summary>
        /// Individual belt configuration settings.
        /// </summary>
        public ConfigBeltOptions Belts { get; set; } = new();



        /// <summary>
        /// Advanced and experimental configuration settings.
        /// </summary>
        public ConfigAdvancedOptions Advanced { get; set; } = new();
    }
}