using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KaphiyQuipu.Repository
{
    public class AgricultorRepository : IAgricultorRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public AgricultorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public void ConfirmarDisponibilidad(int ContratoSocioFincaId, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pContratoSocioFincaId", ContratoSocioFincaId);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarCantidadMateriaPrima", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void ConfirmarEnvio(int ContratoSocioFincaId, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pContratoSocioFincaId", ContratoSocioFincaId);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarEnvioMateriaPrima", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaAgricultorDTO> Consultar(ConsultaAgricultorRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pTipoCertificacionId", request.TipoCertificacionId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAgricultorDTO>("uspConsultaAgricultoresPorTipoCertificacion", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaMateriaPrimaSolicitadaDTO ConsultarDetalleMateriaPrimaSolicitada(int contratoSocioFincaId)
        {
            ConsultaMateriaPrimaSolicitadaDTO itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@pContratoSocioFincaId", contratoSocioFincaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaMateriaPrimaSolicitadaDTO>("uspConsultaSolicitudMateriaPrimaDetalle", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }

        public IEnumerable<ConsultaMateriaPrimaSolicitadaDTO> ConsultarMateriaPrimaSolicitada(ConsultaMateriaPrimaSolicitadaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pUserId", request.UserId);
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pFechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaMateriaPrimaSolicitadaDTO>("uspConsultaSolicitudesMateriaPrimaPorAgricultor", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
