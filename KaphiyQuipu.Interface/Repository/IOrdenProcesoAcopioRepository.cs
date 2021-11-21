﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IOrdenProcesoAcopioRepository
    {
        string Registrar(OrdenProcesoAcopio ordenProceso);
        IEnumerable<ConsultarOrdenProcesoAcopioDTO> Consultar(DateTime fechaInicio, DateTime fechaFin);
        IEnumerable<ConsultarPorIdOrdenProcesoDTO> ConsultarPorId(int ordenProcesoId);
        void ActualizarTipoProceso(int ordenProcesoId, string tipoProceso, string usuario, DateTime fecha);
    }
}