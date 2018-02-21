using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Model;
using SmartHoldemNet.Service;
using SmartHoldemNet.Utils.Enum;
using Newtonsoft.Json;
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Controller.Tests
{
    [TestClass()]
    public class AccountControllerTests : TestsBase
    {
        private string _address = "SgfSC4H3AViZHwf1MeXaThsvJBThwV1AS9";
        private string _pubKey = "0259dc2549cf0e7c7bd2a0c203bb6bebf12a7ca468e130d86fcbc9ffb6b52f0eda";
        private string _passPhrase = "seat excess fat category basic entire salute feed various guard treat history";
        private string _delegateName = "gendelegate_1";

        [TestInitialize]
        public void Init()
        {
            base.Initialize();

            if (USE_DEV_NET)
            {
                _address = "ToiwGW7yUFRR6qFxNFty7raVV17vGLtmT8";
                _pubKey = "035304a8a6a2a671080c45ba7d6fbf61bc6c938be19cf98b52a156b78f2bc6bd7b";
                _passPhrase = "sense artefact frame grocery quarter nominee awful gossip village fuel favorite drill";
                _delegateName = "genesis_10 ";
            }
        }

        [TestMethod()]
        public void CreateAccountTest()
        {
            var accCtnrl = new AccountController(_passPhrase);

            Assert.AreEqual(accCtnrl.GetSmartHoldemAccount().Address, _address);
            Assert.AreEqual(accCtnrl.GetSmartHoldemAccount().PublicKey, _pubKey);
        }

        [TestMethod()]
        public void SendSmartHoldemTest()
        {
            var accCtnrl = new AccountController(_passPhrase);
            var result = accCtnrl.SendSmartHoldem(1, _address, "SmartHoldem.Net test trans from Account");

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.TransactionIds);
            Assert.IsTrue(result.TransactionIds.Count > 0);
        }

        [TestMethod()]
        public void SendSmartHoldemUsingMultiBroadCastTest()
        {
            var accCtnrl = new AccountController(_passPhrase);
            var result = accCtnrl.SendSmartHoldemUsingMultiBroadCast(1, _address, "SmartHoldem.Net test multi-trans from Account");

            Assert.IsTrue(result.Where(x => x.Success).Count() > 0);
        }

        [TestMethod()]
        public async Task SendSmartHoldemUsingMultiBroadCastAsyncTest()
        {
            var accCtnrl = new AccountController(_passPhrase);
            var result = await accCtnrl.SendSmartHoldemUsingMultiBroadCastAsync(1, _address, "SmartHoldem.Net test multi-trans from Account");

            Assert.IsTrue(result.Where(x => x.Success).Count() > 0);
        }

        [TestMethod()]
        public void VoteForDelegateTest()
        {
            var dele = DelegateService.GetByUsername(_delegateName);

            List<string> votes = new List<string>();
            votes.Add("+" + dele.Delegate.PublicKey);

            var a2 = JsonConvert.SerializeObject(votes);

            var accCtnrl = new AccountController(_passPhrase);
            var result = accCtnrl.VoteForDelegate(votes);

            Assert.IsTrue(result.Success || (result.Success == false && result.TransactionIds == null && result.Error == "Failed to add vote, account has already voted for this delegate"));
        }

        [TestMethod()]
        public void GetTransactionsTest()
        {
            var accCtnrl = new AccountController(_passPhrase);
            var result = accCtnrl.GetTransactions();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetUnconfirmedTransactionsTest()
        {
            var accCtnrl = new AccountController(_passPhrase);
            var result = accCtnrl.GetUnconfirmedTransactions();

            Assert.IsTrue(result.Count == 0);
        }
    }
}