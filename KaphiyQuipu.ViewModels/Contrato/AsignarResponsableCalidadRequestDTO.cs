using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class AsignarResponsableCalidadRequestDTO
    {
        public int Id { get; set; }
        public int ResponsableId { get; set; }
        public int EstadoId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }

    }
}
