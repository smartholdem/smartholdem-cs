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
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Service.Account.Tests
{
    public class AccountServiceTestsBase : TestsBase
    {
        protected string _address = "AQLUKKKyKq5wZX7rCh4HJ4YFQ8bpTpPJgK";

        public void InitializeAccountServiceTest()
        {
            base.Initialize();

            Setup();
        }

        public async Task InitializeAccountServiceAsyncTest()
        {
            await base.InitializeAsync();

            Setup();
        }

        private void Setup()
        {
            if (base.USE_DEV_NET)
                _address = "DFZG912okkrs9vvZUDV1rqCgzh26zgED3Q";
        }

        public void GetByAddressResultTest(SmartHoldemAccountResponse account)
        {
            Assert.IsNotNull(account);
            Assert.IsNotNull(account.Account);
            Assert.IsTrue(account.Success);
            Assert.IsNull(account.Error);
            Assert.AreEqual(_address, account.Account.Address);
        }

        public void GetByAddressErrorResultTest(SmartHoldemAccountResponse account)
        {
            Assert.IsNotNull(account);
            Assert.IsNull(account.Account);
            Assert.IsFalse(account.Success);
            Assert.IsNotNull(account.Error);
        }

        public void GetBalanceResultTest(SmartHoldemAccountBalance balance)
        {
            Assert.IsNotNull(balance);
            Assert.IsTrue(balance.Success);
            Assert.IsNull(balance.Error);
        }

        public void GetBalanceErrorResultTest(SmartHoldemAccountBalance balance)
        {
            Assert.IsNotNull(balance);
            Assert.IsFalse(balance.Success);
            Assert.IsNotNull(balance.Error);
        }

        public void GetDelegatesResultTest(SmartHoldemDelegateList delegates)
        {
            Assert.IsNotNull(delegates);
            Assert.IsNotNull(delegates.Delegates);
            Assert.IsTrue(delegates.Success);
            Assert.IsNull(delegates.Error);
        }

        public void GetDelegatesErrorResultTest(SmartHoldemDelegateList delegates)
        {
            Assert.IsNotNull(delegates);
            Assert.IsNull(delegates.Delegates);
            Assert.IsFalse(delegates.Success);
            Assert.IsNotNull(delegates.Error);
        }

        public void GetTopResultTest(SmartHoldemAccountTopList top)
        {
            Assert.IsNotNull(top);
            Assert.IsNotNull(top.Accounts);
            Assert.IsTrue(top.Success);
            Assert.IsNull(top.Error);
            Assert.AreEqual(100, top.Accounts.Count);
        }

        public void GetTopLimitResultTest(SmartHoldemAccountTopList top)
        {
            Assert.IsNotNull(top);
            Assert.IsNotNull(top.Accounts);
            Assert.IsTrue(top.Success);
            Assert.IsNull(top.Error);
            Assert.AreEqual(10, top.Accounts.Count);
        }

        public void GetTopRecordsToSkipResultTest(SmartHoldemAccountTopList top)
        {
            Assert.IsNotNull(top);
            Assert.IsNotNull(top.Accounts);
            Assert.IsTrue(top.Success);
            Assert.IsNull(top.Error);
            Assert.AreEqual(100, top.Accounts.Count);
        }

        public void GetTopLimitAndRecordsToSkipResultTest(SmartHoldemAccountTopList top)
        {
            Assert.IsNotNull(top);
            Assert.IsNotNull(top.Accounts);
            Assert.IsTrue(top.Success);
            Assert.IsNull(top.Error);
            Assert.AreEqual(10, top.Accounts.Count);
        }

        public void GetTopLimitErrorResultTest(SmartHoldemAccountTopList top)
        {
            Assert.IsNotNull(top);
            Assert.IsFalse(top.Success);
            Assert.IsNotNull(top.Error);
        }
    }
}