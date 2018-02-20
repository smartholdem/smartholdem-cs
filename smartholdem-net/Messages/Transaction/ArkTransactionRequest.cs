using SmartHoldemNet.Attributes;
using SmartHoldemNet.Messages.BaseMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHoldemNet.Messages.Transaction
{
    public class SmartHoldemTransactionRequest : SmartHoldemBaseRequest
    {
        [SmartHoldemQueryParam(Name = "senderPublicKey")]
        public string SenderPublickey { get; set; }

        [SmartHoldemQueryParam(Name = "ownerPublicKey")]
        public string OwnerPublicKey { get; set; }

        [SmartHoldemQueryParam(Name = "ownerAddress")]
        public string OwnerAddress { get; set; }

        [SmartHoldemQueryParam(Name = "senderId")]
        public string SenderId { get; set; }

        [SmartHoldemQueryParam(Name = "recipientId")]
        public string RecipientId { get; set; }

        [SmartHoldemQueryParam(Name = "amount")]
        public long? Amount { get; set; }

        [SmartHoldemQueryParam(Name = "fee")]
        public int? Fee { get; set; }

        [SmartHoldemQueryParam(Name = "type")]
        public int? Type { get; set; }

        [SmartHoldemQueryParam(Name = "blockId")]
        public string BlockId { get; set; }
    }
}
