using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IUbigeoRepository
    {
        int Insertar(Ubigeo ubigeo);

        int Actualizar(Ubigeo ubigeo);

        IEnumerable<ConsultaUbigeoBE> ConsultarUbigeoPorCodigoPais(ConsultaUbigeoPorCodigoPaisRequestDTO request);

        ConsultaUbigeoPorIdBE ConsultarUbigeoPorId(int UbigeoId);

    }
}