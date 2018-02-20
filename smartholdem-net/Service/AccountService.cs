using System;
using SmartHoldemNet.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using SmartHoldemNet.Model.Account;
using SmartHoldemNet.Model.Delegate;
using SmartHoldemNet.Utils;
using System.Threading.Tasks;

namespace SmartHoldemNet.Service
{
    public class AccountService
    {
        public static SmartHoldemAccountResponse GetByAddress(string address)
        {
            return GetByAddressAsync(address).Result;
        }

        public async static Task<SmartHoldemAccountResponse> GetByAddressAsync(string address)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Account.GET_ACCOUNT, address));

            return JsonConvert.DeserializeObject<SmartHoldemAccountResponse>(response);
        }

        public static SmartHoldemAccountBalance GetBalance(string address)
        {
            return GetBalanceAsync(address).Result;
        }

        public async static Task<SmartHoldemAccountBalance> GetBalanceAsync(string address)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Account.GET_BALANCE, address));

            return JsonConvert.DeserializeObject<SmartHoldemAccountBalance>(response);
        }

        public static SmartHoldemDelegateList GetDelegates(string address)
        {
            return GetDelegatesAsync(address).Result;
        }

        public async static Task<SmartHoldemDelegateList> GetDelegatesAsync(string address)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Account.GET_DELEGATES, address));

            return JsonConvert.DeserializeObject<SmartHoldemDelegateList>(response);
        }

        public static SmartHoldemAccountTopList GetTop(int? limit, int? recordsToSkip)
        {
            return GetTopAsync(limit, recordsToSkip).Result;
        }

        public async static Task<SmartHoldemAccountTopList> GetTopAsync(int? limit, int? recordsToSkip)
        {
            var response =
                await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Account.GET_TOP_ACCOUNTS, limit.HasValue ? limit : 100, recordsToSkip.HasValue ? recordsToSkip : 0));

            return JsonConvert.DeserializeObject<SmartHoldemAccountTopList>(response);
        }
    }
}