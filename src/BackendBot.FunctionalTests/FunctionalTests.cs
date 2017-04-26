using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendBot.FunctionalTests
{
    [TestClass]
    public class FunctionalTests
    {
        [TestMethod]
        public void OneEqualsOne_FromFunctionalTests()
        {
            Assert.IsTrue(1 == 1);
        }
    }
}
