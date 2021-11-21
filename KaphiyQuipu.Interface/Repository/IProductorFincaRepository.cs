using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IProductorFincaRepository
    {
        int Insertar(ProductorFinca productorFinca);
        int Actualizar(ProductorFinca productorFinca);
        IEnumerable<ConsultaProductorFincaProductorIdBE> ConsultarProductorFincaPorProductorId(int productorId);
        ConsultaProductorFincaPorIdBE ConsultarProductorFincaPorId(int productorFincaId);
    }
}