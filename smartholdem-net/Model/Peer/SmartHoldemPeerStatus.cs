using SmartHoldemNet.Model.BaseModels;

namespace SmartHoldemNet.Model.Peer
{
    public class SmartHoldemPeerStatus : SmartHoldemResponseBase
    {
        public int Height { get; set; }
        public bool ForgingAllowed { get; set; }
        public int CurrentSlot { get; set; }
        public SmartHoldemPeerHeader Header { get; set; }
    }
}