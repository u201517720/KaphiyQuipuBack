using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IMaestroRepository
    {
        IEnumerable<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId, string idioma);
        IEnumerable<ConsultaUbigeoBE> ConsultaUbibeo();
        IEnumerable<Zona> ConsultarZona(string codigoDistrito);
        IEnumerable<ConsultaPaisBE> ConsultarPais();
    }
}