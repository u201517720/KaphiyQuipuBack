﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRemisionAlmacenRepository
    {
        //int ActualizarGuiaRemisionAlmacen(GuiaRemisionAlmacen guiaRemisionAlmacen);
        int ActualizarGuiaRemisionAlmacenDetalle(List<GuiaRemisionAlmacenDetalleTipo> guiaRemisionAlmacenDetalle);
        ConsultaGuiaRemisionAlmacen ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(int notaSalidaAlmacenId);
        IEnumerable<ConsultaGuiaRemisionAlmacenDetalle> ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(int guiaRemisionAlmacenId);

        int Insertar(GuiaRemisionAlmacen guiaRemisionAlmacen);
        int Actualizar(GuiaRemisionAlmacen guiaRemisionAlmacen);

        int ActualizarDatosCalidad(GuiaRemisionAlmacen guiaRemisionAlmacen);

        //ConsultaGuiaRemisionAlmacen ConsultaGuiaRemisionAlmacenPorId(int guiaRemisionAlmacenId);
    }
}