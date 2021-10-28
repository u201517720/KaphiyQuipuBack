using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IOrdenServicioControlCalidadService
    {
       
       
        List<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request);

        int AnularOrdenServicioControlCalidad(AnularOrdenServicioControlCalidadRequestDTO request);
        int RegistrarOrdenServicioControlCalidad(RegistrarActualizarOrdenServicioControlCalidadRequestDTO request);
        int ActualizarOrdenServicioControlCalidad(RegistrarActualizarOrdenServicioControlCalidadRequestDTO request);
        ConsultaOrdenServicioControlCalidadPorIdBE ConsultarOrdenServicioControlCalidadPorId(ConsultaOrdenServicioCalidadServicioPorIdRequestDTO request);
        int ActualizarOrdenServicioControlCalidadAnalisisCalidad(ActualizarOrderServicioControlCalidadRequestDTO request);

    }
}
