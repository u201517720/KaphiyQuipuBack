using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IZonaRepository
    {
        int Insertar(Zona Zona);

        int Actualizar(Zona Zona);

        IEnumerable<ConsultaZonaBE> ConsultarZona(ConsultaZonaRequestDTO request);

        ConsultaZonaPorIdBE ConsultarZonaPorId(int ZonaId);

       
    }
}