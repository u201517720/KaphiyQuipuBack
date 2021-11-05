using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IContratoRepository
    {
        IEnumerable<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request);
        ConsultaContratoPorIdDTO ConsultarPorId(int contratoId);
        string Registrar(Contrato contrato);
        void Confirmar(int ContratoId, string hash, string usuario);
        void AsociarAgricultoresContrato(List<AsociarAgricultoresContratoDTO> request);
        IEnumerable<ObtenerAgricultoresPorContratoDTO> ObtenerAgricultoresPorContrato(int contratoId);
    }
}