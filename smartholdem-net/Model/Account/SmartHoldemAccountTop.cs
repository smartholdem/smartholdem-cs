using SmartHoldemNet.Model.BaseModels;
using SmartHoldemNet.Service;
using System.Collections.Generic;
using System.Numerics;

namespace SmartHoldemNet.Model.Account
{
    public class SmartHoldemAccountTop
    {
        public string Address { get; set; }
        public long Balance { get; set; }
        public string PublicKey { get; set; }
    }
}