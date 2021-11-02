using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.Facade;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Blockchain.ERC20
{
    public interface IUserContract 
    {
        Task<UserDTO> ValidateUser(string username, string passsword);
    }
    public class UserContract: IUserContract
    {
        private readonly IContractFacade _ContractFacade;
        private readonly IConfiguration _configuration;
        public UserContract(IContractFacade contractFacade,
                            IConfiguration configuration)
        {
            _ContractFacade = contractFacade;
            _configuration = configuration;
        }

        public async Task<UserDTO> ValidateUser(string username, string passsword)
        {
            var contract = await _ContractFacade.GetContract(_configuration["Ethereum:Contracts:UserContract:Name"], true, _configuration["Ethereum:Contracts:UserContract:Address"]);
            bool isAuthenticated= await contract.Contract.GetFunction(Constants.FUNCTION_VALIDATE_USER).CallAsync<bool>(username, passsword);

            if (isAuthenticated)
            {
                var user = await contract.Contract.GetFunction(Constants.FUNCTION_GET_USER).CallDeserializingToObjectAsync<GenericOutputDTO<UserDTO>>(username);
                return user.Data;
            }

            return null;
        }
    }
}
