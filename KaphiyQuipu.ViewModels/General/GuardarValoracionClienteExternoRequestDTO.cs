using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class GuardarValoracionClienteExternoRequestDTO
    {
        public string NroContrato { get; set; }
        public string NroDocumento { get; set; }
        public string NombreCliente { get; set; }
        public int Puntaje { get; set; }
        public string Comentario { get; set; }
    }
}
