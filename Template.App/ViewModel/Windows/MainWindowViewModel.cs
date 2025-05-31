namespace Template.App.ViewModel.Windows
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using Template.App.ViewModel.Navigation.Interfaces;
    using Template.App.ViewModel.Pages;

    /// <summary>
    /// ViewModel for the main application window
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets an instance of <see cref="INavigationViewModel"/>
        /// </summary>
        [ObservableProperty]
        private INavigationViewModel navigationViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindowViewModel"/> class
        /// </summary>
        /// <param name="navigationViewModel">An instance of <see cref="INavigationViewModel"/></param>
        public MainWindowViewModel(INavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;

            // Some logic could go here to change what page is initially navigated to...
            this.NavigationViewModel.Navigate<ExamplePageViewModel>();
        }
    }
}
