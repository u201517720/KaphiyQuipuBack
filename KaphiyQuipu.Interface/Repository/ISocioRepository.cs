﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISocioRepository
    {
        int Insertar(Socio socio);

        int Actualizar(Socio socio);

        IEnumerable<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request);

        ConsultaSocioPorIdBE ConsultarSocioPorId(int socioId);

        ConsultarSocioProductorPorSocioFincaId ConsultarSocioProductorPorSocioFincaId(int socioFincaId);

        IEnumerable<ConsultaSocioBE> ValidarSocio(int productorId);

    }
}