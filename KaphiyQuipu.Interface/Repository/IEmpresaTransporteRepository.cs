using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IEmpresaTransporteRepository
    {
        IEnumerable<EmpresaTransporteBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteRequestDTO request);
        IEnumerable<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request);
        IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteDTO request);
        ConsultaEmpresaTransportePorIdBE ConsultarEmpresaTransportePorId(int empresaTransporteId);
    }
}
