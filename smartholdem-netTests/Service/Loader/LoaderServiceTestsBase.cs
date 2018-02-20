using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;
using SmartHoldemNet.Model.Account;
using SmartHoldemNet.Model.Delegate;
using SmartHoldemNet.Model.Block;
using SmartHoldemNet.Utils;
using SmartHoldemNet.Model.Loader;
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Service.Loader.Tests
{
    public class LoaderServiceTestsBase : TestsBase
    {
        public void GetStatusResultTest(SmartHoldemLoaderStatus status)
        { 
            Assert.IsNotNull(status);
            Assert.IsTrue(status.Success);
            Assert.IsNull(status.Error);
        }

        public void GetSyncStatusResultTest(SmartHoldemLoaderStatusSync syncStatus)
        {
            Assert.IsNotNull(syncStatus);
            Assert.IsTrue(syncStatus.Success);
            Assert.IsNull(syncStatus.Error);
        }

        public void GetAutoConfigureParametersResultTest(SmartHoldemLoaderNetworkResponse parameters)
        {
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.Network);
            Assert.IsTrue(parameters.Success);
            Assert.IsNull(parameters.Error);
        }
    }
}