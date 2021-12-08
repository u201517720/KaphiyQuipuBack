using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Blockchain.Contracts.Interface
{
    public interface INotaIngresoPlantaContract
    {
        Task<TransactionResult> RegistrarControlCalidad(RegistrarControlCalidadNotaIngresoPlantaRequestDTO controlCalidad, string correlativo, DateTime fechaRegistro);
        Task<NotaIngresoPlantaCalidadOutputDTO> ObtenerControlCalidadPorCorrelativo(string correlativo);
        Task<TransactionResult> RegistrarResultadoTransformacion(RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO resultado, string correlativo, DateTime fechaRegistro);
        Task<NotaIngresoPlantaResultadoTransfOutputDTO> ObtenerResultadoTransformacionPorCorrelativo(string correlativo);

    }
}
