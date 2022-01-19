using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ILoteRepository
    {
        int InsertarLoteDetalle(List<LoteDetalle> request);
        LoteDetalle ConsultarLoteDetallePorId(int loteDetalleId);
        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);
        int EliminarLoteDetalle(List<TablaIdsTipo> request);
        IEnumerable<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request);
        int ActualizarEstado(int loteId, DateTime fecha, string usuario, string estadoId);
        int Actualizar(int loteId, DateTime fecha, string usuario, string almacenId, int cantidad, decimal totalKilosNetosPesado, decimal totalKilosBrutosPesado, int? contratoId);
        IEnumerable<LoteDetalle> ConsultarLoteDetallePorLoteId(int loteId);
        IEnumerable<LoteDetalleConsulta> ConsultarBandejaLoteDetallePorId(int loteId);
        ConsultaLoteBandejaBE ConsultarLotePorId(int loteId);
        int ActualizarLoteRegistroTostadoIndicadorDetalle(List<LoteRegistroTostadoIndicadorDetalleTipo> request, int LoteId);
    }
}