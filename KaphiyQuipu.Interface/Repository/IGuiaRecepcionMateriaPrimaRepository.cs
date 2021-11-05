using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRecepcionMateriaPrimaRepository
    {
        int AnularGuiaRecepcionMateriaPrima(int guiaRecepcionMateriaPrimaId, DateTime fecha, string usuario, string estadoId);
        int InsertarPesado(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);
        int ActualizarPesado(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);
        int ActualizarAnalisisCalidad(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima);
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetallePorId(int guiaRecepcionMateriaPrimaId);
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetallePorId(int guiaRecepcionMateriaPrimaId);
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetallePorId(int guiaRecepcionMateriaPrimaId);
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetallePorId(int guiaRecepcionMateriaPrimaId);

        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetallePorId(int guiaRecepcionMateriaPrimaId);
        IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(int guiaRecepcionMateriaPrimaId);
        IEnumerable<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle> ConsultarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetallePorId(int guiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle(List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle(List<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle(List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo> request, int GuiaRecepcionMateriaPrimaId);
        int ActualizarEstado(int guiaRecepcionMateriaPrimaId, DateTime fecha, string usuario, string estadoId);

    }
}
