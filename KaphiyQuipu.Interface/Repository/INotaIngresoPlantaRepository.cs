using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaIngresoPlantaRepository
    {
        IEnumerable<ConsultaNotaIngresoPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin);
        string Registrar(NotaIngresoPlanta nota);
        IEnumerable<ConsultarPorIdNotaIngresoPlantaDTO> ConsultarPorId(int id);
        void RegistrarControlCalidad(NotaIngresoPlanta notaIngreso);
        void ConfirmarRecepcionMateriaPrima(int id, string usuario, DateTime fecha);
        void AutorizarTransformacion(int id, string usuario, DateTime fecha);
        void FinalizarEtiquetado(int id, string usuario, DateTime fecha);
        void RegistrarResultadosTransformacion(NotaIngresoPlantaResultadoTransformacion transformacion);
        IEnumerable<EtiquetaPlanta> GenerarEtiquetasPlanta(int id);
    }
}
