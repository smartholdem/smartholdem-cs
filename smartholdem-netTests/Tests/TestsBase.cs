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

namespace SmartHoldemNet.Tests
{
    public class TestsBase
    {
        protected readonly bool USE_DEV_NET = true;

        public void Initialize()
        {
            if (USE_DEV_NET)
                SmartHoldemNetApi.Instance.Start(NetworkType.DevNet).Wait();
            else
                SmartHoldemNetApi.Instance.Start(NetworkType.MainNet).Wait();
        }

        public async Task InitializeAsync()
        {
            if (USE_DEV_NET)
                await SmartHoldemNetApi.Instance.Start(NetworkType.DevNet);
            else
                await SmartHoldemNetApi.Instance.Start(NetworkType.MainNet);
        }
    }
}