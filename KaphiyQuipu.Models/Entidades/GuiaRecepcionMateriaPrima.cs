using System;

namespace KaphiyQuipu.Models
{
    public class GuiaRecepcionMateriaPrima
    {
        public GuiaRecepcionMateriaPrima()
        {

        }

        public int ID { get; set; }
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
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
