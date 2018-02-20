using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Block
{
    public class SmartHoldemBlockResponse : SmartHoldemResponseBase
    {
        public SmartHoldemBlock Block { get; set; }
    }
}
