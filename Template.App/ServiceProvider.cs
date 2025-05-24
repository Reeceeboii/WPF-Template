namespace Template.App
{
    using System.IO.Abstractions;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Template.App.ViewModel.Navigation;
    using Template.App.ViewModel.Pages;
    using Template.App.ViewModel.Windows;

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

            // ViewModels (windows)
            services.AddScoped<MainWindowViewModel>();

            // ViewModels (pages)
            services.AddScoped<ExamplePageViewModel>();

            // ViewModels (misc)
            services.AddScoped<NavigationViewModel>();

            // Services
            // ...

            // Configure IoC provider
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }
    }
}
