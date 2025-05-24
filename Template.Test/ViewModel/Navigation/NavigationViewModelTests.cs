#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Template.Test.ViewModel.Navigation
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using Serilog;
    using Serilog.Events;
    using Serilog.Sinks.TestCorrelator;
    using Shouldly;
    using Template.App.ViewModel.Navigation;
    using Template.Test.Utils.ExampleTypes;

    /// <summary>
    /// Tests targeting <see cref="NavigationViewModel"/>
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage(Justification = "Unit test")]
    public sealed class NavigationViewModelTests
    {
        /// <summary>
        /// System under test
        /// </summary>
        private NavigationViewModel sut;

        /// <summary>
        /// Mock <see cref="INavigationViewModelFactory"/> used in tests
        /// </summary>
        private INavigationViewModelFactory factoryMock;

        /// <summary>
        /// Initialise the test class
        /// </summary>
        /// <param name="_">Unused</param>
        [ClassInitialize]
        public static void ClassInit(TestContext _)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo
                .TestCorrelator()
                .CreateLogger();
        }

        /// <summary>
        /// This method is called before each test method.
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {            
            this.factoryMock = Substitute.For<INavigationViewModelFactory>();

            this.factoryMock
                .ResolveViewModelFromServiceProvider<TestViewModel>()
                .Returns(Substitute.For<TestViewModel>());
        }

        /// <summary>
        /// This method is called after each test method.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
        }

        /// <summary>
        /// Test that <see cref="NavigationViewModel"/> can be initialised
        /// </summary>
        [TestMethod]
        public void CanInitialiseTest()
        {
            // Arrange
            // Act
            this.CreateSut();

            // Assert
            this.sut.ShouldNotBeNull();
        }

        /// <summary>
        /// Tests that <see cref="NavigationViewModel.Navigate{TTarget}"/> navigates when
        /// permitted to do so.
        /// </summary>
        [TestMethod]
        public void NavigationWhenNavigationAllowedTest()
        {
            // Arrange
            using ITestCorrelatorContext ctx = TestCorrelator.CreateContext();
            this.CreateSut();

            // Act
            this.sut.Navigate<TestViewModel>();

            // Assert
            this.sut.CurrentViewModel.ShouldBeAssignableTo<TestViewModel>();

            this.factoryMock!
                .Received(1)
                .ResolveViewModelFromServiceProvider<TestViewModel>();

            TestCorrelator
                .GetLogEventsFromCurrentContext()
                .Count
                .ShouldBe(2);
        }

        /// <summary>
        /// Tests that navigation does not occur when a navigation to the same type has 
        /// already occurred
        /// </summary>
        [TestMethod]
        public void NavigationWhenAlreadyNavigatedToTargetTest()
        {
            // Arrange
            using ITestCorrelatorContext ctx = TestCorrelator.CreateContext();
            this.CreateSut();

            // Simulate a navigation
            this.sut.Navigate<TestViewModel>();

            // Act
            this.sut.Navigate<TestViewModel>();

            // Assert
            // We should still be in the same location
            this.sut.CurrentViewModel.ShouldBeAssignableTo<TestViewModel>();

            // We should only have attempted to resolve the target once.
            // The second attempt is ignored as we are already navigated to it.
            this.factoryMock!
                .Received(1)
                .ResolveViewModelFromServiceProvider<TestViewModel>();
        }

        /// <summary>
        /// Tests that an error is logged when an attempt is made to navigate but 
        /// the target type is not registered with IoC container
        /// </summary>
        [TestMethod]
        public void NavigateWhenServiceResolutionFailsLogsErrorTest()
        {
            // Arrange
            using ITestCorrelatorContext ctx = TestCorrelator.CreateContext();
            this.factoryMock
                .When(m => m.ResolveViewModelFromServiceProvider<TestViewModel>())
                .Throws<InvalidOperationException>();

            this.CreateSut();

            // Act
            this.sut.Navigate<TestViewModel>();

            // Assert
            this.factoryMock
                .Received(1)
                .ResolveViewModelFromServiceProvider<TestViewModel>();

            TestCorrelator
                .GetLogEventsFromCurrentContext()
                .Count
                .ShouldBe(1);

            TestCorrelator
                .GetLogEventsFromCurrentContext()[0]
                .Level
                .ShouldBe(LogEventLevel.Error);
        }

        /// <summary>
        /// Initialise a new instance of <see cref="NavigationViewModel"/> for testing
        /// </summary>
        private void CreateSut()
        {
            this.sut = new NavigationViewModel(this.factoryMock);
        }
    }
}
