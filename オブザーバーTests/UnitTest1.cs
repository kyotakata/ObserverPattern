using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using オブザーバー;

namespace オブザーバーTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new MainViewModel(null, );
            Assert.AreEqual("AAA", vm.WarningLabelText);

        }
    }

    internal class WarningTimerMock : WarningTimerBase
    {

    }
}
