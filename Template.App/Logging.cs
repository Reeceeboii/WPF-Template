namespace Template.App
{
    using System;
    using System.Diagnostics;
    using Resource;
    using Serilog;
    using Serilog.Events;

    /// <summary>
    /// Class to handle various logging in DEBUG and RELEASE environments
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Configures logging in a debug environment.
        /// Logs <see cref="LogEventLevel.Verbose"/> and up to a file and <see cref="Debug"/>
        /// </summary>
        [Conditional("DEBUG")]
        public static void ConfigureDebugLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug(restrictedToMinimumLevel: LogEventLevel.Debug)
                .MinimumLevel.Verbose()
                .CreateLogger();
        }

        /// <summary>
        /// Configures logging in a release environment.
        /// Logs <see cref="LogEventLevel.Information"/> and up to a file only.
        /// </summary>
        [Conditional("RELEASE")]
        public static void ConfigureReleaseLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    Constants.LogFileName,
                    rollingInterval: RollingInterval.Day,
                    flushToDiskInterval: TimeSpan.FromMinutes(1),
                    retainedFileCountLimit: 3,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
        }
    }
}
