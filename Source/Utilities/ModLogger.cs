using Jotunn;

using MegingjordReforged.Source.Config;
using MegingjordReforged.Source.Managers;

namespace MegingjordReforged.Source.Utilities
{
    /// <summary>
    /// Centralized logging system for Megingjord Reforged.
    ///
    /// Logging behavior is controlled through:
    ///
    /// ConfigManager.Current.Logging
    ///
    /// If configuration has not loaded,
    /// safe default behavior is applied.
    /// </summary>
    public static class ModLogger
    {
        /// <summary>
        /// Logs startup messages.
        ///
        /// Startup messages are always displayed.
        /// </summary>
        public static void LogStart(string message)
        {
            WriteInfo(
                $"[Startup] {message}"
            );
        }



        /// <summary>
        /// Logs debugging information.
        ///
        /// Only displayed in Debug mode.
        /// </summary>
        public static void LogDebug(string message)
        {
            if (!IsDebugEnabled())
                return;


            WriteInfo(
                $"[Debug] {message}"
            );
        }



        /// <summary>
        /// Logs standard operational information.
        ///
        /// Displayed in Standard and Debug modes.
        /// </summary>
        public static void LogInfo(string message)
        {
            if (!IsInfoEnabled())
                return;


            WriteInfo(
                $"[Info] {message}"
            );
        }



        /// <summary>
        /// Logs warnings.
        ///
        /// Hidden only in Minimal mode.
        /// </summary>
        public static void LogWarning(string message)
        {
            if (!IsWarningEnabled())
                return;


            WriteWarning(
                $"[Warning] {message}"
            );
        }



        /// <summary>
        /// Logs errors.
        ///
        /// Errors are always displayed.
        /// </summary>
        public static void LogError(string message)
        {
            WriteError(
                $"[Error] {message}"
            );
        }



        private static bool IsDebugEnabled()
        {
            if (ConfigManager.Current == null)
                return false;


            return ConfigManager.Current.Logging ==
                   ConfigLoggingMode.Debug;
        }



        private static bool IsInfoEnabled()
        {
            if (ConfigManager.Current == null)
                return false;


            return ConfigManager.Current.Logging ==
                       ConfigLoggingMode.Standard
                   ||
                   ConfigManager.Current.Logging ==
                       ConfigLoggingMode.Debug;
        }



        private static bool IsWarningEnabled()
        {
            if (ConfigManager.Current == null)
                return true;


            return ConfigManager.Current.Logging !=
                   ConfigLoggingMode.Minimal;
        }



        private static void WriteInfo(string message)
        {
            Jotunn.Logger.LogInfo(message);
        }



        private static void WriteWarning(string message)
        {
            Jotunn.Logger.LogWarning(message);
        }



        private static void WriteError(string message)
        {
            Jotunn.Logger.LogError(message);
        }
    }
}