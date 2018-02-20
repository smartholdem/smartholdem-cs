using SmartHoldemNet.Model.BaseModels;
using SmartHoldemNet.Service;
using System.Numerics;

namespace SmartHoldemNet.Model.Account
{
    public class SmartHoldemAccount
    {
        public string Address { get; set; }
        public long UnconfirmedBalance { get; set; }
        public long Balance { get; set; }
        public string PublicKey { get; set; }
        public int UnconfirmedSignature { get; set; }
        public int SecondSignature { get; set; }
        public object SecondPublicKey { get; set; }
        public object[] Multisignatures { get; set; }
        public object[] U_Multisignatures { get; set; }
    }
}