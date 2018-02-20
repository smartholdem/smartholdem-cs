using SmartHoldemNet.Model.BaseModels;

namespace SmartHoldemNet.Model.Delegate
{
    public class SmartHoldemDelegateForgedBalance : SmartHoldemResponseBase
    {
        public long Fees { get; set; }
        public long Rewards { get; set; }
        public long Forged { get; set; }
    }
}