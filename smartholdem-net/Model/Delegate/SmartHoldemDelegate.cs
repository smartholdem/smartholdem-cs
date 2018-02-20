using SmartHoldemNet.Model.BaseModels;
using System.Collections.Generic;

namespace SmartHoldemNet.Model.Delegate
{
    public class SmartHoldemDelegate
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string PublicKey { get; set; }
        public long Vote { get; set; }
        public int Producedblocks { get; set; }
        public int Missedblocks { get; set; }
        public int Rate { get; set; }
        public float Approval { get; set; }
        public float Productivity { get; set; }
    }
}