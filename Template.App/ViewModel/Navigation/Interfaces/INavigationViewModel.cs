#pragma warning disable CS1591
// Missing XML comment for publicly visible type or member - SEE IMPLEMENTATION(S) FOR DOCS

namespace Template.App.ViewModel.Navigation.Interfaces
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// Interface for a ViewModel that provides navigation functionality
    /// </summary>
    public interface INavigationViewModel
    {
        ObservableObject? CurrentViewModel { get; }
        void Navigate<TTarget>() where TTarget : ObservableObject;
    }
}