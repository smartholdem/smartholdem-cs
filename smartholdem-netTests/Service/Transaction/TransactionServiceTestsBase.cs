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
using SmartHoldemNet.Model.Peer;
using SmartHoldemNet.Model.Transactions;
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Service.Transaction.Tests
{
    public class TransactionServiceTestsBase : TestsBase
    {
        protected string _blockId = "9116970896546202944";

        public void InitializeTransactionServiceTest()
        {
            base.Initialize();

            Setup();
        }

        public async Task InitializeTransactionServiceAsyncTest()
        {
            await base.InitializeAsync();

            Setup();
        }

        private void Setup()
        {
            if (base.USE_DEV_NET)
            {
                _blockId = "10989145419427330148";
            }
        }

        public void GetAllResultTest(SmartHoldemTransactionList trans)
        {
            Assert.IsNotNull(trans);
            Assert.IsNotNull(trans.Transactions);
            Assert.IsTrue(trans.Success);
            Assert.IsNull(trans.Error);
            Assert.IsTrue(trans.Transactions.Count > 0);
        }

        public void GetTransactionsResultTest(SmartHoldemTransactionList trans)
        {
            Assert.IsNotNull(trans);
            Assert.IsNotNull(trans.Transactions);
            Assert.IsTrue(trans.Success);
            Assert.IsNull(trans.Error);
            if(base.USE_DEV_NET)
                Assert.IsTrue(trans.Transactions.Count == 50);
            else
                Assert.IsTrue(trans.Transactions.Count == 1);
        }

        public void GetByIdResultTest(SmartHoldemTransactionResponse trans1)
        {
            Assert.IsNotNull(trans1);
        }

        public void GetByIdErrorResultTest(SmartHoldemTransactionResponse trans)
        {
            Assert.IsNotNull(trans);
            Assert.IsNull(trans.Transaction);
            Assert.IsFalse(trans.Success);
            Assert.IsNotNull(trans.Error);
        }

        public void GetUnConfirmedByIdResultTest(SmartHoldemTransactionResponse trans1)
        {
            Assert.IsNotNull(trans1);
        }

        public void GetUnConfirmedByIdErrorResultTest(SmartHoldemTransactionResponse trans)
        {
            Assert.IsNotNull(trans);
            Assert.IsNull(trans.Transaction);
            Assert.IsFalse(trans.Success);
            Assert.IsNotNull(trans.Error);
        }

        public void GetUnconfirmedAllResultTest(SmartHoldemTransactionList trans)
        {
            Assert.IsNotNull(trans);
        }
    }
}