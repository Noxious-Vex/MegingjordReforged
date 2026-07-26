using System.Collections.Generic;


namespace MegingjordReforged.Source.Definitions
{
    /// <summary>
    /// Represents synchronized configuration data
    /// transferred from server to client.
    ///
    /// This object is only a transport container.
    ///
    /// It does not:
    /// - Modify client configuration files.
    /// - Handle networking.
    /// - Apply runtime changes.
    ///
    /// The package is created server-side,
    /// serialized, transferred, then applied
    /// through RuntimeConfigOverride.
    /// </summary>
    public class ServerSyncPackage
    {
        /// <summary>
        /// Mod version running on the server.
        ///
        /// Used for compatibility validation.
        ///
        /// Example:
        /// 1.0.0
        /// </summary>
        public string Version { get; set; } = string.Empty;



        /// <summary>
        /// Synchronization schema version.
        ///
        /// This value is assigned by the
        /// server-side package creator.
        ///
        /// Authority:
        ///
        /// VersionManager.SchemaVersion
        ///
        /// This represents the structure of:
        ///
        /// - ServerSyncPackage
        /// - ServerSyncSerializer
        /// - RuntimeConfigOverride
        ///
        /// It is intentionally separate from:
        ///
        /// Plugin.ModVersion
        ///
        /// because gameplay releases and network
        /// structure changes are different concerns.
        /// </summary>
        public int SchemaVersion { get; set; }



        /// <summary>
        /// Synchronized configuration values.
        ///
        /// Key:
        /// Stable synchronization identifier.
        ///
        /// Examples:
        ///
        /// Belts.Aedigjord.CraftingStation
        /// Belts.Aedigjord.Effects.CarryWeight
        ///
        ///
        /// Value:
        /// Serialized configuration value.
        ///
        /// Examples:
        ///
        /// GaldrTable
        /// 250
        /// true
        ///
        ///
        /// Values remain strings because the
        /// synchronization layer should not depend
        /// on individual configuration data types.
        ///
        /// Conversion back into actual types occurs
        /// when the client applies RuntimeConfigOverride.
        /// </summary>
        public Dictionary<string, string> Values { get; set; } =
            new();
    }
}