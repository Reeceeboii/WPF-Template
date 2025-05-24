namespace Template.App.ViewModel.Windows
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using Template.App.ViewModel.Pages;
    using Template.App.ViewModel.Navigation;

    /// <summary>
    /// ViewModel for the main application window
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets an instance of <see cref="NavigationViewModel"/>
        /// </summary>
        [ObservableProperty]
        private NavigationViewModel navigationViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindowViewModel"/> class
        /// </summary>
        public MainWindowViewModel(NavigationViewModel navigationViewModel)
        {
            this.NavigationViewModel = navigationViewModel;

            // Some logic could go here to change what page is initially navigated to...
            this.NavigationViewModel.Navigate<ExamplePageViewModel>();
        }
    }
}
