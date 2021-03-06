using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace KaphiyQuipu.Blockchain.Facade
{
    public static class Constants
    {
        public static string GETH_RPC = "GethRPC";

        #region Defautl values for contracts
        public static string DEFAULT_TEST_ACCOUNT_ADDRESS = "0x18595224cc2A9221ebDA8dbd69d60A60d4698D63";
        public static string DEFAULT_TEST_ACCOUNT_PASSWORD = "Pass@word1";
        public static string GAMER_TOKEN_CONTRACT_NAME = "GamerToken";
        public static BigInteger DEFAULT_GAS = 3000000;
        public static BigInteger DEFAULT_VALUE = 0;

        #endregion

        #region Directories
        public static string CONTRACTS_DIR_NAME = "SmartContracts";
        public static string CONTRACT_ARTIFACTS_DIR_NAME = "Contracts";
        public static string CONTRACT_ARTIFACT_FILE_NAME = "ContractArtifacts";
        #endregion

        #region Cache

        public static string CACHE_CONTRACT_LIST = "ContractList";
        public static string CACHE_ACCOUNT_LIST = "AccountList";
        #endregion
    }
}
