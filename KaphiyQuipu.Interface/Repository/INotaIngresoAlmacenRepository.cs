using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaIngresoAlmacenRepository
    {       
        int Insertar(NotaIngresoAlmacen notaIngresoAlmacen);

        IEnumerable<NotaIngresoAlmacen> ConsultarNotaIngresoPorIds(List<TablaIdsTipo> request);

        int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId);

        int ActualizarEstado(int notaIngresoAlmacenId, DateTime fecha, string usuario, string estadoId);

        int Actualizar(int notaIngresoAlmacenId, DateTime fecha, string usuario, string almacenId);
    }
}