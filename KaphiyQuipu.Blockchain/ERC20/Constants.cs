using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace KaphiyQuipu.Blockchain.ERC20
{
    public static class Constants
    {
        public static string GETH_RPC = "GethRPC";

        #region Function names
        public static string FUNCTION_TOTAL_SUPPLY = "totalSupply";
        public static string FUNCTION_BALANCE_OF = "balanceOf";
        public static string FUNCTION_ALLOWANCE = "allowance";
        public static string FUNCTION_TRANSFER = "transfer";
        public static string FUNCTION_APPROVE = "approve";
        public static string FUNCTION_TRANSFER_FROM = "transferFrom";
        public static string FUNCTION_HOLDER_EXIST = "holderExist";
        public static string FUNCTION_APPOINTEE_EXIST = "appointeeExist";
        public static string FUNCTION_ADD_HOLDER = "addHolder";
        public static string FUNCTION_ADD_APPOINTEE = "addAppointee";
        public static string FUNCTION_REMOVE_HOLDER = "removeHolder";
        public static string FUNCTION_REMOVE_APPOINTEE = "removeAppointee";
        public static string FUNCTION_CHECK_PERMISSION = "checkPermission";
        public static string FUNCTION_CHECK_HOLDER_PERMISSION = "checkHolderPermission";
        public static string FUNCTION_CHECK_APPOINTEE_PERMISSION = "checkAppointeePermission";
        public static string FUNCTION_CHECK_OWNER_PERMISSION = "checkOwnerPermission";
        public static string FUNCTION_GET_OWNER = "getOwner";

        public static string FUNCTION_VALIDATE_USER = "validateUser";
        public static string FUNCTION_GET_USER = "getUser";
        public static string FUNCTION_TOTAL_USERS = "totalUsers";
        public static string FUNCTION_USERS = "users";

        #endregion

        #region Defautl values for contracts
        public static string DEFAULT_TEST_ACCOUNT_ADDRESS = "0x18595224cc2A9221ebDA8dbd69d60A60d4698D63";
        public static string DEFAULT_TEST_ACCOUNT_PASSWORD = "98e53a79b69b5967351c7aefcb417ac29fdbaef2d9fd76fe3249379ee8ecaa31";
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
