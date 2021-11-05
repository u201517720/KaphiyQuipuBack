using KaphiyQuipu.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaCompraService
    {
        int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request);

        int LiquidarNotaCompra(LiquidarNotaCompraRequestDTO request);

    }
}
