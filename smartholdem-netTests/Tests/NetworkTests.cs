using System.IO;
using SmartHoldemNet;
using SmartHoldemNet.Core;
using SmartHoldemNet.Service;
using SmartHoldemNet.Utils;
using SmartHoldemNet.Utils.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Tests;
using System.Threading.Tasks;
using System.Linq;

namespace SmartHoldemNetTest.Tests
{
    [TestClass]
	public class NetworkTests : TestsBase
	{
        /* TEST MAIN WALLET
	     Adress: "SgfSC4H3AViZHwf1MeXaThsvJBThwV1AS9"
	     pass: seat excess fat category basic entire salute feed various guard treat history
	     */

        private string _address = "Sa9JKodiNeM7tbYjxwEhvvG1kBczhQxTN3";
        private string _passPhrase = "this is a test";
        private string _noBalanceAddress = "Si71eBSBe7gDJaW8krAN9UTfFwee5BdJwd";
        private string _noBalanceAddressPassPhrase = "rare dove dress alley reveal either machine roast gold book lecture shoot";

        [TestInitialize]
	    public void Init()
	    {
            base.Initialize();

            if (USE_DEV_NET)
            {
                _address = "ToiwGW7yUFRR6qFxNFty7raVV17vGLtmT8";
                _noBalanceAddress = "TnA7H8XaWBjkLty13CEfPJ5NdhPprxGKnP";
                _passPhrase = "sense artefact frame grocery quarter nominee awful gossip village fuel favorite drill";
                _noBalanceAddressPassPhrase = "this is a test";
            }
	    }

        [TestMethod]
		public void PostTransactionNoBalanceTest()
		{
			var tx = TransactionApi.CreateTransaction(_noBalanceAddress,
				133380000000,
				"This is first transaction from SmartHoldem-NET",
                _noBalanceAddressPassPhrase);

			var result = TransactionService.PostTransaction(tx);

			Assert.AreEqual(result.Error, string.Format("Account does not have enough STH: {0} balance: 0", _noBalanceAddress));
		}


		[TestMethod]
		public void TransactionSerializeTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SmartHoldem-NET 22",
                _passPhrase);

			tx.Timestamp = 100;
			File.WriteAllText(@"C:\temp\txNew.json", tx.SerializeObject2JSon());
			File.WriteAllText(@"C:\temp\txNew.xml", tx.SerializeObject2Xml());

			Assert.IsTrue(1 == 1);
		}


		[TestMethod]
		public void PostTransactionTransferTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SmartHoldem-NET 22",
				_passPhrase);

			var result = TransactionService.PostTransaction(tx);

			Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.TransactionIds);
            Assert.IsTrue(result.TransactionIds.Count > 0);
        }

		[TestMethod]
		public void MultiplePostTransactionSuccessTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first Multi transaction from SmartHoldem-NET",
                _passPhrase);

			var res = TransactionService.MultipleBroadCast(tx);

			Assert.IsTrue(res.Where(x => x.Success).Count() > 0);
		}

        [TestMethod]
        public async Task MultiplePostTransactionAsyncSuccessTest()
        {
            var tx = TransactionApi.CreateTransaction(_address,
                1,
                "This is first Multi transaction from SmartHoldem-NET",
                _passPhrase);

            var res = await TransactionService.MultipleBroadCastAsync(tx);

            Assert.IsTrue(res.Where(x => x.Success).Count() > 0);
        }
    }
}