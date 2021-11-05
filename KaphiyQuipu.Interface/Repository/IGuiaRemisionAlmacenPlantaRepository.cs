using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRemisionAlmacenPlantaRepository
    {
        
        int Insertar(GuiaRemisionAlmacenPlanta guiaRemisionAlmacenPlanta);
        int Actualizar(GuiaRemisionAlmacenPlanta guiaRemisionAlmacenPlanta);

    }
}