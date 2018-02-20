using SmartHoldemNet.Model.BaseModels;

namespace SmartHoldemNet.Model.Loader
{
    public class SmartHoldemLoaderStatusSync : SmartHoldemResponseBase
    {
        public string Id { get; set; }
        public bool Syncing { get; set; }
        public long Blocks { get; set; }
        public long Height { get; set; }
    }
}