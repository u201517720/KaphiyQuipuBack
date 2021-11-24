using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class NotaIngresoPlantaResultadoTransformacion
    {
        public int Id { get; set; }
        public int NotaIngresoPlantaId { get; set; }
        public decimal CafeExportacionSacos { get; set; }
        public decimal CafeExportacionKilos { get; set; }
        public decimal CafeExportacionMCSacos { get; set; }
        public decimal CafeExportacionMCKilos { get; set; }
        public decimal CafeSegundaSacos { get; set; }
        public decimal CafeSegundaKilos { get; set; }
        public decimal CafeDescarteMaquinaSacos { get; set; }
        public decimal CafeDescarteMaquinaKilos { get; set; }
        public decimal CafeDescarteEscojoSacos { get; set; }
        public decimal CafeDescarteEscojoKilos { get; set; }
        public decimal CafeBolaSacos { get; set; }
        public decimal CafeBolaKilos { get; set; }
        public decimal CafeCiscoSacos { get; set; }
        public decimal CafeCiscoKilos { get; set; }
        public decimal TotalCafeSacos { get; set; }
        public decimal TotalCafeKgNetos { get; set; }
        public decimal PiedraOtrosKgNetos { get; set; }
        public decimal CascaraOtrosKgNetos { get; set; }
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
