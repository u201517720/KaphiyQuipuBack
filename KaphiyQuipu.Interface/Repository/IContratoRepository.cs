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
    }
}