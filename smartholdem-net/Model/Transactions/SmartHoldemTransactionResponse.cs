using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Transactions
{
    public class SmartHoldemTransactionResponse : SmartHoldemResponseBase
    {
        public SmartHoldemTransaction Transaction { get; set; }
    }
}
