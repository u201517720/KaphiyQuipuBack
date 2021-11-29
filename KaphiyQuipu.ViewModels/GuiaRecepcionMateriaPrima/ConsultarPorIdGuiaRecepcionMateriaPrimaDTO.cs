using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPorIdGuiaRecepcionMateriaPrimaDTO
    {
        public ConsultarPorIdGuiaRecepcionMateriaPrimaDTO()
        {
            agricultores = new List<AgricultoresGuiaRecepcionMateriaPrimaDTO>();
            controlesCalidad = new List<GuiaRecepcionMateriaPrimaControlCalidadDTO>();
        }
        public int GuiaRecepcionId { get; set; }
        public string Correlativo { get; set; }
        public string FechaRegistro { get; set; }
        public string RazonSocial { get; set; }
        public string EstadoId { get; set; }
        public string EstadoGuiaRecepcion { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Moneda { get; set; }
        public string UnidadMedida { get; set; }
        public string TipoProduccion { get; set; }
        public string Empaque { get; set; }
        public string TipoEmpaque { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public string Grado { get; set; }
        public string Calidad { get; set; }
        public string TipoCertificacion { get; set; }
        public int TotalSacos { get; set; }
        public decimal PesoSaco { get; set; }
        public decimal PesoKilos { get; set; }
        public string ObservacionesSolicitudCompra { get; set; }
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
        public string Responsable { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Tara { get; set; }
        public decimal KilosNetosContrato { get; set; }
        public List<AgricultoresGuiaRecepcionMateriaPrimaDTO> agricultores { get; set; }
        public List<GuiaRecepcionMateriaPrimaControlCalidadDTO> controlesCalidad { get; set; }
    }
}
