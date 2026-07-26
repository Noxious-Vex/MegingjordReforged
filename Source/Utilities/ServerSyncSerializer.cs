using System.Collections.Generic;

using Jotunn;

using MegingjordReforged.Source.Definitions;


namespace MegingjordReforged.Source.Utilities
{
    /// <summary>
    /// Handles conversion of ServerSyncPackage objects
    /// into Valheim network packages and back.
    ///
    /// This class only handles transport serialization.
    ///
    /// It does not:
    /// - Validate permissions.
    /// - Apply configuration values.
    /// - Modify configuration files.
    /// </summary>
    public static class ServerSyncSerializer
    {
        /// <summary>
        /// Serializes a ServerSyncPackage into
        /// a Valheim network package.
        ///
        /// Format:
        ///
        /// string:
        ///     Mod version
        ///
        /// int:
        ///     Synchronization schema version
        ///
        /// int:
        ///     Number of synchronized values
        ///
        /// repeated:
        ///     string key
        ///     string value
        /// </summary>
        public static ZPackage Serialize(
            ServerSyncPackage package)
        {
            ZPackage zPackage =
                new ZPackage();



            /*
             * Write package mod version.
             */
            zPackage.Write(
                package.Version
            );



            /*
             * Write synchronization schema version.
             *
             * Used to validate compatibility
             * between server and client.
             */
            zPackage.Write(
                package.SchemaVersion
            );



            /*
             * Write number of synchronized values.
             */
            zPackage.Write(
                package.Values.Count
            );



            foreach (
                KeyValuePair<string, string> entry
                in package.Values)
            {
                /*
                 * Synchronization keys are stable
                 * identifiers defined by ServerSyncRegistry.
                 */
                zPackage.Write(
                    entry.Key
                );



                /*
                 * Values remain serialized strings.
                 */
                zPackage.Write(
                    entry.Value
                );
            }



            return zPackage;
        }




        /// <summary>
        /// Deserializes a Valheim network package
        /// back into a ServerSyncPackage.
        ///
        /// Expected format:
        ///
        /// Version
        /// SchemaVersion
        /// Values
        /// </summary>
        public static ServerSyncPackage Deserialize(
            ZPackage package)
        {
            ServerSyncPackage syncPackage =
                new ServerSyncPackage();



            /*
             * Read server mod version.
             */
            syncPackage.Version =
                package.ReadString();



            /*
             * Read synchronization schema version.
             */
            syncPackage.SchemaVersion =
                package.ReadInt();




            /*
             * Read number of synchronized values.
             */
            int valueCount =
                package.ReadInt();




            for (
                int i = 0;
                i < valueCount;
                i++)
            {
                string key =
                    package.ReadString();



                string value =
                    package.ReadString();



                /*
                 * Assignment instead of Add()
                 *
                 * Prevents duplicate keys from
                 * causing synchronization failure.
                 */
                syncPackage.Values[key] =
                    value;
            }



            return syncPackage;
        }
    }
}