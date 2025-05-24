namespace Template.App
{
    using System.IO.Abstractions;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Template.App.ViewModel;

    /// <summary>
    /// DI container for services/VMs etc...
    /// </summary>
    public static class ServiceProvider
    {
        /// <summary>
        /// Initialises an <see cref="IServiceCollection"/>
        /// and sets up <see cref="Ioc"/> with it
        /// </summary>
        public static void InitServiceProvider()
        {
            ServiceCollection services = [];

            // Misc
            services.AddScoped<IFileSystem, FileSystem>();

            // ViewModels
            services.AddScoped<MainWindowViewModel>();

            // Services
            // ...

            // Configure IoC provider
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }
    }
}
