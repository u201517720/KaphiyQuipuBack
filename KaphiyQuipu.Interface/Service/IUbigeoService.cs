using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IUbigeoService
    {

        int RegistrarUbigeo(RegistrarActualizarUbigeoRequestDTO request);
        int ActualizarUbigeo(RegistrarActualizarUbigeoRequestDTO request);


        List<ConsultaUbigeoBE> ConsultarUbigeoPorCodigoPais(ConsultaUbigeoPorCodigoPaisRequestDTO request);
        ConsultaUbigeoPorIdBE ConsultarUbigeoPorId(ConsultaUbigeoPorIdRequestDTO request);


    }
}
