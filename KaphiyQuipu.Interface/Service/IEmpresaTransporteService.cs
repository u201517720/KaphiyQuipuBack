using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IEmpresaTransporteService
    {
        List<EmpresaTransporteBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteRequestDTO request);
        List<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request);
        ConsultaEmpresaTransportePorIdBE ConsultarEmpresaTransportePorId(ConsultaEmpresaTransportePorIdRequestDTO request);
        int ActualizarEmpresaTransporte(RegistrarActualizarEmpresaTransporteRequestDTO request);

        int RegistrarEmpresaTransporte(RegistrarActualizarEmpresaTransporteRequestDTO request);



    }
}
