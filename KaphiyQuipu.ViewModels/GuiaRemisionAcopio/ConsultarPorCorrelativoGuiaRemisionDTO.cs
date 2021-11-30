using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPorCorrelativoGuiaRemisionDTO
    {
        public int GuiaRemisionId { get; set; }
        public string CorrelativoGRA { get; set; }
        public string Empresa { get; set; }
        public string EmpresaRUC { get; set; }
        public string EmpresaDireccion { get; set; }
        public string Conductor { get; set; }
        public string PlacaTractor { get; set; }
        public string Certificacion { get; set; }
        public string Producto { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal KilosBrutosPC { get; set; }
        public decimal TaraSacoPC { get; set; }
        public decimal KilosNetos { get; set; }
    }
}
