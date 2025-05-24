namespace Template.App.ViewModel.Pages
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// A sample page ViewModel
    /// </summary>
    public partial class ExamplePageViewModel : ObservableObject
    {
        /// <summary>
        /// Example property using MVVM code generators
        /// </summary>
        [ObservableProperty]
        private string examplePageViewModelProperty;

        /// <summary>
        /// Initialises a new instance of the <see cref="ExamplePageViewModel"/> class
        /// </summary>
        public ExamplePageViewModel()
        {
            this.ExamplePageViewModelProperty = "Hello world from WPF";
        }
    }
}
