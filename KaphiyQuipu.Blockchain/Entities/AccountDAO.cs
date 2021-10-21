using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class AccountDAO
    {
        [Parameter("address", 1)]
        public string Address { get; set; }
        public double Balance { get; set; }
        public long Nonce { get; set; }
        public string PublicKey { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
