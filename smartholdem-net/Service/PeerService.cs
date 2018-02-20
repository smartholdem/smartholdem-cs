using System.Collections.Generic;
using SmartHoldemNet.Core;
using SmartHoldemNet.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartHoldemNet.Model.Peer;
using SmartHoldemNet.Utils;
using System.Threading.Tasks;

namespace SmartHoldemNet.Service
{
    public static class PeerService
    {
        public static SmartHoldemPeerList GetAll()
        {
            return GetAllAsync().Result;
        }

        public async static Task<SmartHoldemPeerList> GetAllAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Peer.GET_ALL);

            return JsonConvert.DeserializeObject<SmartHoldemPeerList>(response);
        }

        public static SmartHoldemPeerResponse GetPeer(string ip, int port)
        {
            return GetPeerAsync(ip, port).Result;
        }

        public async static Task<SmartHoldemPeerResponse> GetPeerAsync(string ip, int port)
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Peer.GET, ip, port));

            return JsonConvert.DeserializeObject<SmartHoldemPeerResponse>(response);
        }

        public static SmartHoldemPeerStatus GetPeerStatus()
        {
            return GetPeerStatusAsync().Result;
        }

        public async static Task<SmartHoldemPeerStatus> GetPeerStatusAsync()
        {
            var response = await NetworkApi.Instance.ActivePeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Peer.GET_STATUS);

            return JsonConvert.DeserializeObject<SmartHoldemPeerStatus>(response);
        }
    }
}