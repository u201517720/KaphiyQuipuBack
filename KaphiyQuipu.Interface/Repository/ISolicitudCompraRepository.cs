using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISolicitudCompraRepository
    {
        string Insertar(SolicitudCompra solicitudCompra);
        IEnumerable<ConsultaSolicitudCompraDTO> Consultar(ConsultaSolicitudCompraRequestDTO request);
        ConsultaSolicitudCompraPorIdDTO ConsultarPorId(int solicitudCompraId);
    }
}
