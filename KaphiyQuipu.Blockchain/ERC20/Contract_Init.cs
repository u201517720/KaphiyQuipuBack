using KaphiyQuipu.Blockchain.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.ERC20
{
    public partial class ContractOperation : IContractOperation
    {
        protected readonly IContractFacade ContractFacade;
        public ContractOperation(IContractFacade contractFacade)
        {
            ContractFacade = contractFacade;
        }
    }
}
