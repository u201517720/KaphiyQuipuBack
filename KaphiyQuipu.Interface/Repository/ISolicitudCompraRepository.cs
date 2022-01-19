using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISolicitudCompraRepository
    {
        string Insertar(SolicitudCompra solicitudCompra);
        IEnumerable<ConsultaSolicitudCompraDTO> Consultar(ConsultaSolicitudCompraRequestDTO request);
        ConsultaSolicitudCompraPorIdDTO ConsultarPorId(int solicitudCompraId);
        EvaluarDisponibilidadDTO EvaluarDisponibilidad(EvaluarDisponibilidadRequestDTO request);
    }
}
