using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarActualizarGuiaRecepcionRequestDTO
    {
        public string Correlativo { get; set; }
        public int ContratoId { get; set; }
        public decimal SacosPC { get; set; }
        public decimal KilosBrutosPC { get; set; }
        public decimal TaraSacoPC { get; set; }
        public decimal KilosNetos { get; set; }
        public decimal QQ55KG { get; set; }
        public decimal CafeExportacionGramosAFC { get; set; }
        public decimal CafeExportacionPorcAFC { get; set; }
        public decimal DescarteGramosAFC { get; set; }
        public decimal DescartePorcAFC { get; set; }
        public decimal CascaraGramosAFC { get; set; }
        public decimal CascaraPorcAFC { get; set; }
        public decimal TotalGramosAFC { get; set; }
        public decimal TotalPorcAFC { get; set; }
        public decimal Humedad { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
