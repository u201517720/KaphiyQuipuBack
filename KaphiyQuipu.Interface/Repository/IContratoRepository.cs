﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IContratoRepository
    {
        IEnumerable<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request);
        int Insertar(Contrato contrato);
        int Actualizar(Contrato contrato);
        ConsultaContratoPorIdBE ConsultarContratoPorId(int contratoId);
        int ActualizarEstado(int contratoId, DateTime fecha, string usuario, string estadoId);
        ConsultarTrackingContratoPorContratoIdBE ConsultarTrackingContratoPorContratoId(int contratoId, string idioma);
        IEnumerable<ConsultarTrackingContratoPorContratoIdBE> ConsultarTrackingContrato(ConsultaTrackingContratoRequestDTO request);
        decimal CalcularPrecioDiaContrato(int empresaId);
        int AsignarAcopio(int contratoId, DateTime fecha, string usuario, string estadoId, decimal kgPergaminoAsignacion, decimal porcentajeRendimientoAsignacion, decimal totalKGPergaminoAsignacion);
        int ValidadContratoAsignado(int empresaId, string estadoId);
        ConsultaContratoAsignado ConsultarContratoAsignado(int empresaId, string estadoId);
        int ActualizarSaldoPendienteAsignacionAcopio(int contratoId, decimal totalKGPergaminoIngreso);
        int ValidadContratoExistente(int empresaId, string numero);
    }
}