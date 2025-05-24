namespace Template.App
{
    using System.Windows;
    using Serilog;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// <inheritdoc cref="Application.OnStartup(StartupEventArgs)"/>
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Log.Information("App is starting");

            // Configure DI
            ServiceProvider.InitServiceProvider();

            Log.Information("App has started");
        }
    } 
}
