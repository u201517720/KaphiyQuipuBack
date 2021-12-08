using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class UserOutputDTO : IFunctionOutputDTO
    {
        [Parameter("tuple", 1)]
        public virtual UserDTO User { get; set; }
    }

    [FunctionOutput]
    public class GenericOutputDTO<T> : IFunctionOutputDTO
    {
        [Parameter("tuple", 1)]
        public virtual T Data { get; set; }
    }

    [FunctionOutput]
    public class GenericTupleOutputDTO<T> : IFunctionOutputDTO
    {
        [Parameter("tuple[]", 1)]
        public virtual List<T> Lista { get; set; }
    }

    [FunctionOutput]
    public class UserDTO: IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string UserName { get; set; }

        [Parameter("string", 2)]
        public string FullName { get; set; }

        [Parameter("string", 3)]
        public string email { get; set; }

        [Parameter("uint16", 5)]
        public short IdEmpresa { get; set; }
    }

    [FunctionOutput]
    public class UserListOutputDTO : IFunctionOutputDTO
    {
        [Parameter("tuple[]", 1)]
        public virtual List<UserResponseDTO> Lista { get; set; }
    }

    [FunctionOutput]
    public class UserResponseDTO : IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string UserName { get; set; }

        [Parameter("string", 2)]
        public string FullName { get; set; }

        [Parameter("string", 3)]
        public string Email { get; set; }

        [Parameter("string", 4)]
        public string Password { get; set; }

        [Parameter("uint16", 5)]
        public short IdEmpresa { get; set; }

        [Parameter("string", 6)]
        public string Role { get; set; }
    }
}
