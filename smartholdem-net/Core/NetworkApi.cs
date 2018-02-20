using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHoldemNet.Service;

namespace SmartHoldemNet.Core
{
    public sealed class NetworkApi
    {
        private static readonly Lazy<NetworkApi> lazy =
            new Lazy<NetworkApi>(() => new NetworkApi());

        private readonly Random _random = new Random();
        private List<PeerApi> _peers = new List<PeerApi>();

        private NetworkApi()
        {
            _peers = new List<PeerApi>();
        }

        public static NetworkApi Instance => lazy.Value;
   
        public string Nethash { get; set; } = SmartHoldemNetApi.Instance.NetworkSettings.NetHash; 
        public int Port { get; set; } = SmartHoldemNetApi.Instance.NetworkSettings.Port;
        public byte Prefix { get; set; } = SmartHoldemNetApi.Instance.NetworkSettings.BytePrefix;
        public string Version { get; set; } = SmartHoldemNetApi.Instance.NetworkSettings.Version;
        public int BroadcastMax { get; set; } = SmartHoldemNetApi.Instance.NetworkSettings.MaxNumOfBroadcasts;
        public PeerApi ActivePeer { get; set; }

        public async Task WarmUp(PeerApi initialPeer)
        {
            ActivePeer = initialPeer;
            await SetPeerList();
            ActivePeer = GetRandomPeer();
            StartPeerCleaningTask();
        }

        public PeerApi GetRandomPeer()
        {
            return _peers[_random.Next(_peers.Count())];
        }

        public void SwitchPeer()
        {
            ActivePeer = GetRandomPeer();
        }

        private async Task SetPeerList()
        {
            var peers = await PeerService.GetAllAsync();
            var peersOrderByHeight = peers.Peers
                .Where(x => x.Status.Equals("OK") && x.Version == SmartHoldemNetApi.Instance.NetworkSettings.Version)
                .OrderByDescending(x => x.Height)
                .ToList();

            var heightToCompare = peersOrderByHeight.FirstOrDefault().Height - SmartHoldemNetApi.Instance.NetworkSettings.PeerCleaningHeightThreshold;

            var peerURLs = peersOrderByHeight.Where(x => x.Height >= heightToCompare)
                .Select(x => new { Ip = x.Ip, Port = x.Port })
                .ToList();

            var tmpPeerList = new List<PeerApi>();
            foreach (var peerURL in peerURLs)
            {
                tmpPeerList.Add(new PeerApi(peerURL.Ip, peerURL.Port));
            }

            if (!tmpPeerList.Any(x => x.Ip == NetworkApi.Instance.ActivePeer.Ip))
                tmpPeerList.Add(NetworkApi.Instance.ActivePeer);

            _peers = tmpPeerList;
        }

        private void StartPeerCleaningTask()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromMinutes(SmartHoldemNetApi.Instance.NetworkSettings.PeerCleaningIntervalInMinutes));
                    try
                    {
                        await SetPeerList();
                    }
                    catch { }
                }
            });
        }
    }
}