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
    public class PeerServiceTests : PeerServiceTestsBase
    {
        [TestInitialize]
        public void Init()
        {
            base.InitializePeerServiceTest();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var peers = PeerService.GetAll().Peers.Where(x => x.Status.Equals("OK"));
            var peer = peers.FirstOrDefault();

            GetAllResultTest(peer);
        }

        [TestMethod()]
        public void GetPeerTest()
        {
            var peer = PeerService.GetPeer(base._ip, base._port);

            GetPeerResultTest(peer);
        }

        [TestMethod()]
        public void GetPeerStatusTest()
        {
            var peer = PeerService.GetPeerStatus();

            GetPeerStatusResultTest(peer);
        }

        [TestMethod]
        public void SwitchPeerTest()
        {
            NetworkApi.Instance.ActivePeer = new PeerApi("1.1.1.1", 5000);

            var peer = PeerService.GetPeer(base._ip, base._port);

            GetPeerResultTest(peer);
        }
    }
}