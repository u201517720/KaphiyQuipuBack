using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISolicitudCompraService
    {
        int Registrar(RegistrarActualizarSolicitudCompraRequestDTO request);
    }
}
