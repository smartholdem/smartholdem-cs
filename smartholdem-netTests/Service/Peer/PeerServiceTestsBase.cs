using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;
using SmartHoldemNet.Model.Account;
using SmartHoldemNet.Model.Delegate;
using SmartHoldemNet.Model.Block;
using SmartHoldemNet.Utils;
using SmartHoldemNet.Model.Loader;
using SmartHoldemNet.Model.Peer;
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Service.Peer.Tests
{
    public class PeerServiceTestsBase : TestsBase
    {
        protected string _ip = "213.239.207.170";
        protected int _port = 6100;

        public void InitializePeerServiceTest()
        {
            base.Initialize();

            Setup();
        }

        public async Task InitializePeerServiceAsyncTest()
        {
            await base.InitializeAsync();

            Setup();
        }

        private void Setup()
        {
            if (base.USE_DEV_NET)
            {
                _ip = "88.198.67.196";
                _port = 4100;
            }
        }

        public void GetPeerResultTest(SmartHoldemPeerResponse peer)
        {
            Assert.IsNotNull(peer);
            Assert.IsNotNull(peer.Peer);
            Assert.IsNull(peer.Error);
            Assert.IsTrue(peer.Success);
            Assert.IsTrue(peer.Peer.Ip == _ip);
            Assert.IsTrue(peer.Peer.Port == _port);
        }

        public void GetAllResultTest(SmartHoldemPeer peer)
        {
            Assert.IsNotNull(peer);
        }

        public void GetPeerStatusResultTest(SmartHoldemPeerStatus status)
        {
            Assert.IsNotNull(status);
            Assert.IsNotNull(status.Header);
            Assert.IsTrue(status.Success);
            Assert.IsNull(status.Error);
        }
    }
}