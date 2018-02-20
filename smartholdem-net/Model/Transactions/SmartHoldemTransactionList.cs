using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Transactions
{
    public class SmartHoldemTransactionList : SmartHoldemResponseBase
    {
        public int Count { get; set; }

        public List<SmartHoldemTransaction> Transactions { get; set; }
    }
}
