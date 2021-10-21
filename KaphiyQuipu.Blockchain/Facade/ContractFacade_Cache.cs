﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex.HexTypes;
using Nethereum.Hex.HexConvertors;
using Nethereum.Web3.Accounts;
using KaphiyQuipu.Blockchain.Entities;

namespace KaphiyQuipu.Blockchain.Facade
{
    public partial class ContractFacade : IContractFacade
    {
        public async Task<ContractDAO> GetContract(string contractName, bool isDeployed, string contractAddress)
        {
            List<ContractDAO> contractList = null;
            if (!Cache.TryGetValue(Constants.CACHE_CONTRACT_LIST, out contractList))
            {
                contractList = new List<ContractDAO>();
                Cache.Set(Constants.CACHE_CONTRACT_LIST, contractList);
            }
            var cachedContract = contractList.Where(x => x.Name.Equals(contractName)
                                                    && x.Address.Equals(contractAddress));
            //if (cachedContract.Any())
            //    return cachedContract.SingleOrDefault();

            string abi = null;
            try
            {
                abi = await GetAbi(contractName, isDeployed, contractAddress);
            }
            catch (ArgumentNullException ex)
            {
                Logger.LogError(ex.Message);
                return null;
            }
            catch (ArgumentException ex)
            {
                Logger.LogTrace(ex.Message);
                return null;
            }

            var url = Config.GetSection(Constants.GETH_RPC).Value;
            var web3 = new Web3(url);
            var contract = await Task.Run(() => web3.Eth.GetContract(abi, contractAddress));
            var contDAO = new ContractDAO()
            {
                Contract = contract,
                Name = contractName,
                Address = contract.Address,
                CodeHash = contract.Eth.GetCode.ToString(),
                StorageHash = contract.Eth.GetStorageAt.ToString(),
                Abi = abi
            };

            contractList.Add(contDAO);
            Cache.Set(Constants.CACHE_CONTRACT_LIST, contractList);
            return contDAO;
        }

        public Web3 GetWeb3(string address, string password, string rpcUrl)
        {
            var account = new ManagedAccount(address, password);
            return new Web3(account, rpcUrl);
        }

        private string GetContractDir(string contractName)
        {
            var rootcontractDir = Constants.CONTRACTS_DIR_NAME;
            var sln = Directory.GetParent(Directory.GetCurrentDirectory());
            var dir = sln + $"/{rootcontractDir}/{contractName}";
            if (!Directory.Exists(dir))
                return null;
            return dir;
        }

        public async Task<string> GetAbi(string contractName, bool isDeployed, string contractAddress = null)
        {
            // if(isDeployed)
            // {
            //     CheckNameAddressCompliant(contractAddress, contractName);
            // }

            var dir = GetContractDir(contractName);
            var abiFile = $"{dir}/bin/{contractName}.abi";
            if (!File.Exists(abiFile))
                return null;
            return await Task.Run(() => File.ReadAllText(abiFile));
        }

        public async Task<string> GetByteCode(string contractName, bool isDeployed, string contractAddress = null)
        {
            if (isDeployed)
                CheckNameAddressCompliant(contractAddress, contractName);

            var dir = GetContractDir(contractName);
            var bytecodeFile = $"{dir}/bin/{contractName}.bin";
            return await Task.Run(() => File.ReadAllText(bytecodeFile));
        }

        private bool CheckNameAddressCompliant(string contractAddress, string contractName)
        {
            if (contractAddress == null)
                throw new ArgumentException("Deployed contract must have a valid address.");

            var path = Directory.GetCurrentDirectory() + $"/{Constants.CONTRACT_ARTIFACTS_DIR_NAME}" + $"/{Constants.CONTRACT_ARTIFACT_FILE_NAME}.xml";
            if (!File.Exists(path))
                throw new ArgumentNullException($"File {Constants.CONTRACT_ARTIFACT_FILE_NAME} does not exist.");

            XElement root = XElement.Load(path);
            IEnumerable<XElement> contract = root.Elements("Contract")
            .Where(c => c.Attribute("Name").Value.Equals(contractName))
            .Elements("Address").Where(x => x.Value.Equals(contractAddress)).ToList();
            if (!contract.Any())
                throw new ArgumentException($"No contract {contractName} matches address {contractAddress} found.");

            return true;
        }
    }
}
