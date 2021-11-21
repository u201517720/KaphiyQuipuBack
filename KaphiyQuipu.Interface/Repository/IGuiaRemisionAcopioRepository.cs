using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRemisionAcopioRepository
    {
        string Registrar(GuiaRemisionAcopio request);
    }
}
