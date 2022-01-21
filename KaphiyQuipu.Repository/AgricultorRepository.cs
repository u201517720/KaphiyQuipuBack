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

        public void ConfirmarDisponibilidad(int ContratoSocioFincaId, string usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pContratoSocioFincaId", ContratoSocioFincaId);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", DateTime.Now);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspConfirmarCantidadMateriaPrima", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void ConfirmarEnvio(int ContratoSocioFincaId, string usuario, string hash)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pContratoSocioFincaId", ContratoSocioFincaId);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", DateTime.Now);
            parameters.Add("@pHashBC", hash);

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

        public IEnumerable<ListarCosechasPorAgricultorDTO> ListarCosechasPorAgricultor(ListarCosechasPorAgricultorRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pIdUsuario", request.CodigoUsuario);
            parameters.Add("@pFecInicio", request.FechaInicio);
            parameters.Add("@pFecFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ListarCosechasPorAgricultorDTO>("uspConsultarCosechasPorAgricultor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ListarFincasPorAgricultorDTO> ListarFincasPorAgricultor(int codigoUsuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pIdUsuario", codigoUsuario);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ListarFincasPorAgricultorDTO>("uspObtenerFincasPorProductor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConfirmacionEnvioAgricultorDTO ObtenerDatosConfirmacionEnvio(int contratoSocioFincaId)
        {
            ConfirmacionEnvioAgricultorDTO itemBE = null;
            var parameters = new DynamicParameters();
            parameters.Add("@ContratoSocioFincaId", contratoSocioFincaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConfirmacionEnvioAgricultorDTO>("uspContratoSocioFincaConsulta", parameters, commandType: CommandType.StoredProcedure);
                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public void RegistrarCosechaPorFinca(RegistrarCosechaPorFincaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pSocioFincaId", request.CodigoSocioFinca);
            parameters.Add("@pPesoNeto", request.PesoNeto);
            parameters.Add("@pFecCosecha", request.FechaCosecha);
            parameters.Add("@pUnidMedicionId", request.UnidadMedida);
            parameters.Add("@pUsuario", request.Usuario);
            parameters.Add("@pFecha", request.Fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspRegistrarCosechaPorAgricultor", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
