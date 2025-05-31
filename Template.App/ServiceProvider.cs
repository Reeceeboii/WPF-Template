namespace Template.App
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO.Abstractions;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Template.App.ViewModel.Navigation;
    using Template.App.ViewModel.Navigation.Interfaces;
    using Template.App.ViewModel.Pages;
    using Template.App.ViewModel.Windows;

    /// <summary>
    /// DI container for services/VMs etc...
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Not testable")]
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
            services.AddSingleton<INavigationViewModelFactory, NavigationViewModelFactory>();
            services.AddScoped<IFileSystem, FileSystem>();

            // ViewModels (windows)
            services.AddScoped<MainWindowViewModel>();

            // ViewModels (pages)
            services.AddScoped<ExamplePageViewModel>();

            // ViewModels (misc)
            services.AddSingleton<INavigationViewModel, NavigationViewModel>();
            // Note - a singleton for the NavigationViewModel will cause navigation to become broken if
            // this type is attempted to be used for navigation on smaller stratas of the UI than the MainWindow.
            // In these cases, re-register this service as scoped/transient etc... or whatever works.

            // Services
            // ...

            // Configure IoC provider
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }
    }
}
