using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IFincaFotoGeoreferenciadaRepository
    {
        int Insertar(FincaFotoGeoreferenciada FincaFotoGeoreferenciada);

        int Actualizar(FincaFotoGeoreferenciada FincaFotoGeoreferenciada);

        IEnumerable<ConsultaFincaFotoGeoreferenciadaPorId> ConsultarFincaFotoGeoreferenciadaPorFincaId(int fincaId);

        ConsultaFincaFotoGeoreferenciadaPorId ConsultarFincaFotoGeoreferenciadaPorId(int FincaFotoGeoreferenciadaId);

        int Eliminar(int fincaFotoGeoreferenciadaId);
    }
}