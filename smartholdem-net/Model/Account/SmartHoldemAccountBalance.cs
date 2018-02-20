using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Account
{
    public class SmartHoldemAccountBalance : SmartHoldemResponseBase
    {
        public long Balance { get; set; }
        public long UnconfirmedBalance { get; set; }
    }
}
