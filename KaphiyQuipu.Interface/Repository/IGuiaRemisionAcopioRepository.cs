using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRemisionAcopioRepository
    {
        string Registrar(GuiaRemisionAcopio request);
        IEnumerable<ConsultarPorCorrelativoGuiaRemisionDTO> ConsultarPorCorrelativo(string correlativo);
        string RegistrarDevolucion(GuiaRemisionDevolucion guia);
    }
}
