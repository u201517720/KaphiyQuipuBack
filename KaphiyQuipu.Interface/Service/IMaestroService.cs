using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IMaestroService
    {
        List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId, string idioma);
        List<ConsultaUbigeoBE> ConsultaUbibeo();
        List<Zona> ConsultarZona(string codigoDistrito);
        List<ConsultaPaisBE> ConsultarPais();
        List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(string subProductoId, int empresaId);
        List<ConsultarTransportistaDTO> ConsultarTransportista(ConsultarTransportistaRequestDTO request);
        List<ConsultarResponsableDTO> ConsultarResponsable(ConsultarResponsableRequestDTO request);
        TipoCambio ObtenerTipoCambio();
    }
}
