using System;
using System.Collections.Generic;
using SmartHoldemNet.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using SmartHoldemNet.Model.Delegate;
using SmartHoldemNet.Utils;
using System.Threading.Tasks;
using SmartHoldemNet.Messages.BaseMessages;

namespace SmartHoldemNet.Service
{
    public static class DelegateService
    {
        public static SmartHoldemDelegateList GetAll()
        {
            return GetAllAsync().Result;
        }

        public async static Task<SmartHoldemDelegateList> GetAllAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_ALL);

            return JsonConvert.DeserializeObject<SmartHoldemDelegateList>(response);
        }

        public static SmartHoldemDelegateList GetDelegates(SmartHoldemBaseRequest req)
        {
            return GetDelegatesAsync(req).Result;
        }

        public async static Task<SmartHoldemDelegateList> GetDelegatesAsync(SmartHoldemBaseRequest req)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_ALL + "{0}", req.ToQuery()));

            return JsonConvert.DeserializeObject<SmartHoldemDelegateList>(response);
        }

        public static SmartHoldemDelegateResponse GetByUsername(string username)
        {
            return GetByUsernameAsync(username).Result;
        }

        public async static Task<SmartHoldemDelegateResponse> GetByUsernameAsync(string username)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_BY_USERNAME, username));

            return JsonConvert.DeserializeObject<SmartHoldemDelegateResponse>(response);
        }

        public static SmartHoldemDelegateResponse GetByPubKey(string pubKey)
        {
            return GetByPubKeyAsync(pubKey).Result;
        }

        public async static Task<SmartHoldemDelegateResponse> GetByPubKeyAsync(string pubKey)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_BY_PUBLIC_KEY, pubKey));

            return JsonConvert.DeserializeObject<SmartHoldemDelegateResponse>(response);
        }

        public static SmartHoldemDelegateVoterList GetVoters(string pubKey)
        {
            return GetVotersAsync(pubKey).Result;
        }

        public async static Task<SmartHoldemDelegateVoterList> GetVotersAsync(string pubKey)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_VOTERS, pubKey));

            return JsonConvert.DeserializeObject<SmartHoldemDelegateVoterList>(response);
        }

        public static long GetFee()
        {
            return GetFeeAsync().Result;
        }

        public async static Task<long> GetFeeAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_FEE);
            var parsed = JObject.Parse(response);

            return Int64.Parse(parsed["fee"].ToString());
        }

        public static SmartHoldemDelegateForgedBalance GetForgedByAccount(string pubKey)
        {
            return GetForgedByAccountAsync(pubKey).Result;
        }

        public async static Task<SmartHoldemDelegateForgedBalance> GetForgedByAccountAsync(string pubKey)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_FORGED, pubKey));

            return JsonConvert.DeserializeObject<SmartHoldemDelegateForgedBalance>(response);
        }

        public static SmartHoldemDelegateNextForgers GetNextForgers()
        {
            return GetNextForgersAsync().Result;
        }

        public async static Task<SmartHoldemDelegateNextForgers> GetNextForgersAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Delegate.GET_NEXT_FORGERS);

            return JsonConvert.DeserializeObject<SmartHoldemDelegateNextForgers>(response);
        }

        public static long GetTotalVoteSmartHoldem(string pubKey)
        {
            var SmartHoldemDelegate = GetByPubKey(pubKey);

            if (SmartHoldemDelegate.Success && SmartHoldemDelegate.Delegate != null)
            {
                return SmartHoldemDelegate.Delegate.Vote;
            }

            return 0;
        }

        public async static Task<long> GetTotalVoteSmartHoldemAsync(string pubKey)
        {
            var SmartHoldemDelegate = await GetByPubKeyAsync(pubKey);

            if (SmartHoldemDelegate.Success && SmartHoldemDelegate.Delegate != null)
            {
                return SmartHoldemDelegate.Delegate.Vote;
            }

            return 0;
        }
    }
}