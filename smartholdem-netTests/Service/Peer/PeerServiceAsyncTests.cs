using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;
using SmartHoldemNet.Core;

namespace SmartHoldemNet.Service.Peer.Tests
{
    [TestClass()]
    public class PeerServiceAsyncTests : PeerServiceTestsBase
    {
        [TestInitialize]
        public async Task Init()
        {
            await base.InitializePeerServiceAsyncTest();
        }

        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            var peers = await PeerService.GetAllAsync();
            var peer = peers.Peers.Where(x => x.Status.Equals("OK")).FirstOrDefault();

            GetAllResultTest(peer);
        }

        [TestMethod()]
        public async Task GetPeerAsyncTest()
        {
            var peer = await PeerService.GetPeerAsync(base._ip, base._port);

            GetPeerResultTest(peer);
        }

        [TestMethod()]
        public async Task GetPeerStatusAsyncTest()
        {
            var peer = await PeerService.GetPeerStatusAsync();

            GetPeerStatusResultTest(peer);
        }

        [TestMethod]
        public async Task SwitchPeerAsyncTest()
        {
            NetworkApi.Instance.ActivePeer = new PeerApi("1.1.1.1", 5000);

            var peer = await PeerService.GetPeerAsync(base._ip, base._port);

            GetPeerResultTest(peer);
        }
    }
}