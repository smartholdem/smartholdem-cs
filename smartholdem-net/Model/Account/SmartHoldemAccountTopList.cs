using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Account
{
    public class SmartHoldemAccountTopList : SmartHoldemResponseBase
    {
        public List<SmartHoldemAccountTop> Accounts { get; set; }
    }
}
