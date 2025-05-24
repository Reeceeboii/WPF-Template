namespace Template.App.ViewModel.Navigation
{
    using System;
    using CommunityToolkit.Mvvm.ComponentModel;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// A factory class used to generically retrieve ViewModels from a <see cref="IServiceProvider"/>
    /// </summary>
    /// <param name="serviceProvider">An implementation of <see cref="IServiceProvider"/></param>
    public class NavigationViewModelFactory(IServiceProvider serviceProvider) : INavigationViewModelFactory
    {
        /// <summary>
        /// An implementation of <see cref="IServiceProvider"/>
        /// </summary>
        private readonly IServiceProvider serviceProvider = serviceProvider;

        /// <summary>
        /// Given a type <typeparamref name="T"/>, attempt to resolve a required service
        /// of the same type from the service provider
        /// </summary>
        /// <typeparam name="T">The type to resolve. Constrained to being an <see cref="ObservableObject"/></typeparam>
        /// <returns>A resolved instance of <typeparamref name="T"/></returns>
        public T ResolveViewModelFromServiceProvider<T>() where T : ObservableObject
        {
            return this.serviceProvider.GetRequiredService<T>();
        }
    }
}
