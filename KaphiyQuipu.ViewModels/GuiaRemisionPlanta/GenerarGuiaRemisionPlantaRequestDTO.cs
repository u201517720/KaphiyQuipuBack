using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class GenerarGuiaRemisionPlantaRequestDTO
    {
        public int NotaSalidaPlantaId { get; set; }
        public string UsuarioRegistro { get; set; }
        public string Empresa { get; set; }
        public string Correlativo { get; set; }
        public string Contrato { get; set; }
    }
}
