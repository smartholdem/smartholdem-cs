using System;
using System.Collections.Generic;
using SmartHoldemNet;
using SmartHoldemNet.Core;
using SmartHoldemNet.Utils.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBitcoin;
using NBitcoin.DataEncoders;
using SmartHoldemNet.Tests;

namespace SmartHoldemNetTest.Tests
{
	[TestClass]
	public class TransactionCryptoTests : TestsBase
	{
        private string _passPhrase = "this is a test";
        private string _address = "Sa9JKodiNeM7tbYjxwEhvvG1kBczhQxTN3";
        private string _addressFromCrypto = "SgfSC4H3AViZHwf1MeXaThsvJBThwV1AS9";
        private string _pubKey = "0259dc2549cf0e7c7bd2a0c203bb6bebf12a7ca468e130d86fcbc9ffb6b52f0eda";

        [TestInitialize]
	    public void Init()
	    {
            base.Initialize();

            if (USE_DEV_NET)
            {
                _passPhrase = "essay pledge slab slush avocado check icon genre scale nut surround hat";
                _address = "DLDuxqCFtA2ZvBQWSMKWnpQUL2wgtvAxhn";
                _addressFromCrypto = "DJi22Q2R5JPV9hgmRr5YyxPcvNPAM4AzDC";
                _pubKey = "0223ccfaee704337d650687b3377bdac12206473e6fef8aab448f26ee9d4647257";
            }
        }

        [TestMethod]
		public void GetKeysTest()
		{
			var key = Crypto.GetKeys(_passPhrase);

			Assert.AreEqual(key.PubKey.ToString(), _pubKey);
		}


		[TestMethod]
		public void GetAddressTest()
		{
			var a1 = Crypto.GetAddress(Crypto.GetKeys(_passPhrase),SmartHoldemNetApi.Instance.NetworkSettings.BytePrefix);
			var a2 = _addressFromCrypto;

			Assert.AreEqual(a2, a1);
		}

		[TestMethod]
		public void CreateTransactionPassPhraseVerifyTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase);


			Assert.IsTrue(Crypto.Verify(tx));
		}

		[TestMethod]
		public void JSONSerDeSerTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase);
			var json = tx.ToJson();
			Console.WriteLine(json);

			var tx2 = TransactionApi.FromJson(json);

			Assert.AreEqual(json, tx2.ToJson());
		}

		[TestMethod]
		public void JSONSerDeSerNegTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase);
			var json = tx.ToJson();
			Console.WriteLine(json);

			var tx2 = TransactionApi.FromJson(json);
			tx2.SignSignature = "Change";

			Assert.AreNotEqual(json, tx2.ToJson());
		}

		[TestMethod]
		public void CreateTransaction2ndPassPhraseandVerifyTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase,
                "this is a top secret second passphrase");

			var secondPublicKeyHex = Crypto.GetKeys("this is a top secret second passphrase").PubKey.ToBytes();

			var secondPublicKeyHexStr = Encoders.Hex.EncodeData(secondPublicKeyHex);

			Assert.IsTrue(Crypto.Verify(tx));
			Assert.IsTrue(Crypto.SecondVerify(tx, secondPublicKeyHexStr));
		}

		[TestMethod]
		public void CreateTransactionAmountChangeTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase);
			var json = tx.ToJson();

			tx.Amount = 10100000000000000;

			Assert.IsFalse(Crypto.Verify(tx));
			Assert.AreNotEqual(json, tx.ToJson());
		}


		[TestMethod]
		public void CreateTransactionFeeChangeTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase);
			var json = tx.ToJson();

			tx.Fee = 11;

			Assert.IsFalse(Crypto.Verify(tx));
			Assert.AreNotEqual(json, tx.ToJson());
		}


		[TestMethod]
		public void CreateTransactionRecepientChangeTest()
		{
			var tx = TransactionApi.CreateTransaction(_address,
				1,
				"This is first transaction from SMARTHOLDEM-NET",
                _passPhrase);
			var json = tx.ToJson();

			tx.RecipientId = "SbNu1nZevSh1Qx9zL4VjqatcE7DQSnLn37";

			Assert.IsFalse(Crypto.Verify(tx));
			Assert.AreNotEqual(json, tx.ToJson());
		}

		[TestMethod]
		public void CreateDelegateTest()
		{
			var tx = TransactionApi.CreateDelegate("testdelegate", _passPhrase);
			var json = tx.ToJson();

			Assert.IsTrue(Crypto.Verify(tx));
			Assert.AreEqual(json, tx.ToJson());
		}

	    [TestMethod]
	    public void CreateVoteSignTest()
	    {
	        List<string> votes = new List<string> { "+020664026362dce27637b8f77039b5158ec0e53dac9ad0cca7a15b55d9a6556ba0" };


	        var tx = TransactionApi.CreateVote(votes, _passPhrase);

	        var json = tx.ToObject(true);
            Assert.IsTrue(Crypto.Verify(tx));
	        Assert.AreEqual(json, tx.ToObject(true));
	    }
    }
}