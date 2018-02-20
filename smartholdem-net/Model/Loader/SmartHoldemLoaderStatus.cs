using SmartHoldemNet.Model.BaseModels;

namespace SmartHoldemNet.Model.Loader
{
    public class SmartHoldemLoaderStatus : SmartHoldemResponseBase
    {
        public bool Loaded { get; set; }
        public long Now { get; set; }
        public long BlocksCount { get; set; }
    }
}