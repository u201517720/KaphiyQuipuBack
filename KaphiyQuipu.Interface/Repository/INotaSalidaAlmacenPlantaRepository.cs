
using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using Core.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaSalidaAlmacenPlantaRepository
    {
        int Insertar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta);

        int Actualizar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta);

        int ActualizarEstado(int NotaSalidaAlmacenPlantaId, DateTime fecha, string usuario, string estadoId);


        int ActualizarNotaSalidaAlmacenPlantaDetalle(List<NotaSalidaAlmacenPlantaDetalle> request, int? NotaSalidaAlmacenPlantaId);

    }
}