namespace MegingjordReforged.Source.Config
{
    /// <summary>
    /// Available logging verbosity levels.
    /// </summary>
    public enum ConfigLoggingMode
    {
        /// <summary>
        /// Startup messages and errors only.
        /// </summary>
        Minimal,


        /// <summary>
        /// Startup messages, errors, and warnings.
        /// </summary>
        Warnings,


        /// <summary>
        /// Normal operational logging.
        /// </summary>
        Standard,


        /// <summary>
        /// Detailed debugging information.
        /// </summary>
        Debug
    }
}