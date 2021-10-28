using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IFincaMapaRepository
    {
        int Insertar(FincaMapa fincaMapa);

        int Actualizar(FincaMapa fincaMapa);

        IEnumerable<ConsultaFincaMapaPorId> ConsultarFincaMapaPorFincaId(int fincaId);

        ConsultaFincaMapaPorId ConsultarFincaMapaPorId(int fincaMapaId);

        int Eliminar(int fincaMapaId);
    }
}