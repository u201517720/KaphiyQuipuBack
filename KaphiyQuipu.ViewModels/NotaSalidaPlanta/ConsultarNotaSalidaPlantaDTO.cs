using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarNotaSalidaPlantaDTO
    {
        public int NotaSalidaPlantaId { get; set; }
        public string CorrelativoNSP { get; set; }
        public string CorrelativoNIP { get; set; }
        public string Acopiador { get; set; }
        public string Transformadora { get; set; }
        public string Conductor { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public string FechaActualizacion { get; set; }
    }
}
