using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IEmpresaProveedoraAcreedoraService
    {
        List<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request);

        ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraPorId(ConsultaEmpresaProveedoraAcreedoraPorIdRequestDTO request);
        int ActualizarEmpresaProveedoraAcreedora(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request);

        int RegistrarEmpresaProveedoraAcreedora(RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO request);

        ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraCertificacionPorEmpresaProveedoraAcreedoraId(ConsultaEmpresaProveedoraAcreedoraPorIdRequestDTO request);


    }
}
