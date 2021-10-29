﻿using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IPrecioDiaRendimientoService
    {
        List<ConsultaPrecioDiaRendimientoBE> ConsultarPrecioDiaRendimiento(ConsultarPrecioDiaRendimientoRequestDTO request);
        int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);

        int AnularPrecioDiaRendimiento(AnularPrecioDiaRendimientoRequestDTO request);

        CalculoPrecioDiaRendimientoDTO CalcularPrecioDiaRendimiento(CalcularPrecioDiaRendimientoRequestDTO request);

        List<PorcentajeRendimientoBE> ConsultarPorcentajeRendimiento(CalcularPrecioDiaRendimientoRequestDTO request);

         int ActualizarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request);

        ConsultaPrecioDiaRendimientoBE ConsultarPrecioDiaRendimientoPorId(ConsultaPrecioDiaRendimientoPorIdRequestDTO request);
    }
}
