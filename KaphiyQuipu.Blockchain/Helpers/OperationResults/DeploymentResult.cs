﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace KaphiyQuipu.Blockchain.Helpers.OperationResults
{
    public class DeploymentResult
    {
        public string ContractAddress { get; set; }
        public string OwnerAddress { get; set; }
        public BigInteger GasPrice { get; set; }
        public string TransactionHash { get; set; }
        public TransactionResult TransactionReceipt { get; set; }
        public BigInteger DeployedAtBlock { get; set; }

        public bool Success { get; set; }
        public string StatusMessage { get; set; }
    }
}
