using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IProductorRepository
    {
        int Insertar(Productor lote);

        int Actualizar(Productor lote);

        IEnumerable<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request);
        
        ConsultaProductorIdBE ConsultarProductorId(int productorId);

        IEnumerable<ConsultaProductorBE> ValidarProductor(ConsultaProductorRequestDTO request);
}
}