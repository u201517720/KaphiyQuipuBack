﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class ConsultaProveedoresRequestDTO
    {

        public String TipoProveedorId { get; set; }
        public String NombreRazonSocial { get; set; }

        public String TipoDocumentoId { get; set; }

        public String NumeroDocumento { get; set; }

        public String CodigoSocio { get; set; }

        public int EmpresaId { get; set; }

    }
}
