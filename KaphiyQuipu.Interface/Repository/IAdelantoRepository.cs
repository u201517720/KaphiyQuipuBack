using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adelanto;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IAdelantoRepository
    {
        IEnumerable<ConsultaAdelantoBE> ConsultarAdelanto(ConsultaAdelantoRequestDTO request);
        IEnumerable<ResultadoPDFAdelanto> GenerarPDF(int idAdelanto);
        int Insertar(Adelanto adelanto);
        int Actualizar(Adelanto adelanto);
        ConsultaAdelantoPorIdBE ConsultarAdelantoPorId(int adelantoId);
        int Anular(int adelantoId, DateTime fecha, string usuario, string estadoId);

        int AsociarNotaCompra(int adelantoId, int notaCompraId, DateTime fecha, string usuario);

        IEnumerable<ConsultaAdelantoBE> ConsultarAdelantosPorNotaCompra(int notaCompraId, string estadoId);

        int ActualizarEstadoPorNotaCompra(int notaCampraId, DateTime fecha, string usuario, string estadoId);
    }
}
