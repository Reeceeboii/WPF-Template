#pragma warning disable CS1591
// Missing XML comment for publicly visible type or member - SEE IMPLEMENTATION(S) FOR DOCS

namespace Template.App.ViewModel.Navigation.Interfaces
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// An interface for a factory that constructs ViewModels
    /// </summary>
    public interface INavigationViewModelFactory
    {
        T ResolveViewModelFromServiceProvider<T>() where T : ObservableObject;
    }
}