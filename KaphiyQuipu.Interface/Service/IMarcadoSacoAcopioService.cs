using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IMarcadoSacoAcopioService
    {
        string Registrar(RegistrarGuiaRemisionAcopioRequestDTO request);
    }
}
