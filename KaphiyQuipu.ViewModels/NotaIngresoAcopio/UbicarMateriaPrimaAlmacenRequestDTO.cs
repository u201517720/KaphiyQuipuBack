using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class UbicarMateriaPrimaAlmacenRequestDTO
    {
        public int NotaIngresoAcopioId { get; set; }
        public string AlmacenId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string HashBC { get; set; }
        public string Correlativo { get; set; }
        public string Almacen { get; set; }
    }
}
