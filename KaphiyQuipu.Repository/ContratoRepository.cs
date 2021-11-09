using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.Common;
using KaphiyQuipu.DTO.Agricultor;
using KaphiyQuipu.DTO.ContratoCompraVenta;

namespace KaphiyQuipu.Repository
{
    public class ContratoRepository : IContratoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ContratoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pFechaFin", request.FechaFin);
            parameters.Add("@pRolId", request.RolId);
            parameters.Add("@pCodigoCliente", request.CodigoDistribuidor);
            parameters.Add("@pUserId", request.UserId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaContratoDTO>("uspContratoCompraVentaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaContratoPorIdDTO ConsultarPorId(int contratoId)
        {
            ConsultaContratoPorIdDTO itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@pContratoId", contratoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaContratoPorIdDTO>("uspContratoCompraVentaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }

        public string Registrar(Contrato contrato)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", contrato.Correlativo);
            parameters.Add("@pSolicitudCompraId", contrato.SolicitudCompraId);
            parameters.Add("@pEmpresaId", contrato.EmpresaId);
            parameters.Add("@pObservaciones", contrato.Observaciones);
            parameters.Add("@pUsuarioRegistro", contrato.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", contrato.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspRegistrarContratoCompraVenta", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public void Confirmar(int ContratoId, string hash, string usuario)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pContratoId", ContratoId);
            parameters.Add("@pHashBC", hash);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", DateTime.Now);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspContratoConfirmar", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void AsociarAgricultoresContrato(List<AsociarAgricultoresContratoDTO> request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pttAgricultores", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspRegistrarContratoSocioFinca", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ObtenerAgricultoresPorContratoDTO> ObtenerAgricultoresPorContrato(int contratoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pContratoId", contratoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ObtenerAgricultoresPorContratoDTO>("uspObtenerAgricultoresPorContradoId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public SolicitudConfirmacionAgrigultorDTO ObtenerDatosSolicitudConfirmacionAgrigultor(int socioFincaId, int contratoid)
        {
            SolicitudConfirmacionAgrigultorDTO itemBE = null;
            var parameters = new DynamicParameters();
            parameters.Add("@pSocioFincaId", socioFincaId);
            parameters.Add("@pContratoid", contratoid);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<SolicitudConfirmacionAgrigultorDTO>("uspContratoSocioFincaAgricultorConsulta", parameters, commandType: CommandType.StoredProcedure);

                if(list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public void RegistrarControlCalidad(List<RegistrarControlCalidadDTO> listaControles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pTabla", listaControles.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.ExecuteScalar<string>("uspRegistrarControlCalidadContratoPorAgricultor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ObtenerControlCalidadDTO> ObtenerControlCalidad(int contratoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pContratoId", contratoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ObtenerControlCalidadDTO>("uspObtenerControlCalidadPoRContratoId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
