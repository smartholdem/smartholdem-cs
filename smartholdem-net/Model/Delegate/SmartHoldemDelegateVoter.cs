using SmartHoldemNet.Model.BaseModels;
using System.Collections.Generic;

namespace SmartHoldemNet.Model.Delegate
{
    public class SmartHoldemDelegateVoter
    {
        public object Username { get; set; }
        public string Address { get; set; }
        public string PublicKey { get; set; }
        public long Balance { get; set; }
    }
}