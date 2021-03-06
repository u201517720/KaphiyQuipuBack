using Core.Utils;
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

        public void ConfirmarVoucherPagoContratoCompra(int id, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarDepositoPagoContratoCompra", parameters, commandType: CommandType.StoredProcedure);
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

        public void GuardarVoucherContratoCompra(GuardarVoucherContratoCompraRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", request.Id);
            parameters.Add("@pUsuario", request.Usuario);
            parameters.Add("@pFecha", request.Fecha);
            parameters.Add("@pArchivo", request.Archivo);
            parameters.Add("@pRuta", request.Ruta);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspGuardarVoucherContratoCompra", parameters, commandType: CommandType.StoredProcedure);
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

        public dynamic ProyectarCosecha(int CantMeses, int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pMes", CantMeses);
            parameters.Add("@pUserId", userId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query("uspProyectarCosechaXAgricultor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public dynamic ProyectarVenta(int periodo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pMes", periodo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query("uspProyectarVenta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public dynamic ProyectarCosechaTodos(List<ColumnasProyeccionDTO> columnas, List<UserProyeccionCosechaDTO> users)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pColumnas", columnas.ToDataTable().AsTableValuedParameter());
            parameters.Add("@pData", users.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query("uspProyectarCosechaTodos", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public dynamic ProyectarTodasCosechasAcopio(int CantMeses)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pMes", CantMeses);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query("uspProyectarCosechaAgricultoresAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ValoracionesPorAgricultorDTO> ValoracionesPorAgricultor(ValoracionesPorAgricultorRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaFin", request.FechaFin);
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pUsuario", request.Usuario);
            parameters.Add("@pTipo", request.Tipo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ValoracionesPorAgricultorDTO>("uspListarValoracionesPorAgricultor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ListarPuntajeValoracionesAgricultoresDTO> ListarPuntajeValoracionesAgricultores(DateTime fIni, DateTime fFin, int tipo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaFin", fFin);
            parameters.Add("@pFechaInicio", fIni);
            parameters.Add("@pTipo", tipo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ListarPuntajeValoracionesAgricultoresDTO>("uspListarValoracionesTodosAgricultores", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<string> GuardarValoracionClienteExterno(string contrato, string documento, string cliente, int puntaje, string comentario, DateTime fecha, string tipoDocumento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNroContrato", contrato);
            parameters.Add("@pDocumento", documento);
            parameters.Add("@pCliente", cliente);
            parameters.Add("@pPuntaje", puntaje);
            parameters.Add("@pComentario", comentario);
            parameters.Add("@pFecha", fecha);
            parameters.Add("@pTipoDoc", tipoDocumento);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<string>("uspGuardarValoracionClienteExterno", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
