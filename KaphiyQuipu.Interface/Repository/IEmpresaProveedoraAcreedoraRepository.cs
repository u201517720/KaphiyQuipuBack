using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IEmpresaProveedoraAcreedoraRepository
    {   
        IEnumerable<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request);

        ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraPorId(int EmpresaProveedoraAcreedoraId);
        int Actualizar(EmpresaProveedoraAcreedora EmpresaProveedoraAcreedora);
        int Insertar(EmpresaProveedoraAcreedora EmpresaProveedoraAcreedora);

        IEnumerable<ConsultaEmpresaProveedoraAcreedoraCertificacionPorIdBE> ConsultarEmpresaProveedoraAcreedoraCertificacionPorId(int empresaProveedoraAcreedoraId);

        int ActualizarEmpresaProveedoraAcreedoraCertificacion(List<EmpresaProveedoraAcreedoraCertificacionTipo> request, int empresaProveedoraAcreedoraCertificacionId);

    }
}
