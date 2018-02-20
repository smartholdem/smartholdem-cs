using SmartHoldemNet.Utils;
using SmartHoldemNet.Utils.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartHoldemNet.Tests
{
    [TestClass()]
    public class SmartHoldemNetApiTests
    {
        [TestMethod()]
        public void StartTest()
        {
            SmartHoldemNetApi.Instance.Start(NetworkType.MainNet).Wait();

            Assert.IsNotNull(SmartHoldemNetApi.Instance.NetworkSettings);
        }
    }
}