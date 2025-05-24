namespace Template.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    /// <summary>
    /// Example test class
    /// </summary>
    [TestClass]
    public sealed class Test1
    {
        /// <summary>
        /// This method is called before each test method.
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
        }

        /// <summary>
        /// This method is called after each test method.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
        }

        /// <summary>
        /// Example unit test method
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            1.ShouldBe(1);
        }
    }
}
