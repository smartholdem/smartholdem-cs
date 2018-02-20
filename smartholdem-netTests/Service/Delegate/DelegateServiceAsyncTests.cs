using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;
using SmartHoldemNet.Messages.BaseMessages;

namespace SmartHoldemNet.Service.Delegate.Tests
{
    [TestClass()]
    public class DelegateServiceAsyncTests : DelegateServiceTestsBase
    {
        [TestInitialize]
        public async Task Init()
        {
            await base.InitializeDelegateServiceAsyncTest();
        }

        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            var delegates = await DelegateService.GetAllAsync();

            GetAllResultTest(delegates);
        }

        [TestMethod()]
        public async Task GetDelegatesAsyncTest()
        {
            var delegates = await DelegateService.GetDelegatesAsync(new SmartHoldemBaseRequest { OrderBy = "vote" });

            GetAllResultTest(delegates);
        }

        [TestMethod()]
        public async Task GetByUsernameAsyncTest()
        {
            var dele = await DelegateService.GetByUsernameAsync(_userName);

            GetByUsernameResultTest(dele);
        }

        [TestMethod()]
        public async Task GetByUsernameErrorAsyncTest()
        {
            var dele = await DelegateService.GetByUsernameAsync("NonExistingPool");

            GetByUsernameErrorResultTest(dele);
        }

        [TestMethod()]
        public async Task GetByPubKeyAsyncTest()
        {
            var dele2 = await DelegateService.GetByPubKeyAsync(_pubKey);

            GetByPubKeyResultTest(dele2);
        }

        [TestMethod()]
        public async Task GetByPubKeyErrorAsyncTest()
        {
            var dele = await DelegateService.GetByPubKeyAsync("ErrorKey");

            GetByPubKeyErrorResultTest(dele);
        }

        [TestMethod()]
        public async Task GetVotersAsyncTest()
        {
            var dele = await DelegateService.GetVotersAsync(_pubKey);

            GetVotersResultTest(dele);
        }

        [TestMethod()]
        public async Task GetVotersErrorAsyncTest()
        {
            var dele = await DelegateService.GetVotersAsync("ErrorKey");

            GetVotersErrorResultTest(dele);
        }

        [TestMethod()]
        public async Task GetFeeAsyncTest()
        {
            var fee = await DelegateService.GetFeeAsync();

            GetFeeResultTest(fee);
        }

        [TestMethod()]
        public async Task GetForgedByAccountAsyncTest()
        {
            var forgedByAccount = await DelegateService.GetForgedByAccountAsync(_pubKey);

            GetForgedByAccountResultTest(forgedByAccount);
        }

        [TestMethod()]
        public async Task GetForgedByAccountErrorAsyncTest()
        {
            var forgedByAccount = await DelegateService.GetForgedByAccountAsync("ErrorKey");

            GetForgedByAccountErrorResultTest(forgedByAccount);
        }

        [TestMethod()]
        public async Task GetNextForgersAsyncTest()
        {
            var nextForgers = await DelegateService.GetNextForgersAsync();

            GetNextForgersResultTest(nextForgers);
        }

        [TestMethod()]
        public async Task GetTotalVoteSmartHoldemAsyncTest()
        {
            var totalVoteSmartHoldem = await DelegateService.GetTotalVoteSmartHoldemAsync(_pubKey);

            GetTotalVoteSmartHoldemResultTest(totalVoteSmartHoldem);
        }

        [TestMethod()]
        public async Task GetTotalVoteSmartHoldemErrorAsyncTest()
        {
            var totalVoteSmartHoldem = await DelegateService.GetTotalVoteSmartHoldemAsync("ErrorKey");

            GetTotalVoteSmartHoldemErrorResultTest(totalVoteSmartHoldem);
        }
    }
}