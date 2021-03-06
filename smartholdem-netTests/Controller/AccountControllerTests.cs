﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private string _address = "Sa9JKodiNeM7tbYjxwEhvvG1kBczhQxTN3";
        private string _pubKey = "03675c61dcc23eab75f9948c6510b54d34fced4a73d3c9f2132c76a29750e7a614";
        private string _passPhrase = "this is a test";
        private string _delegateName = "tdelegate";

        [TestInitialize]
        public void Init()
        {
            base.Initialize();

            if (USE_DEV_NET)
            {
                _address = "DJi22Q2R5JPV9hgmRr5YyxPcvNPAM4AzDC";
                _pubKey = "0223ccfaee704337d650687b3377bdac12206473e6fef8aab448f26ee9d4647257";
                _passPhrase = "essay pledge slab slush avocado check icon genre scale nut surround hat";
                _delegateName = "reserve01";
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

            List<string> minusVotes = new List<string>();
            List<string> plusVotes = new List<string>();
            plusVotes.Add("+" + dele.Delegate.PublicKey);
            minusVotes.Add("-" + dele.Delegate.PublicKey);

            var accCtnrl = new AccountController(_passPhrase);
            
            accCtnrl.VoteForDelegate(minusVotes);
            System.Threading.Thread.Sleep(20000);
            var result = accCtnrl.VoteForDelegate(plusVotes);

            Assert.IsTrue(result.Success || (result.Success == false && result.TransactionIds == null && result.Error == "Failed to add vote, account has already voted for this delegate"),result.Error);
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