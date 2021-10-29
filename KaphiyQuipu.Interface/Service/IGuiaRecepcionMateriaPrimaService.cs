﻿using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGuiaRecepcionMateriaPrimaService
    {
        List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO consultaGuiaRecepcionMateriaPrimaRequestDTO);
        int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request);

        ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(ConsultaGuiaRecepcionMateriaPrimaPorIdRequestDTO request);
        int RegistrarPesadoGuiaRecepcionMateriaPrima(RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO request);
        int ActualizarPesadoGuiaRecepcionMateriaPrima(RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO request);
        
        int ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidad(ActualizarGuiaRecepcionMateriaPrimaAnalisisCalidadRequestDTO request);

        //int EnviarGuardiolaGuiaRecepcionMateriaPrima(EnviarGuardiolaGuiaRecepcionMateriaPrimaRequestDTO request);

    }
}
