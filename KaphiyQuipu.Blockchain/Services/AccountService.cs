using System;
using Microsoft.Extensions.Configuration;

using Nethereum.Web3.Accounts.Managed;
using Nethereum.Web3;
using KaphiyQuipu.Blockchain.ERC20;
using Nethereum.RPC.Accounts;
using Nethereum.Web3.Accounts;

namespace KaphiyQuipu.Blockchain.Services
{
    public class AccountService : IAccountService
    {
        private IAccount _account;
        private ContractService _contractService;
        private Web3 _web3;
        private bool _isAuthenticated = false;
        public AccountService(IConfiguration config, ContractService contractService, IServiceProvider service)
        {
            _isAuthenticated = true;

            _config = config;
            _contractService = contractService;

            SetAccount();
            SetWeb3();

        }
        private readonly IConfiguration _config;
 
        private void SetAccount()
        {
            if (_isAuthenticated)
                _account = GetDefaultAccount();
        }

        public IAccount GetAccount()
        {
            return _account;
        }

        private void SetWeb3()
        {
            if (_isAuthenticated && _account != null)
                _web3 = _contractService.GetDefaultWeb3(_account);
        }
        public Web3 GetWeb3()
        {
            return _web3;
        }

        private IAccount GetDefaultAccount()
        {
            return new Account(_config["Ethereum:Account:Key"]);
        }
    }
}
