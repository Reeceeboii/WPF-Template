#pragma warning disable CS8618
// Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Template.Test.ViewModel.Windows
{
    using System.Diagnostics.CodeAnalysis;
    using CommunityToolkit.Mvvm.ComponentModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using Shouldly;
    using Template.App.ViewModel.Navigation.Interfaces;
    using Template.App.ViewModel.Windows;

    /// <summary>
    /// Unit tests for the <see cref="MainWindowViewModel"/>
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage(Justification = "Unit test")]
    public class MainWindowViewModelTests
    {
        /// <summary>
        /// System under test
        /// </summary>
        private MainWindowViewModel sut;

        /// <summary>
        /// Mock <see cref="INavigationViewModel"/> used in tests
        /// </summary>
        private INavigationViewModel navigationViewModelMock;

        /// <summary>
        /// This method is called before each test method.
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            this.navigationViewModelMock = Substitute.For<INavigationViewModel>();
        }

        /// <summary>
        /// Tests that the <see cref="MainWindowViewModel"/> can be initialised
        /// </summary>
        [TestMethod]
        public void CanInitialiseTest()
        {
            // Arrange
            // Act
            this.CreateSut();

            // Assert
            this.sut
                .ShouldNotBeNull();

            this.navigationViewModelMock
                .Received(1)
                .Navigate<ObservableObject>();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindowViewModel"/> class
        /// </summary>
        private void CreateSut()
        {
            this.sut = new MainWindowViewModel(this.navigationViewModelMock);
        }
    }
}
