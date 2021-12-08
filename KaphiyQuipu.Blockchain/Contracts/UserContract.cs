using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.Blockchain.Services;
using KaphiyQuipu.DTO.Seguridad;
using Microsoft.Extensions.Configuration;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Blockchain.Contracts
{
    public interface IUserContract 
    {
        Task<UserDTO> ValidateUser(string username, string passsword);
        Task<TransactionResult> AgregarUsuario(UsuarioDTO request);
        Task<List<UserResponseDTO>> ListarUsuarios();

    }
    public class UserContract: IUserContract
    {
        private readonly IContractFacade _ContractFacade;
        private readonly IContractOperation _contractOperation;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly Web3 _web3;
        private IAccount _account;
        private ContractDAO contract;

        public UserContract(IContractFacade contractFacade,
                            IContractOperation contractOperation,
                            IAccountService accountService,
                            IConfiguration configuration)
        {
            _ContractFacade = contractFacade;
            _contractOperation = contractOperation;
            _accountService = accountService;
            _web3 = _accountService.GetWeb3();
            _account = _accountService.GetAccount();
            _configuration = configuration;

            contract = _ContractFacade.GetContract(_configuration["Ethereum:Contracts:UserContract:Name"], true, _configuration["Ethereum:Contracts:UserContract:Address"]).Result;
        }

        public async Task<UserDTO> ValidateUser(string username, string passsword)
        {
            var contract = await _ContractFacade.GetContract(_configuration["Ethereum:Contracts:UserContract:Name"], true, _configuration["Ethereum:Contracts:UserContract:Address"]);
            bool isAuthenticated= await contract.Contract.GetFunction(Functions.Usuario.FUNCTION_VALIDATE_USER).CallAsync<bool>(username, passsword);

            if (isAuthenticated)
            {
                var user = await contract.Contract.GetFunction(Functions.Usuario.FUNCTION_GET_USER).CallDeserializingToObjectAsync<GenericOutputDTO<UserDTO>>(username);
                return user.Data;
            }

            return null;
        }

        public async Task<TransactionResult> AgregarUsuario(UsuarioDTO request)
        {
            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.Usuario.ADD_USERS,
                                             request.UserName,
                                             request.FullName,
                                             request.Email,
                                             request.Password,
                                             request.Empresa.ToString(),
                                             request.Role
                                           );

            return result;
        }

        public async Task<List<UserResponseDTO>> ListarUsuarios()
        {
            var solicitudOutput = await contract.Contract.GetFunction(Functions.Usuario.FUNCTION_USERS).CallDeserializingToObjectAsync<UserListOutputDTO>();
            return solicitudOutput.Lista;
        }
    }
}
