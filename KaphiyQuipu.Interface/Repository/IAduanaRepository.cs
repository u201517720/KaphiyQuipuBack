﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IAduanaRepository
    {
        int Insertar(Aduana Aduana);

        int Actualizar(Aduana Aduana);

        int Anular(int AduanaId, DateTime fecha, string usuario, string estadoId);


        int ActualizarAduanaCertificacion(List<AduanaCertificacionTipo> request, int aduanaId);

        int InsertarAduanaDetalle(AduanaDetalle aduanaDetalle);

        int EliminarAduanaDetalle(int aduanaId);

        IEnumerable<AduanaDetalle> ConsultarAduanaDetallePorId(int aduanaId);

    }
}