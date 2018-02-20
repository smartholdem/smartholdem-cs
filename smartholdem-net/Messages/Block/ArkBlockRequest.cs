using SmartHoldemNet.Attributes;
using SmartHoldemNet.Messages.BaseMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHoldemNet.Messages.Block
{
    public class SmartHoldemBlockRequest : SmartHoldemBaseRequest
    {
        [SmartHoldemQueryParam(Name = "generatorPublicKey")]
        public string GeneratorPublickey { get; set; }

        [SmartHoldemQueryParam(Name = "totalAmount")]
        public long? TotalAmount { get; set; }

        [SmartHoldemQueryParam(Name = "totalFee")]
        public int? TotalFee { get; set; }

        [SmartHoldemQueryParam(Name = "reward")]
        public int? Reward { get; set; }

        [SmartHoldemQueryParam(Name = "previousBlock")]
        public string PreviousBlock { get; set; }

        [SmartHoldemQueryParam(Name = "height")]
        public int? Height { get; set; }
    }
}
