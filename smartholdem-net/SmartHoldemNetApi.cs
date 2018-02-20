using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils;
using SmartHoldemNet.Utils.Enum;
using NBitcoin.DataEncoders;
using SmartHoldemNet.Core;
using Newtonsoft.Json;
using SmartHoldemNet.Model.Loader;
using Newtonsoft.Json.Linq;
using SmartHoldemNet.Model.Peer;

namespace SmartHoldemNet
{
    public sealed class SmartHoldemNetApi
    {
        private List<Tuple<string, int>> _peerSeedListMainNet = 
            new List<Tuple<string, int>> {
            Tuple.Create("213.239.207.170", 6100),
            Tuple.Create("194.87.109.123", 6100),
            Tuple.Create("195.133.197.97", 6100),
            Tuple.Create("88.198.67.196", 6100),
            Tuple.Create("195.133.144.144", 6100),
            Tuple.Create("194.87.146.50", 6100),
            Tuple.Create("194.87.109.162", 6100),
            Tuple.Create("194.87.97.190", 6100),
            Tuple.Create("194.87.109.198", 6100),
            Tuple.Create("194.87.95.30", 6100),
            Tuple.Create("195.133.197.108", 6100)
            };

        private List<Tuple<string, int>> _peerSeedListDevNet =
            new List<Tuple<string, int>> {
            Tuple.Create("95.183.9.205", 4100),
            Tuple.Create("88.198.67.196", 4100),
            Tuple.Create("194.87.109.198", 4100),
            Tuple.Create("194.87.232.27", 4100),
            Tuple.Create("194.87.146.50", 4100),
            Tuple.Create("194.87.109.123", 4100),
            Tuple.Create("95.183.9.207", 4100),
            Tuple.Create("195.133.1.3", 4100),
            Tuple.Create("95.183.9.191", 4100)
            };

        private static readonly Lazy<SmartHoldemNetApi> _lazy =
            new Lazy<SmartHoldemNetApi>(() => new SmartHoldemNetApi());

        public static SmartHoldemNetApi Instance => _lazy.Value;

        public SmartHoldemNetworkSettings NetworkSettings;

        private SmartHoldemNetApi()
        {
            
        }

        public async Task Start(NetworkType type)
        {
            await SetNetworkSettings(await GetInitialPeer(type));
        }

        public async Task Start(string initialPeerIp, int initialPeerPort)
        {
            await SetNetworkSettings(GetInitialPeer(initialPeerIp, initialPeerPort));
        }

        private async Task SetNetworkSettings(PeerApi initialPeer)
        {
            var responseAutoConfigure = await initialPeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Loader.GET_AUTO_CONFIGURE);
            var responseFees = await initialPeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, SmartHoldemStaticStrings.SmartHoldemApiPaths.Block.GET_FEES);
            var responsePeer = await initialPeer.MakeRequest(SmartHoldemStaticStrings.SmartHoldemHttpMethods.GET, string.Format(SmartHoldemStaticStrings.SmartHoldemApiPaths.Peer.GET, initialPeer.Ip, initialPeer.Port));

            var autoConfig = JsonConvert.DeserializeObject<SmartHoldemLoaderNetworkResponse>(responseAutoConfigure);
            var fees = JsonConvert.DeserializeObject<Fees>(JObject.Parse(responseFees)["fees"].ToString());
            var peer = JsonConvert.DeserializeObject<SmartHoldemPeerResponse>(responsePeer);

            NetworkSettings = new SmartHoldemNetworkSettings()
            {
                Port = initialPeer.Port,
                BytePrefix = (byte)autoConfig.Network.Version,
                Version = peer.Peer.Version,
                NetHash = autoConfig.Network.NetHash,
                Fee = fees
            };

            await NetworkApi.Instance.WarmUp(new PeerApi(initialPeer.Ip, initialPeer.Port));
        }

        private PeerApi GetInitialPeer(string initialPeerIp, int initialPeerPort)
        {
            return new PeerApi(initialPeerIp, initialPeerPort);
        }

        private async Task<PeerApi> GetInitialPeer(NetworkType type, int retryCount = 0)
        {
            var peerUrl = _peerSeedListMainNet[new Random().Next(_peerSeedListMainNet.Count)];
            if (type == NetworkType.DevNet)
                peerUrl = _peerSeedListDevNet[new Random().Next(_peerSeedListDevNet.Count)];

            var peer = new PeerApi(peerUrl.Item1, peerUrl.Item2);
            if (await peer.IsOnline())
            {
                return peer;
            }

            if ((type == NetworkType.DevNet && retryCount == _peerSeedListDevNet.Count) 
             || (type == NetworkType.MainNet && retryCount == _peerSeedListMainNet.Count))
                throw new Exception("Unable to connect to a seed peer");

            return await GetInitialPeer(type, retryCount + 1);
        }
    }
}
