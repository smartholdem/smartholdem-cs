using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Delegate
{
    public class SmartHoldemDelegateVoterList : SmartHoldemResponseBase
    {
        public List<SmartHoldemDelegateVoter> Accounts { get; set; }
    }
}
