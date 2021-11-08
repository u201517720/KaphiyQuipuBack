using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Service
{
    public static class GuiaRecepcionMateriaPrimaEstados
    {
        public static string Pesado { get { return "01"; } }
        public static string Analizado { get { return "02"; } }
        public static string EnviadoAlmacen { get { return "03"; } }
        public static string Anulado { get { return "00"; } }
    }


    public static class GuiaRemisionAlmacenPlantaEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class ClienteTipo
    {
        public static string Nacional { get { return "01"; } }
        public static string Internacional { get { return "02"; } }
    }

    public static class Documentos
    {
        public static string GuiaRecepcion { get { return "GuiaRecepcion"; } }
        public static string Productor { get { return "Productor"; } }
        public static string Socio { get { return "Socio"; } }
        public static string UbigeoCiudad { get { return "UbigeoCiudad"; } }
        public static string Contrato { get { return "Contrato"; } }
        public static string SolicitudCompra { get { return "SolicitudCompra"; } }
        public static string NotaIngresoAcopio { get { return "NotaIngresoAcopio"; } }
        public static string Cliente { get { return "NotaIngresoAcopio"; } }

    }
    public static class NotaSalidaAlmacenPlantaEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
    }

    public static class ClienteEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class AdelantoEstados
    {
        public static string PorLiquidar { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Liquidado { get { return "02"; } }

    }
    public static class PrecioDiaRendimientoEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }

    public static class TipoCambioDiaEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }




    public static class AduanaEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

    }



    public static class ContratoEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }

        public static string Asignado { get { return "02"; } }

        public static string Completado { get { return "03"; } }

    }

    public static class LoteEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
        public static string GeneradoNotaSalida { get { return "03"; } }
    }

    public static class OrdenServicioControlCalidadEstados
    {
        public static string Ingresado { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
        public static string Analizado { get { return "02"; } }
    }


    public static class ProductorEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class SocioEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class MaestroEstados
    {
        public static string Activo { get { return "01"; } }
        public static string Anulado { get { return "00"; } }
    }

    public static class OrdenProcesoEstados
    {
        public static string Anulado { get { return "00"; } }
    }
}
