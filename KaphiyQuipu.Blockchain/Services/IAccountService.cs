using Nethereum.Web3.Accounts.Managed;
using Nethereum.Web3;
using KaphiyQuipu.Blockchain.Entities;

namespace KaphiyQuipu.Blockchain.Services
{
    public interface IAccountService
    {
        //AccountDAO Authenticate(string address, string password);
        ManagedAccount GetAccount();
        Web3 GetWeb3();
    }
}
