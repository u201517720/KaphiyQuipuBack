﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class ConsultaInspeccionInternaRequestDTO
    {       
        
        public String Numero { get; set; }

        public String EstadoId { get; set; }

        public int EmpresaId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        

    }
}
