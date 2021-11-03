using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class TransactionResponse<T>
    {
        public TransactionResponse()
        {
            Result = new Result();
        }

        public T Data { get; set; }
        public Result Result { get; set; }
    }
}
