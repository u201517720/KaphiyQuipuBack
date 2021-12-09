using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO.Reporte
{
    public class ReporteContratoDTO
    {
        public ReporteContratoDTO()
        {
            ContratoCompra = new ContratoCompra();
            ListaCalidadCafeAgricultor = new List<CalidadCafeAgricultor>();
            ListaAnalisisCafe = new List<AnalisisCalidadCafe>();
            ControlPlantaTransformadora = new ControlPlantaTransformadora();
            ListaControlPlantaTransformadora = new List<AnalisisCalidadCafe>();
            ListaResultadoTransformacion = new List<ResultadoTransformacion>();
            TrazabilidadContrato = new TrazabilidadContrato();
        }

        public ContratoCompra ContratoCompra { get; set; }
        public List<CalidadCafeAgricultor> ListaCalidadCafeAgricultor { get; set; }
        public List<AnalisisCalidadCafe> ListaAnalisisCafe { get; set; }
        public ControlPlantaTransformadora ControlPlantaTransformadora { get; set; }
        public List<AnalisisCalidadCafe> ListaControlPlantaTransformadora { get; set; }
        public List<ResultadoTransformacion> ListaResultadoTransformacion { get; set; }
        public TrazabilidadContrato TrazabilidadContrato { get; set; }
    }

    public class ContratoCompra
    {
        public string FechaSolicitud { get; set; }
        public string Producto { get; set; }
        public string TipoProduccion { get; set; }
        public string Calidad { get; set; }
        public string GradoPreparacion { get; set; }
        public string Logo { get; set; }
        public string Distribuidor { get; set; }
        public string Cooperativa { get; set; }
        public string HashBC { get; set; }
    }

    public class CalidadCafeAgricultor
    {
        public string Agricultor { get; set; }
        public string Documento { get; set; }
        public string Finca { get; set; }
        public string Certificacion { get; set; }
        public string PorcentajeHumedad { get; set; }
        public string Olores { get; set; }
        public string Colores { get; set; }
        public string Responsable { get; set; }
    }

    public class AnalisisCalidadCafe
    {
        public AnalisisCalidadCafe()
        {

        }

        public AnalisisCalidadCafe(string descripcion, string gramos, string porcentaje)
        {
            Descripcion = descripcion;
            Gramos = gramos;
            Porcentaje = porcentaje;
        }

        public string Descripcion { get; set; }
        public string Gramos { get; set; }
        public string Porcentaje { get; set; }
    }

    public class ControlPlantaTransformadora
    {
        public string Olores { get; set; }
        public string Colores { get; set; }
        public string Humedad { get; set; }
    }

    public class ResultadoTransformacion
    {
        public ResultadoTransformacion()
        {

        }
        public ResultadoTransformacion(string producto, string sacos, string kilos)
        {
            Producto = producto;
            Sacos = sacos;
            Kilos = kilos;

            if (!string.IsNullOrEmpty(sacos) && !string.IsNullOrEmpty(kilos))
            {
                KilosNetos = (decimal.Parse(sacos) * decimal.Parse(kilos)).ToString("0.00");
            }
            
            QQS = "0.00";
            Porcentaje = "0.00";
        }

        public string Producto { get; set; }
        public string Sacos { get; set; }
        public string Kilos { get; set; }
        public string KilosNetos { get; set; }
        public string QQS { get; set; }
        public string Porcentaje { get; set; }
    }

    public class TrazabilidadContrato
    {
        public string FechaSolicitud { get; set; }
        public string FechaControlCalidad { get; set; }
        public string FechaAnalisisCafe { get; set; }
        public string FechaIngresoPlantaAcopio { get; set; }
        public string FechaEnvioPlantaTransformadora { get; set; }
        public string FechaRecepcionPlantaTransformadora { get; set; }
        public string FechaControlCalidadPlantaTransformadora { get; set; }
        public string FechaIngresoTransformacionPlanta { get; set; }
        public string FechaResultadoTransformacion { get; set; }
        public string FechaTransformacionMateriaPrima { get; set; }
        public string FechaEnvioACooperativa { get; set; }
        public string FechaRecepcionCooperativa { get; set; }
        public string FechaEnvioADistribuidora { get; set; }
    }
}
