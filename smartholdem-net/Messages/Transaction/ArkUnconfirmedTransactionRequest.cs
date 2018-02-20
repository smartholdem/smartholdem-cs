using SmartHoldemNet.Attributes;
using SmartHoldemNet.Messages.BaseMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHoldemNet.Messages.Transaction
{
    public class SmartHoldemUnconfirmedTransactionRequest : SmartHoldemBaseRequest
    {
        [SmartHoldemQueryParam(Name = "senderPublicKey")]
        public string SenderPublickey { get; set; }

        [SmartHoldemQueryParam(Name = "address")]
        public string Address { get; set; }
    }
}
