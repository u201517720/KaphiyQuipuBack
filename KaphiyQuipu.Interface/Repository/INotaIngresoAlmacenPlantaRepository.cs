using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaIngresoAlmacenPlantaRepository
    {       
        int Insertar(NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta);

        int ActualizarEstado(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);

        int Actualizar(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string almacenId);

        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);
    }
}