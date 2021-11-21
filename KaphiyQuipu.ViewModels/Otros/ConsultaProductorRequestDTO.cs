﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class ConsultaProductorRequestDTO
    {

        public String Numero { get; set; }

        public String NombreRazonSocial { get; set; }

        public String TipoDocumentoId { get; set; }

        public String NumeroDocumento { get; set; }       

        public String EstadoId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        

    }
}
