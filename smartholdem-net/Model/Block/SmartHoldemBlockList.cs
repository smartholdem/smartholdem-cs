using SmartHoldemNet.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHoldemNet.Model.Block
{
    public class SmartHoldemBlockList : SmartHoldemResponseBase
    {
        public List<SmartHoldemBlock> Blocks { get; set; }
    }
}
