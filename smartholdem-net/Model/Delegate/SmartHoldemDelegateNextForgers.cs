using System.Collections.Generic;

namespace SmartHoldemNet.Model.Delegate
{
    public class SmartHoldemDelegateNextForgers
    {
        public long CurrentBlock { get; set; }
        public long CurrentSlot { get; set; }
        public List<string> Delegates { get; set; }
    }
}