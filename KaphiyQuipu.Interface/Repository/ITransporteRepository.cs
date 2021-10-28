using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ITransporteRepository
    {


        IEnumerable<ConsultaTransportePorEmpresaTransporteId> ConsultarTransportePorEmpresaTransporteId(int empresaTransporteId);
        
        ConsultaTransportePorIdBE ConsultarTransportePorId(int transporteId);
        int Actualizar(Transporte transporte);
        int Insertar(Transporte transporte);

    }
}
