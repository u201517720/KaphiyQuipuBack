using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IProductorFincaService
    {

        int RegistrarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request);
        int ActualizarProductorFinca(RegistrarActualizarProductorFincaRequestDTO request);

        IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaPorProductorId(ConsultaProductorFincaProductorIdRequestDTO request);

        ConsultaProductorFincaPorIdBE ConsultarProductorFincaPorId(ConsultaProductorFincaPorIdRequestDTO request);
    }
}
