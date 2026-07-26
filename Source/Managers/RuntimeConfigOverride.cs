using System;
using System.Collections.Generic;
using System.Globalization;


namespace MegingjordReforged.Source.Managers
{
    /// <summary>
    /// Stores temporary server-authoritative configuration overrides.
    ///
    /// These values:
    ///
    /// - Exist only during the current game session.
    /// - Do not modify the local BepInEx configuration file.
    /// - Are cleared when leaving a synchronized server.
    ///
    /// Values received from ServerSync are stored as strings
    /// and converted when requested.
    /// </summary>
    public static class RuntimeConfigOverride
    {
        /*
         * Stores active overrides.
         *
         * Key:
         * Stable synchronization identifier.
         *
         * Value:
         * Serialized server value.
         */
        private static readonly Dictionary<string, string> Overrides =
            new();



        /// <summary>
        /// Determines whether a runtime override exists.
        /// </summary>
        public static bool Contains(
            string key)
        {
            return Overrides.ContainsKey(
                key
            );
        }



        /// <summary>
        /// Adds or replaces a runtime override value.
        ///
        /// Values are stored as strings because
        /// ServerSync packages serialize values as strings.
        /// </summary>
        public static void Set(
            string key,
            object value)
        {
            Overrides[key] =
                value.ToString() ?? string.Empty;
        }



        /// <summary>
        /// Attempts to retrieve a runtime override.
        ///
        /// Automatically converts stored values
        /// into the requested type.
        /// </summary>
        public static bool TryGet<T>(
            string key,
            out T value)
        {
            value =
                default!;



            if (!Overrides.TryGetValue(
                    key,
                    out string? stored))
            {
                return false;
            }



            try
            {
                Type targetType =
                    typeof(T);



                if (targetType == typeof(string))
                {
                    value =
                        (T)(object)stored;

                    return true;
                }



                if (targetType.IsEnum)
                {
                    value =
                        (T)Enum.Parse(
                            targetType,
                            stored
                        );

                    return true;
                }



                value =
                    (T)Convert.ChangeType(
                        stored,
                        targetType,
                        CultureInfo.InvariantCulture
                    );

                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// Removes a single runtime override.
        /// </summary>
        public static void Remove(
            string key)
        {
            Overrides.Remove(
                key
            );
        }



        /// <summary>
        /// Clears all server overrides.
        ///
        /// Called when:
        ///
        /// - Leaving a multiplayer server.
        /// - Disconnecting.
        /// - Resetting synchronization state.
        /// </summary>
        public static void Clear()
        {
            Overrides.Clear();
        }
    }
}