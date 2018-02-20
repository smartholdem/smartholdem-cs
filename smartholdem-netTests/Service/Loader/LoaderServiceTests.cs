using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;

namespace SmartHoldemNet.Service.Loader.Tests
{
    [TestClass()]
    public class LoaderServiceTests : LoaderServiceTestsBase
    {
        [TestInitialize]
        public void Init()
        {
            base.Initialize();
        }

        [TestMethod()]
        public void GetStatusTest()
        {
            var status = LoaderService.GetStatus();

            GetStatusResultTest(status);
        }

        [TestMethod()]
        public void GetSyncStatusTest()
        {
            var syncStatus = LoaderService.GetSyncStatus();

            GetSyncStatusResultTest(syncStatus);
        }

        [TestMethod()]
        public void GetAutoConfigureParametersTest()
        {
            var parameters = LoaderService.GetAutoConfigureParameters();

            GetAutoConfigureParametersResultTest(parameters);
        }
    }
}