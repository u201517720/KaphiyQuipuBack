using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IProductoPrecioDiaService
    {

        int RegistrarProductoPrecioDia(RegistrarActualizarProductoPrecioDiaRequestDTO request);
        int ActualizarProductoPrecioDia(RegistrarActualizarProductoPrecioDiaRequestDTO request);


        List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDia(ConsultaProductoPrecioDiaRequestDTO request);
        ConsultaProductoPrecioDiaPorIdBE ConsultarProductoPrecioDiaPorId(ConsultaProductoPrecioDiaPorIdRequestDTO request);


    }
}
