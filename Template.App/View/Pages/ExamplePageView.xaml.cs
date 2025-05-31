namespace Template.App.View.Pages
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Template.App.ViewModel.Pages;

    /// <summary>
    /// Interaction logic for ExamplePageView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Not testable")]
    public partial class ExamplePageView : UserControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExamplePageView"/> class
        /// </summary>
        public ExamplePageView()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetRequiredService<ExamplePageViewModel>();
        }
    }
}
