﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Models
{
    
    public class Empresa
    {
        [Key]
        public int EmpresaId { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string Logo { get; set; }
        public string TipoEmpresaid { get; set; }
        
        public string CorreoFrom { get; set; }

        public bool Activo { get; set; }
       
    }

}
