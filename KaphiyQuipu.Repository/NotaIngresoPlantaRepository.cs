using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KaphiyQuipu.Repository
{
    public class NotaIngresoPlantaRepository: INotaIngresoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public NotaIngresoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public void AutorizarTransformacion(int id, string usuario, DateTime fecha, string hashBC)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);
            parameters.Add("@pHashBC", hashBC);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspAutorizarTransformacionNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void ConfirmarRecepcionMateriaPrima(int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);
            
            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarRecepcionMateriaPrimaNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaNotaIngresoPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", fechaInicio);
            parameters.Add("@pFechaFin", fechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoPlantaDTO>("uspConsultarNotasIngresosPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPorIdNotaIngresoPlantaDTO> ConsultarPorId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPorIdNotaIngresoPlantaDTO>("uspConsultarNotaIngresoPlantaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void FinalizarEtiquetado(int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspFinalizarEtiquetadoNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<EtiquetaPlanta> GenerarEtiquetasPlanta(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<EtiquetaPlanta>("uspObtenerTicketPesadoPorNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string Registrar(NotaIngresoPlanta nota)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", nota.Correlativo);
            parameters.Add("@pGuiaRemisionAcopioId", nota.GuiaRemisionAcopioId);
            parameters.Add("@pObservaciones", nota.Observaciones);
            parameters.Add("@pUsuarioRegistro", nota.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", nota.FechaRegistro);
            parameters.Add("@pHashBC", nota.HashBC);  

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public void RegistrarControlCalidad(NotaIngresoPlanta notaIngreso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", notaIngreso.Id);
            parameters.Add("@pOlores", notaIngreso.Olores);
            parameters.Add("@pColores", notaIngreso.Colores);
            parameters.Add("@pExportableGramos", notaIngreso.ExportableGramos);
            parameters.Add("@pExportablePorcentaje", notaIngreso.ExportablePorcentaje);
            parameters.Add("@pDescarteGramos", notaIngreso.DescarteGramos);
            parameters.Add("@pDescartePorcentaje", notaIngreso.DescartePorcentaje);
            parameters.Add("@pCascarillaGramos", notaIngreso.CascarillaGramos);
            parameters.Add("@pCascarillaPorcentaje", notaIngreso.CascarillaPorcentaje);
            parameters.Add("@pTotalGramos", notaIngreso.TotalGramos);
            parameters.Add("@pTotalPorcentaje", notaIngreso.TotalPorcentaje);
            parameters.Add("@pHumedadPorcentaje", notaIngreso.HumedadPorcentaje);
            parameters.Add("@pHashBC", notaIngreso.HashBC);
            parameters.Add("@pUsuario", notaIngreso.UsuarioActualizacion);
            parameters.Add("@pFecha", notaIngreso.FechaActualizacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspRegistrarControlCalidadNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void RegistrarResultadosTransformacion(NotaIngresoPlantaResultadoTransformacion transformacion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNotaIngresoPlantaId", transformacion.NotaIngresoPlantaId);
            parameters.Add("@pCafeExportacionSacos", transformacion.CafeExportacionSacos);
            parameters.Add("@pCafeExportacionKilos", transformacion.CafeExportacionKilos);
            parameters.Add("@pCafeExportacionMCSacos", transformacion.CafeExportacionMCSacos);
            parameters.Add("@pCafeExportacionMCKilos", transformacion.CafeExportacionMCKilos);
            parameters.Add("@pCafeSegundaSacos", transformacion.CafeSegundaSacos);
            parameters.Add("@pCafeSegundaKilos", transformacion.CafeSegundaKilos);
            parameters.Add("@pCafeDescarteMaquinaSacos", transformacion.CafeDescarteMaquinaSacos);
            parameters.Add("@pCafeDescarteMaquinaKilos", transformacion.CafeDescarteMaquinaKilos);
            parameters.Add("@pCafeDescarteEscojoSacos", transformacion.CafeDescarteEscojoSacos);
            parameters.Add("@pCafeDescarteEscojoKilos", transformacion.CafeDescarteEscojoKilos);
            parameters.Add("@pCafeBolaSacos", transformacion.CafeBolaSacos);
            parameters.Add("@pCafeBolaKilos", transformacion.CafeBolaKilos);
            parameters.Add("@pCafeCiscoSacos", transformacion.CafeCiscoSacos);
            parameters.Add("@pCafeCiscoKilos", transformacion.CafeCiscoKilos);
            parameters.Add("@pTotalCafeSacos", transformacion.TotalCafeSacos);
            parameters.Add("@pTotalCafeKgNetos", transformacion.TotalCafeKgNetos);
            parameters.Add("@pPiedraOtrosKgNetos", transformacion.PiedraOtrosKgNetos);
            parameters.Add("@pCascaraOtrosKgNetos", transformacion.CascaraOtrosKgNetos);
            parameters.Add("@pHashBC", transformacion.HashBC);
            parameters.Add("@pUsuarioRegistro", transformacion.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", transformacion.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspRegistrarResultadosTransformacionNotaIngresoAlmacen", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string ObtenerCorrelativoNotaingresoPorId(int id)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspObtenerCorrelativoNotaIngresoPlantaPorId", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
