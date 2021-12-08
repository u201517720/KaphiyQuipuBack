using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Agricultor;
using KaphiyQuipu.DTO.ContratoCompraVenta;
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
        SolicitudConfirmacionAgrigultorDTO ObtenerDatosSolicitudConfirmacionAgrigultor(int socioFincaId, int contratoId);
        void RegistrarControlCalidad(List<RegistrarControlCalidadDTO> listaControles);
        IEnumerable<ObtenerControlCalidadDTO> ObtenerControlCalidad(int contratoId);
        void ConfirmarRecepcionCafeTerminado(int id, string usuario, DateTime fecha);
        IEnumerable<CorrelativoTrazabilidadContratoDTO> ObtenerCorrelativosTrazabilidadPorNroContrato(string nroContrato);
    }
}