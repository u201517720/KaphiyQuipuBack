using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartContractController : ControllerBase
    {
        private IContractFacade _contractFacade;
        private IContractOperation _operation;

        private Web3 _web3;
        private IAccount _account;
        private ContractService _contractService;
        private IAccountService _accountService;

        public SmartContractController(
            IContractFacade contractFacade,
            IContractOperation operation,
            ContractService contractService,
            IAccountService accountService)
        {
            _contractFacade = contractFacade;
            _operation = operation;
            _contractService = contractService;
            _accountService = accountService;
            _web3 = _accountService.GetWeb3();
            _account = _accountService.GetAccount();
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var contract = await _contractFacade.GetContract("UserContract", true, "0x89D46B6CAaf575CF878fc18209F357f2B320a5Bb");
            //var contract = await _contractFacade.GetContract("UserContract", true, "0x7Ed22e76E47dE32cD0CE4E3D6E136e5340192891");

            var totalUsers = contract.Contract.GetFunction("totalUsers").CallAsync<long>();

            var autenticate = await contract.Contract.GetFunction("validateUser").CallAsync<bool>("admin@gmail.com", "5JKIrQpthKxsTzF4kTDryw==");
 
            var user = await contract.Contract.GetFunction("getUser").CallDeserializingToObjectAsync<GenericOutputDTO<UserDTO>>("admin@gmail.com");


            //var total = await contract.Contract.GetFunction("totalUsers").CallAsync<long>();
            var userfunction = contract.Contract.GetFunction("users");
            var data = await userfunction.CallDeserializingToObjectAsync<UserDTO>(1L).ConfigureAwait(false);
            return Ok(user.Data);
        }
    }
}
