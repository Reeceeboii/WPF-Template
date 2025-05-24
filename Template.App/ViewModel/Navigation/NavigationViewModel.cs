namespace Template.App.ViewModel.Navigation
{
    using System;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Serilog;

    /// <summary>
    /// Class representing the base logic of application view navigation based on
    /// a selected ViewModel
    /// </summary>
    public partial class NavigationViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets the current ViewModel that has been navigated to
        /// </summary>
        [ObservableProperty]
        private ObservableObject? currentViewModel;

        /// <summary>
        /// Direct navigation method that is able to be used by areas of the application that have direct access
        /// to this object
        /// </summary>
        /// <typeparam name="TTarget">The target type of the ViewModel to navigate to</typeparam>
        public void Navigate<TTarget>() where TTarget : ObservableObject
        {
            if (!this.ShouldNavigate<TTarget>())
            {
                Log.Debug("{extenderType} not navigating to {target}", this.GetType().Name, typeof(TTarget));
                return;
            }

            try
            {
                this.CurrentViewModel = Ioc.Default.GetRequiredService<TTarget>();

                Log.Debug("{extenderType} navigated to {navType}", this.GetType().Name, typeof(TTarget));
                Log.Information("Application has navigated to {target}", typeof(TTarget));
            }
            catch (InvalidOperationException ex) 
            {
                Log.Error(
                    ex,
                    "{extenderType} cannot navigate to target: {target}. IoC retrieval of target failed", 
                    this.GetType().Name,
                    typeof(TTarget));
            }
        }

        /// <summary>
        /// Decide whether or not a navigation intent is valid.
        /// Navigations are deemed valid if <see cref="CurrentViewModel"/> is null (i.e. a navigation
        /// has not yet taken place) or if <typeparamref name="TTarget"/> is different to the type of
        /// <see cref="CurrentViewModel"/> (i.e. cyclical navigation is not being attempted).
        /// </summary>
        /// <typeparam name="TTarget">The type of ViewModel targeted for navigation</typeparam>
        /// <returns>True if the application should navigate, false if it should not</returns>
        private bool ShouldNavigate<TTarget>()
        {
            return this.CurrentViewModel is not { } || typeof(TTarget) != this.CurrentViewModel.GetType();     
        }
    }
}
