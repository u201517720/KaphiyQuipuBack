using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaSalidaAlmacenService
    {
        int RegistrarNotaSalidaAlmacen(RegistrarNotaSalidaAlmacenRequestDTO request);
        int ActualizarNotaSalidaAlmacen(RegistrarNotaSalidaAlmacenRequestDTO request);
        int AnularNotaSalidaAlmacen(AnularNotaSalidaAlmacenRequestDTO request);
        List<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalidaAlmacen(ConsultaNotaSalidaAlmacenRequestDTO request);
        ConsultaImpresionListaProductoresPorNotaSalidaAlmacenResponseDTO ConsultarImpresionListaProductoresPorNotaSalidaAlmacen(int notaSalidaAlmacenId);
        ConsultaNotaSalidaAlmacenPorIdBE ConsultarNotaSalidaAlmacenPorId(ConsultaNotaSalidaAlmacenPorIdRequestDTO request);
        //int ActualizarNotaSalidaAlmacenDetalle(RegistrarNotaSalidaAlmacenDetalleRequestDTO request);
        int ActualizarNotaSalidaAlmacenAnalisisCalidad(ActualizarNotaSalidaAnalisisCalidadRequestDTO request);
    }
}
