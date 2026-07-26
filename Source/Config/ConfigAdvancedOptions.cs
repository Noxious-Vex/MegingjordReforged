namespace MegingjordReforged.Source.Config
{
    /// <summary>
    /// Advanced configuration options.
    ///
    /// These settings are intended for future expansion
    /// and experimental features that may not be enabled
    /// during normal gameplay.
    /// </summary>
    public class ConfigAdvancedOptions
    {
        /// <summary>
        /// Enables experimental features.
        ///
        /// Experimental features may alter gameplay behavior
        /// or introduce unfinished functionality.
        ///
        /// Default: Disabled.
        /// </summary>
        public bool ExperimentalFeatures { get; set; } = false;
    }
}