using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarResponsableDTO
    {
        public int ResponsableId { get; set; }
        public string Responsable { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
    }
}
