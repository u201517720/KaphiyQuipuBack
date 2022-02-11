using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaNotaIngresoPlantaDTO
    {
        public int NotaIngresoPlantaId { get; set; }
        public string CorrelativoNIP { get; set; }
        public string CorrelativoGRA { get; set; }
        public string Empresa { get; set; }
        public string HashBC { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public string FechaActualizacion { get; set; }
    }
}
