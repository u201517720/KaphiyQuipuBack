using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request);
        ConsultaClientePorIdBE ConsultarClientePorId(int clienteId);
        int Anular(int clienteId, DateTime fecha, string usuario, string estadoId);
    }
}