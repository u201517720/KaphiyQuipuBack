﻿using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{   

    public class ConsultaDistritoRequestDTO
    {     
        public String CodigoPais { get; set; }
        public String CodigoDepartamento { get; set; }
        public String CodigoProvincia { get; set; }

    }
}
