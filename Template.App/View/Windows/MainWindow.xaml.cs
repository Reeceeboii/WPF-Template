namespace Template.App.View.Windows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Template.App.ViewModel.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Not testable")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// In initialises a new instance of the <see cref="MainWindow"/> class
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
        }
    }
}