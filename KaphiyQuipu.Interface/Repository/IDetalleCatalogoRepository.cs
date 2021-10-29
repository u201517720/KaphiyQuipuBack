using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IDetalleCatalogoRepository
    {
        int Insertar(DetalleCatalogo DetalleCatalogo);

        int Actualizar(DetalleCatalogo DetalleCatalogo);

        IEnumerable<ConsultaDetalleCatalogoBE> ConsultarDetalleCatalogo(ConsultaDetalleCatalogoRequestDTO request);

        ConsultaDetalleCatalogoPorIdBE ConsultarDetalleCatalogoPorId(int DetalleCatalogoId);

        IEnumerable<ConsultaCatalogoTablasBE> ConsultarCatalogoTablas();
    }
}