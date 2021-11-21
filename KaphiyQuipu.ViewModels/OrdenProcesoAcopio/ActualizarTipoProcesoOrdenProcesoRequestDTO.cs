using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ActualizarTipoProcesoOrdenProcesoRequestDTO
    {
        public int OrdenProcesoId { get; set; }
        public string TipoProceso { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
