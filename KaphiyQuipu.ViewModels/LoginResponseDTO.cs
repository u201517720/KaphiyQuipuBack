﻿using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{   

    public class LoginResponseDTO
    {
        public LoginResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
