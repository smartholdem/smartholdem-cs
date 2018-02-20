using System;
using System.Collections.Generic;
using SmartHoldemNet.Core;
using SmartHoldemNet.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartHoldemNet.Model.Transactions;
using SmartHoldemNet.Utils;
using System.Threading.Tasks;
using System.Linq;
using SmartHoldemNet.Messages.Transaction;

namespace SmartHoldemNet.Service
{
    public static class TransactionService
    {
        public static SmartHoldemTransactionList GetAll()
        {
            return GetAllAsync().Result;
        }

        public async static Task<SmartHoldemTransactionList> GetAllAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.GET_ALL);

            return JsonConvert.DeserializeObject<SmartHoldemTransactionList>(response);
        }

        public static SmartHoldemTransactionList GetTransactions(SmartHoldemTransactionRequest req)
        {
            return GetTransactionsAsync(req).Result;
        }

        public async static Task<SmartHoldemTransactionList> GetTransactionsAsync(SmartHoldemTransactionRequest req)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.GET_ALL + "{0}", req.ToQuery()));

            return JsonConvert.DeserializeObject<SmartHoldemTransactionList>(response);
        }

        public static SmartHoldemTransactionList GetUnconfirmedAll()
        {
            return GetUnconfirmedAllAsync().Result;
        }

        public async static Task<SmartHoldemTransactionList> GetUnconfirmedAllAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.GET_ALL_UNCONFIRMED);

            return JsonConvert.DeserializeObject<SmartHoldemTransactionList>(response);
        }

        public static SmartHoldemTransactionList GetUnconfirmedTransactions(SmartHoldemUnconfirmedTransactionRequest req)
        {
            return GetUnconfirmedTransactionsAsync(req).Result;
        }

        public async static Task<SmartHoldemTransactionList> GetUnconfirmedTransactionsAsync(SmartHoldemUnconfirmedTransactionRequest req)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.GET_ALL_UNCONFIRMED + "{0}", req.ToQuery()));

            return JsonConvert.DeserializeObject<SmartHoldemTransactionList>(response);
        }

        public static SmartHoldemTransactionResponse GetById(string id)
        {
            return GetByIdAsync(id).Result;
        }

        public async static Task<SmartHoldemTransactionResponse> GetByIdAsync(string id)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.GET_BY_ID, id));

            return JsonConvert.DeserializeObject<SmartHoldemTransactionResponse>(response);
        }

        public static SmartHoldemTransactionResponse GetUnConfirmedById(string id)
        {
            return GetUnConfirmedByIdAsync(id).Result;
        }

        public async static Task<SmartHoldemTransactionResponse> GetUnConfirmedByIdAsync(string id)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.GET_BY_ID_UNCONFIRMED, id));

            return JsonConvert.DeserializeObject<SmartHoldemTransactionResponse>(response);
        }

        public static SmartHoldemTransactionList GetTransactions(string address, int offset = 0, int limit = 50)
        {
            return GetTransactions(new SmartHoldemTransactionRequest { OrderBy = "timestamp:desc", RecipientId = address, SenderId = address, Offset = offset, Limit = limit });
        }

        public async static Task<SmartHoldemTransactionList> GetTransactionsAsync(string address, int offset = 0, int limit = 50)
        {
            return await GetTransactionsAsync(new SmartHoldemTransactionRequest { OrderBy = "timestamp:desc", RecipientId = address, SenderId = address, Offset = offset, Limit = limit });
        }

        public static SmartHoldemTransactionList GetUnconfirmedTransactions(string address)
        {
            return GetUnconfirmedTransactions(new SmartHoldemUnconfirmedTransactionRequest { Address = address });
        }

        public async static Task<SmartHoldemTransactionList> GetUnconfirmedTransactionsAsync(string address)
        {
            return await GetUnconfirmedTransactionsAsync(new SmartHoldemUnconfirmedTransactionRequest { Address = address });
        }

        public static SmartHoldemTransactionPostResponse PostTransaction(TransactionApi transaction, PeerApi peer = null)
        {
            return PostTransactionAsync(transaction, peer).Result;
        }

        public async static Task<SmartHoldemTransactionPostResponse> PostTransactionAsync(TransactionApi transaction, PeerApi peer = null)
        {
            string body = "{transactions: [" + transaction.ToObject(true) + "]} ";

            var response = string.Empty;

            if (peer == null)
                response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.POST, SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.POST, body);
            else
                response = await peer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.POST, SmartHoldemStaticStrings.SmartHoldemApiPaths.Transaction.POST, body);

            return JsonConvert.DeserializeObject<SmartHoldemTransactionPostResponse>(response);
        }

        public static List<SmartHoldemTransactionPostResponse> MultipleBroadCast(TransactionApi transaction)
        {
            var res = new List<SmartHoldemTransactionPostResponse>();

            for (var i = 0; i < SmartHoldemNetApi.Instance.NetworkSettings.MaxNumOfBroadcasts; i++)
            {
                res.Add(PostTransaction(transaction, NetworkApi.Instance.GetRandomPeer()));
            }

            return res;
        }

        public async static Task<List<SmartHoldemTransactionPostResponse>> MultipleBroadCastAsync(TransactionApi transaction)
        {
            var res = new List<SmartHoldemTransactionPostResponse>();

            for (var i = 0; i < SmartHoldemNetApi.Instance.NetworkSettings.MaxNumOfBroadcasts; i++)
            {
                res.Add(await PostTransactionAsync(transaction, NetworkApi.Instance.GetRandomPeer()));
            }

            return res;
        }
    }
}