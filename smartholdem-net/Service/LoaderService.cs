using System.Collections.Generic;
using SmartHoldemNet.Core;
using SmartHoldemNet.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartHoldemNet.Model.Loader;
using SmartHoldemNet.Utils;
using System.Threading.Tasks;

namespace SmartHoldemNet.Service
{
    public static class LoaderService
    {
        public static SmartHoldemLoaderStatus GetStatus()
        {
            return GetStatusAsync().Result;
        }

        public async static Task<SmartHoldemLoaderStatus> GetStatusAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Loader.GET_STATUS);

            return JsonConvert.DeserializeObject<SmartHoldemLoaderStatus>(response);
        }

        public static SmartHoldemLoaderStatusSync GetSyncStatus()
        {
            return GetSyncStatusAsync().Result;
        }

        public async static Task<SmartHoldemLoaderStatusSync> GetSyncStatusAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Loader.GET_SYNC_STATUS);

            return JsonConvert.DeserializeObject<SmartHoldemLoaderStatusSync>(response);
        }


        public static SmartHoldemLoaderNetworkResponse GetAutoConfigureParameters()
        {
            return GetAutoConfigureParametersAsync().Result;
        }

        public async static Task<SmartHoldemLoaderNetworkResponse> GetAutoConfigureParametersAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Loader.GET_AUTO_CONFIGURE);

            return JsonConvert.DeserializeObject<SmartHoldemLoaderNetworkResponse>(response);
        }
    }
}