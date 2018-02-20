using System;
using System.Collections.Generic;
using SmartHoldemNet.Core;
using SmartHoldemNet.Service;
using SmartHoldemNet.Model.Transactions;
using SmartHoldemNet.Model.Account;
using System.Threading.Tasks;
using SmartHoldemNet.Messages.Transaction;

namespace SmartHoldemNet.Controller
{
    public class AccountController
    {
        private SmartHoldemAccount _account;
        private string _passPhrase;
        private string _secondPassPhrase;

        public AccountController(string passphrase, string secondPassPhrase = null)
        {
            _passPhrase = passphrase;
            _secondPassPhrase = secondPassPhrase;
        }

        public SmartHoldemAccount GetSmartHoldemAccount()
        {
            if (_account == null)
                _account = AccountService.GetByAddress(Crypto.GetAddress(Crypto.GetKeys(_passPhrase), SmartHoldemNetApi.Instance.NetworkSettings.BytePrefix)).Account;
            return _account;
        }

        public async Task<SmartHoldemAccount> GetSmartHoldemAccountAsync()
        {
            if (_account == null)
            {
                var accountResponse = await AccountService.GetByAddressAsync(Crypto.GetAddress(Crypto.GetKeys(_passPhrase), SmartHoldemNetApi.Instance.NetworkSettings.BytePrefix));
                _account = accountResponse.Account;
            }
            return _account;
        }

        //public bool AskRemoteSignature()
        //{
        //    throw new NotImplementedException();
        //}

        //public void SendMultisignSmartHoldem()
        //{
        //    throw new NotImplementedException();
        //}

        public SmartHoldemTransactionPostResponse SendSTH(long satoshiAmount, string recipientAddress,
            string vendorField)
        {
            var tx = TransactionApi.CreateTransaction(recipientAddress,
                satoshiAmount,
                vendorField,
                _passPhrase,
                _secondPassPhrase);

            return TransactionService.PostTransaction(tx);
        }

        public async Task<SmartHoldemTransactionPostResponse> SendSTHAsync(long satoshiAmount, string recipientAddress,
            string vendorField)
        {
            var tx = TransactionApi.CreateTransaction(recipientAddress,
                satoshiAmount,
                vendorField,
                _passPhrase,
                _secondPassPhrase);

            return await TransactionService.PostTransactionAsync(tx);
        }

        public List<SmartHoldemTransactionPostResponse> SendSTHUsingMultiBroadCast(long satoshiAmount, string recipientAddress,
            string vendorField)
        {
            var tx = TransactionApi.CreateTransaction(recipientAddress,
                satoshiAmount,
                vendorField,
                _passPhrase,
                _secondPassPhrase);

            return TransactionService.MultipleBroadCast(tx);
        }

        public async Task<List<SmartHoldemTransactionPostResponse>> SendSTHUsingMultiBroadCastAsync(long satoshiAmount, string recipientAddress,
            string vendorField)
        {
            var tx = TransactionApi.CreateTransaction(recipientAddress,
                satoshiAmount,
                vendorField,
                _passPhrase,
                _secondPassPhrase);

            return await TransactionService.MultipleBroadCastAsync(tx);
        }

        public SmartHoldemTransactionPostResponse VoteForDelegate(List<string> votes)
        {
            var tx = TransactionApi.CreateVote(votes, _passPhrase, _secondPassPhrase);

            return TransactionService.PostTransaction(tx);
        }

        public async Task<SmartHoldemTransactionPostResponse> VoteForDelegateAsync(List<string> votes)
        {
            var tx = TransactionApi.CreateVote(votes, _passPhrase, _secondPassPhrase);

            return await TransactionService.PostTransactionAsync(tx);
        }

        public SmartHoldemTransactionPostResponse RegisterAsDelegate(string username)
        {
            var tx = TransactionApi.CreateDelegate(username, _passPhrase, _secondPassPhrase);

            return TransactionService.PostTransaction(tx);
        }

        public async Task<SmartHoldemTransactionPostResponse> RegisterAsDelegateAsync(string username)
        {
            var tx = TransactionApi.CreateDelegate(username, _passPhrase, _secondPassPhrase);

            return await TransactionService.PostTransactionAsync(tx);
        }

        public bool UpdateBalance()
        {
            var account = GetSmartHoldemAccount();
            var res = AccountService.GetBalance(account.Address);

            account.Balance = res.Balance;
            account.UnconfirmedBalance = res.UnconfirmedBalance;

            return res.Success;
        }

        public async Task<bool> UpdateBalanceAsync()
        {
            var account = await GetSmartHoldemAccountAsync();
            var res = await AccountService.GetBalanceAsync(account.Address);

            account.Balance = res.Balance;
            account.UnconfirmedBalance = res.UnconfirmedBalance;

            return res.Success;
        }

        public SmartHoldemTransactionList GetTransactions(int offset = 0, int limit = 50)
        {
            return TransactionService.GetTransactions(GetSmartHoldemAccount().Address, offset, limit);
        }

        public async Task<SmartHoldemTransactionList> GetTransactionsAsync(int offset = 0, int limit = 50)
        {
            return await TransactionService.GetTransactionsAsync(GetSmartHoldemAccount().Address, offset, limit);
        }

        public SmartHoldemTransactionList GetUnconfirmedTransactions()
        {
            return TransactionService.GetUnconfirmedTransactions(GetSmartHoldemAccount().Address);
        }

        public async Task<SmartHoldemTransactionList> GetUnconfirmedTransactionsAsync()
        {
            return await TransactionService.GetUnconfirmedTransactionsAsync(GetSmartHoldemAccount().Address);
        }

        //public bool RemoteSign()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool RegisterSecondSignature()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool GetVoterContribution()
        //{
        //    throw new NotImplementedException();
        //}
    }
}