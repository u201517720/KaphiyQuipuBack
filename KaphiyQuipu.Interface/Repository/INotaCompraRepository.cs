using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaCompraRepository
    {
        int Insertar(NotaCompra notaCompra);

        int Actualizar(NotaCompra notaCompra);

        int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId);

        int Liquidar(int notaCompraId, DateTime fecha, string usuario, string estadoId, string monedaId, decimal precioPagado, decimal importe, decimal? totalAdelanto, decimal totalPagar);

      
    }
}