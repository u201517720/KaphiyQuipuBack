using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public GeneralRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public void AprobarDepositoPlanta(int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspAprobarDepositoPagoAPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void ConfirmarVoucherPago(int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarDepositoPagoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void ConfirmarVoucherPagoPlanta(int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarDepositoPagoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(string correlativoDPA, string correlativoCC, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativoDPA", correlativoDPA);
            parameters.Add("@pCorrelativoCC", correlativoCC);
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarDocumentoPagoDTO>("uspConsultarDocumentosPagos", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarDocumentoPagoPlantaDTO> ConsultarDocumentoPagoPlanta(string documento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNroDoc", documento);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarDocumentoPagoPlantaDTO>("uspConsultarDocumentosPagosPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarDocumentoPagoPlantaPorIdDTO> ConsultarDocumentoPagoPlantaPorId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarDocumentoPagoPlantaPorIdDTO>("uspConsultarDocumentosPagosPlantaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarDocumentoPagoPorIdDTO> ConsultarDocumentoPagoPorId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarDocumentoPagoPorIdDTO>("uspConsultarDocumentoPagoPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPagoContratoDTO> ConsultarPagoContrato(string documento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNroDoc", documento);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPagoContratoDTO>("uspConsultarPagoContratoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPagoContratoIdDTO> ConsultarPagoContratoId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPagoContratoIdDTO>("uspConsultarPagoContratoAcopioPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void GenerarPagoDistribuidor(string correlativo, int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pCorrelativo", correlativo);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspGenerarPagoContratoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void GenerarPagoPendientePlanta(int id, string correlativo, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNotaIngresoPlantaId", id);
            parameters.Add("@pCorrelativo", correlativo);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspGenerarDocumentoPagoTransformacion", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void GuardarVoucher(GuardarVoucherRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", request.Id);
            parameters.Add("@pUsuario", request.Usuario);
            parameters.Add("@pFecha", request.Fecha);
            parameters.Add("@pArchivo", request.Archivo);
            parameters.Add("@pRuta", request.Ruta);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspGuardarVoucherAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void GuardarVoucherPlanta(GuardarVoucherPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", request.Id);
            parameters.Add("@pUsuario", request.Usuario);
            parameters.Add("@pFecha", request.Fecha);
            parameters.Add("@pArchivo", request.Archivo);
            parameters.Add("@pRuta", request.Ruta);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspGuardarVoucherPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
