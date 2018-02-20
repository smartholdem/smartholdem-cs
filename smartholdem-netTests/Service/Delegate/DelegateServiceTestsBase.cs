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
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Service.Delegate.Tests
{
    public class DelegateServiceTestsBase : TestsBase
    {
        protected string _userName = "gendelegate_1";
        protected string _resultUserNameFromPubKey = "gendelegate_2";
        protected string _pubKey = "0259dc2549cf0e7c7bd2a0c203bb6bebf12a7ca468e130d86fcbc9ffb6b52f0eda";
        protected string _address = "SgfSC4H3AViZHwf1MeXaThsvJBThwV1AS9";

        public void InitializeDelegateServiceTest()
        {
            base.Initialize();

            Setup();
        }

        public async Task InitializeDelegateServiceAsyncTest()
        {
            await base.InitializeAsync();

            Setup();
        }

        private void Setup()
        {
            if (USE_DEV_NET)
            {
                _userName = "genesis_10";
                _resultUserNameFromPubKey = "genesis_1";
                _pubKey = "035304a8a6a2a671080c45ba7d6fbf61bc6c938be19cf98b52a156b78f2bc6bd7b";
                _address = "ToiwGW7yUFRR6qFxNFty7raVV17vGLtmT8";
            }
        }

        public void GetAllResultTest(SmartHoldemDelegateList delegates)
        {
            Assert.IsNotNull(delegates);
            Assert.IsNotNull(delegates.Delegates);
            Assert.IsTrue(delegates.Success);
            Assert.IsNull(delegates.Error);
            Assert.IsTrue(delegates.Delegates.Count > 0);
        }

        public void GetByUsernameResultTest(SmartHoldemDelegateResponse dele)
        {
            Assert.IsNotNull(dele);
            Assert.IsNotNull(dele.Delegate);
            Assert.IsTrue(dele.Success);
            Assert.IsNull(dele.Error);
            Assert.AreEqual(dele.Delegate.Address, _address);
        }

        public void GetByUsernameErrorResultTest(SmartHoldemDelegateResponse dele)
        {
            Assert.IsNotNull(dele);
            Assert.IsNull(dele.Delegate);
            Assert.IsFalse(dele.Success);
            Assert.IsNotNull(dele.Error);
        }

        public void GetByPubKeyResultTest(SmartHoldemDelegateResponse dele2)
        {
            Assert.IsNotNull(dele2);
            Assert.IsNotNull(dele2.Delegate);
            Assert.IsTrue(dele2.Success);
            Assert.IsNull(dele2.Error);
            Assert.AreEqual(dele2.Delegate.Username, _resultUserNameFromPubKey);
        }

        public void GetByPubKeyErrorResultTest(SmartHoldemDelegateResponse dele)
        {
            Assert.IsNotNull(dele);
            Assert.IsNull(dele.Delegate);
            Assert.IsFalse(dele.Success);
            Assert.IsNotNull(dele.Error);
        }

        public void GetVotersResultTest(SmartHoldemDelegateVoterList dele)
        {
            Assert.IsNotNull(dele);
            Assert.IsNotNull(dele.Accounts);
            Assert.IsTrue(dele.Success);
            Assert.IsNull(dele.Error);
            Assert.IsTrue(dele.Accounts.Count > 0);
        }

        public void GetVotersErrorResultTest(SmartHoldemDelegateVoterList dele)
        {
            Assert.IsNotNull(dele);
            Assert.IsNull(dele.Accounts);
            Assert.IsFalse(dele.Success);
            Assert.IsNotNull(dele.Error);
        }

        public void GetFeeResultTest(long fee)
        {
            Assert.IsTrue(fee > 0);
        }

        public void GetForgedByAccountResultTest(SmartHoldemDelegateForgedBalance forgedByAccount)
        {
            Assert.IsNotNull(forgedByAccount);
            Assert.IsTrue(forgedByAccount.Success);
            Assert.IsNull(forgedByAccount.Error);
        }

        public void GetForgedByAccountErrorResultTest(SmartHoldemDelegateForgedBalance forgedByAccount)
        {
            Assert.IsNotNull(forgedByAccount);
            Assert.IsFalse(forgedByAccount.Success);
            Assert.IsNotNull(forgedByAccount.Error);
        }

        public void GetNextForgersResultTest(SmartHoldemDelegateNextForgers nextForgers)
        {
            Assert.IsNotNull(nextForgers);
            Assert.IsNotNull(nextForgers.Delegates);
        }

        public void GetTotalVoteSmartHoldemResultTest(long totalVoteSmartHoldem)
        {
            Assert.IsNotNull(totalVoteSmartHoldem);
        }

        public void GetTotalVoteSmartHoldemErrorResultTest(long totalVoteSmartHoldem)
        {
            Assert.AreEqual(0, totalVoteSmartHoldem);
        }
    }
}