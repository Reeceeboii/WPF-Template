namespace Template.App.ViewModel.Navigation
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// An interface for a factory that constructs ViewModels
    /// </summary>
    public interface INavigationViewModelFactory
    {
        // Missing XML comment for publicly visible type or member - SEE IMPLEMENTATION(S) FOR DOCS
        #pragma warning disable CS1591
        T ResolveViewModelFromServiceProvider<T>() where T : ObservableObject;
        #pragma warning restore CS1591
    }
}