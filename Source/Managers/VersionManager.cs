using System;
using System.IO;
using System.Text;

using MegingjordReforged.Source.Utilities;


namespace MegingjordReforged.Source.Managers
{
    public static class VersionManager
    {
        /*
         * ServerSync schema authority.
         *
         * Increase ONLY when the serialized:
         *
         * - ServerSyncPackage
         * - ServerSyncSerializer
         * - RuntimeConfigOverride
         *
         * structure changes.
         */
        private const int CurrentSchemaVersion = 2;



        /*
         * Configuration file formatting authority.
         *
         * Increase when config layout changes.
         */
        private const int CurrentFormatVersion = 1;



        private const string FormatVersionKey =
            "# MegingjordReforged Config Format Version:";



        private static bool Verified;



        public static void Verify(
            string configPath)
        {
            if (Verified)
            {
                return;
            }



            try
            {
                ModLogger.LogDebug(
                    "Beginning version verification..."
                );



                CheckModVersion();


                CheckSchemaVersion();


                CheckConfigFormatVersion(
                    configPath
                );



                Verified = true;



                ModLogger.LogDebug(
                    "Version verification completed."
                );
            }
            catch (Exception exception)
            {
                ModLogger.LogError(
                    $"Version verification failed: {exception}"
                );
            }
        }



        private static void CheckModVersion()
        {
            /*
             * Reserved for future gameplay
             * migrations.
             */
        }



        private static void CheckSchemaVersion()
        {
            /*
             * ServerSync schema authority.
             *
             * Schema versions are controlled by code,
             * not stored configuration files.
             *
             * Future example:
             *
             * Current schema:
             * 1
             *
             * New schema:
             * 2
             *
             * Migration logic would be added here.
             */


            ModLogger.LogDebug(
                $"ServerSync schema version verified: {CurrentSchemaVersion}."
            );
        }



        private static void CheckConfigFormatVersion(
            string configPath)
        {
            if (string.IsNullOrWhiteSpace(configPath))
            {
                ModLogger.LogWarning(
                    "Unable to verify config format version. Invalid path."
                );

                return;
            }



            if (!File.Exists(configPath))
            {
                return;
            }



            int storedVersion =
                ReadStoredFormatVersion(
                    configPath
                );



            if (storedVersion >= CurrentFormatVersion)
            {
                return;
            }



            ModLogger.LogInfo(
                $"Updating configuration format from version {storedVersion} to {CurrentFormatVersion}."
            );



            ConfigFormatter.Format(
                configPath,
                CurrentFormatVersion
            );
        }



        private static int ReadStoredFormatVersion(
            string configPath)
        {
            try
            {
                string[] lines =
                    File.ReadAllLines(
                        configPath,
                        Encoding.UTF8
                    );



                foreach (
                    string line
                    in lines)
                {
                    if (!line.StartsWith(
                            FormatVersionKey,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }



                    string value =
                        line.Replace(
                            FormatVersionKey,
                            string.Empty
                        )
                        .Trim();



                    if (int.TryParse(
                            value,
                            out int version))
                    {
                        return version;
                    }
                }
            }
            catch (Exception exception)
            {
                ModLogger.LogWarning(
                    $"Unable to read configuration format version: {exception.Message}"
                );
            }



            return 0;
        }



        public static int SchemaVersion =>
            CurrentSchemaVersion;



        public static int FormatVersion =>
            CurrentFormatVersion;
    }
}