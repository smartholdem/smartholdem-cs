using SmartHoldemNet.Core;
using SmartHoldemNet.Messages.Block;
using SmartHoldemNet.Model;
using SmartHoldemNet.Model.Block;
using SmartHoldemNet.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHoldemNet.Service
{
    public class BlockService
    {
        public static SmartHoldemBlockResponse GetById(string id)
        {
            return GetByIdAsync(id).Result;
        }
        public async static Task<SmartHoldemBlockResponse> GetByIdAsync(string id)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_BLOCK, id));

            return JsonConvert.DeserializeObject<SmartHoldemBlockResponse>(response);
        }

        public static SmartHoldemBlockList GetAll()
        {
            return GetAllAsync().Result;
        }

        public async static Task<SmartHoldemBlockList> GetAllAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_ALL);

            return JsonConvert.DeserializeObject<SmartHoldemBlockList>(response);
        }

        public static SmartHoldemBlockList GetBlocks(SmartHoldemBlockRequest req)
        {
            return GetBlocksAsync(req).Result;
        }

        public async static Task<SmartHoldemBlockList> GetBlocksAsync(SmartHoldemBlockRequest req)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_ALL + "{0}", req.ToQuery()));

            return JsonConvert.DeserializeObject<SmartHoldemBlockList>(response);
        }

        public static DateTime GetEpoch()
        {
            return GetEpochAsync().Result;
        }

        public async static Task<DateTime> GetEpochAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_EPOCH);
            var parsed = JObject.Parse(response);

            return DateTime.Parse(parsed["epoch"].ToString());
        }

        public static long GetHeight()
        {
            return GetHeightAsync().Result;
        }

        public async static Task<long> GetHeightAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_HEIGHT);
            var parsed = JObject.Parse(response);

            return Int64.Parse(parsed["height"].ToString());
        }

        public static string GetNetHash()
        {
            return GetNetHashAsync().Result;
        }

        public async static Task<string> GetNetHashAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_NETHASH);
            var parsed = JObject.Parse(response);

            return parsed["nethash"].ToString();
        }

        public static Fees GetFees()
        {
            return GetFeesAsync().Result;
        }

        public async static Task<Fees> GetFeesAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_FEES);
            var parsed = JObject.Parse(response);

            return JsonConvert.DeserializeObject<Fees>(parsed["fees"].ToString());
        }

        public static int GetMilestone()
        {
            return GetMilestoneAsync().Result;
        }

        public async static Task<int> GetMilestoneAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_MILESTONE);
            var parsed = JObject.Parse(response);

            return Int32.Parse(parsed["milestone"].ToString());
        }

        public static int GetReward()
        {
            return GetRewardAsync().Result;
        }

        public async static Task<int> GetRewardAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_REWARD);
            var parsed = JObject.Parse(response);

            return Int32.Parse(parsed["reward"].ToString());
        }

        public static long GetSupply()
        {
            return GetSupplyAsync().Result;
        }

        public async static Task<long> GetSupplyAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_SUPPLY);
            var parsed = JObject.Parse(response);

            return Int64.Parse(parsed["supply"].ToString());
        }

        public static SmartHoldemBlockChainStatus GetStatus()
        {
            return GetStatusAsync().Result;
        }

        public async static Task<SmartHoldemBlockChainStatus> GetStatusAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_STATUS);

            return JsonConvert.DeserializeObject<SmartHoldemBlockChainStatus>(response);
        }
    }
}
