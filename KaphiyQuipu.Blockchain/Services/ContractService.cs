using System;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Microsoft.Extensions.Configuration;

using Nethereum.Web3.Accounts.Managed;
using Nethereum.Contracts;
using Nethereum.Contracts.CQS;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Hex;
using Nethereum.Hex.HexConvertors;
using Nethereum.RPC.Eth.DTOs;

using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using Nethereum.RPC.Accounts;

namespace KaphiyQuipu.Blockchain.Services
{
    public class ContractService
    {
        private readonly IContractFacade _contractFacade;
        private readonly IConfiguration _config;
        public ContractService(IContractFacade contractFacade, IConfiguration configuration)
        {
            _contractFacade = contractFacade;
            _config = configuration;
        }

        public async Task<DeploymentResult> DeployGamerSmartToken()
        {
            var abi = await _contractFacade.GetAbi("GamerToken", false, null);
            var byteCode = await _contractFacade.GetByteCode("GamerToken", false, null);
            return await _contractFacade.Deploy("GamerToken",
                                abi,
                                byteCode,
                                Constants.DEFAULT_TEST_ACCOUNT_ADDRESS,
                                Constants.DEFAULT_TEST_ACCOUNT_PASSWORD,
                                new HexBigInteger(Constants.DEFAULT_GAS));
        }

        public Web3 GetDefaultWeb3(IAccount account)
        {
            return new Web3(account, _config["Ethereum:ProviderUrl"]);
        }
    }
}
