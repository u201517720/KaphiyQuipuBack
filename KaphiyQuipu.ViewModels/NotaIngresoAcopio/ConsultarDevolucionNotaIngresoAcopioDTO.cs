using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDevolucionNotaIngresoAcopioDTO
    {
        public int NotaIngresoDevolucionId { get; set; }
        public string CorrelativoNID { get; set; }
        public string CorrelativoGRP { get; set; }
        public string Almacen { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string HashBC { get; set; }
    }
}
