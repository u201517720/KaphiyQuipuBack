﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaSalidaAlmacenRepository
    {
        int Insertar(NotaSalidaAlmacen notaSalidaAlmacen);

        int Actualizar(NotaSalidaAlmacen notaSalidaAlmacen);

        int ActualizarEstado(int notaSalidaAlmacenId, DateTime fecha, string usuario, string estadoId);

       
        IEnumerable<NotaSalidaAlmacenAnalisisFisicoColorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoColorDetallePorId(int NotaSalidaAlmacenId);
        IEnumerable<NotaSalidaAlmacenAnalisisFisicoOlorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoOlorDetallePorId(int NotaSalidaAlmacenId);

        IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetallePorId(int NotaSalidaAlmacenId);
        IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetallePorId(int NotaSalidaAlmacenId);
        IEnumerable<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialAtributoDetallePorId(int NotaSalidaAlmacenId);
        IEnumerable<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialDefectoDetallePorId(int NotaSalidaAlmacenId);
        IEnumerable<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle> ConsultarNotaSalidaAlmacenRegistroTostadoIndicadorDetallePorId(int NotaSalidaAlmacenId);

        int ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalle(List<NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo> request, int NotaSalidaAlmacenId);
        int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaSalidaAlmacenId);
        int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaSalidaAlmacenId);
        int ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalle(List<NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo> request, int NotaSalidaAlmacenId);
        int ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalle(List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo> request, int NotaSalidaAlmacenId);
        int ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalle(List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo> request, int NotaSalidaAlmacenId);
        int ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalle(List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo> request, int NotaSalidaAlmacenId);

        int ActualizarNotaSalidaAlmacenAnalisisCalidad(NotaSalidaAlmacen notaSalidaAlmacen);

        IEnumerable<NotaSalidaAlmacenDetalle> ConsultarNotaSalidaAlmacenDetallePorId(int notaSalidaAlmacenId);
        IEnumerable<NotaSalidaAlmacenDetalleLotes> ConsultarNotaSalidaAlmacenDetalleLotesPorId(int NotaSalidaAlmacenId);

        int ActualizarNotaSalidaAlmacenDetalle(List<NotaSalidaAlmacenDetalle> request, int? NotaSalidaAlmacenId);
    }
}