namespace MegingjordReforged.Source.Definitions
{
    /// <summary>
    /// Defines a configuration value that can be synchronized
    /// from server to clients.
    /// </summary>
    public class ServerSyncDefinition
    {
        /// <summary>
        /// Configuration section.
        /// Example:
        /// Belts - Aedigjord
        /// </summary>
        public string Section { get; set; } = string.Empty;



        /// <summary>
        /// Configuration key.
        /// Example:
        /// Enable Belt
        /// </summary>
        public string Key { get; set; } = string.Empty;



        /// <summary>
        /// Human-readable identifier.
        /// Example:
        /// Belts.Aedigjord.Enabled
        /// </summary>
        public string Identifier { get; set; } = string.Empty;



        /// <summary>
        /// Whether this value is synchronized.
        /// </summary>
        public bool Enabled { get; set; } = true;
    }
}