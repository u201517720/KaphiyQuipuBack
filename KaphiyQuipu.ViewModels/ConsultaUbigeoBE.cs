using System;

namespace KaphiyQuipu.DTO
{
    public class ConsultaUbigeoBE
    {
        public int IdUbigeo { get; set; }
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public String CodigoPais { get; set; }
        public String DescripcionPais { get; set; }

        public bool EstadoRegistro { get; set; }

        
    }
}
