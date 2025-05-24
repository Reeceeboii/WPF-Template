namespace Template.App.ViewModel
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// ViewModel for the main application window
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// Example property using MVVM code generators
        /// </summary>
        [ObservableProperty]
        private string exampleProperty;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindowViewModel"/> class
        /// </summary>
        public MainWindowViewModel()
        {
            this.ExampleProperty = "Hello world from WPF";
        }
    }
}
