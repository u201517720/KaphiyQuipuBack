﻿using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaIngresoAlmacenService
    {
       
        int Registrar(EnviarAlmacenGuiaRecepcionMateriaPrimaRequestDTO request);

        List<ConsultaNotaIngresoAlmacenBE> ConsultarNotaIngresoAlmacen(ConsultaNotaIngresoAlmacenRequestDTO request);

        int AnularNotaIngresoAlmacen(AnularNotaIngresoAlmacenRequestDTO request);

        int ActualizarNotaIngresoAlmacen(ActualizarNotaIngresoAlmacenRequestDTO request);

        ConsultaNotaIngresoAlmacenPorIdBE ConsultarNotaIngresoAlmacenPorId(ConsultaNotaIngresoAlmacenPorIdRequestDTO request);
    }
}
