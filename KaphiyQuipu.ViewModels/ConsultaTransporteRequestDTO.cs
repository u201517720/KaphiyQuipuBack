﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class ConsultaTransportistaRequestDTO
    {

        public String RazonSocial { get; set; }

        public String Ruc { get; set; }

        public String EstadoId { get; set; }

        public int EmpresaId { get; set; }
        
    }
}
