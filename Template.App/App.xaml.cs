namespace Template.App
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Serilog;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Not testable")]
    public partial class App : Application
    {
        /// <summary>
        /// <inheritdoc cref="Application.OnStartup(StartupEventArgs)"/>
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure logging
            Logging.ConfigureDebugLogging();
            Logging.ConfigureReleaseLogging();

            Log.Information("App is starting");

            // Configure DI
            ServiceProvider.InitServiceProvider();

            Log.Information("App has started");
        }
    } 
}
