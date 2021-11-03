using Nethereum.Web3.Accounts.Managed;
using Nethereum.Web3;
using KaphiyQuipu.Blockchain.Entities;
using Nethereum.RPC.Accounts;

namespace KaphiyQuipu.Blockchain.Services
{
    public interface IAccountService
    {
        IAccount GetAccount();
        Web3 GetWeb3();
    }
}
