﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class ConsultaEmpresaProveedoraAcreedoraRequestDTO
    {

        public string RazonSocial { get; set; }

        public string Ruc { get; set; }

        public string ClasificacionId { get; set; }

        public string EstadoId { get; set; }

        public int EmpresaId { get; set; }
    }
}