﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaIngresoAcopioRepository
    {
        string Registrar(NotaIngresoAlmacenAcopio nota);
        IEnumerable<ConsultaNotaIngresoAcopioDTO> Consultar(ConsultaNotaIngresoAcopioRequestDTO request);
        IEnumerable<ConsultaPorIdNotaIngresoAcopioDTO> ConsultarPorId(int notaIngresoId);
        IEnumerable<ConsultaPorIdNotaIngresoAcopioAgricultoresDTO> ObtenerAgricultores(int notaIngresoId);
        IEnumerable<ConsultaPorIdNotaIngresoAcopioControlCalidadDTO> ObtenerControlesCalidad(int notaIngresoId);
        void UbicarMateriaPrimaAlmacen(UbicarMateriaPrimaAlmacenRequestDTO request);
    }
}
