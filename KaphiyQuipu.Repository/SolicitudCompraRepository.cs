using CoffeeConnect.Repository;
using Dapper;
using KaphiyQuipu.Interface.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Repository
{
    public class SolicitudCompraRepository: ISolicitudCompraRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public SolicitudCompraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        //public int Registrar()
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@Correlativo", contrato.Numero);
        //    parameters.Add("@DistribuidorId", contrato.Numero);
        //    parameters.Add("@DepartamentoId", contrato.Numero);
        //    parameters.Add("@MonedaId", contrato.Numero);
        //    parameters.Add("@UnidadMedidaId", contrato.Numero);
        //    parameters.Add("@TipoProduccionId", contrato.Numero);
        //    parameters.Add("@EmpaqueId", contrato.Numero);
        //    parameters.Add("@TipoEmpaqueId", contrato.Numero);
        //    parameters.Add("@PesoSaco", contrato.Numero);
        //    parameters.Add("@PesoKilos", contrato.Numero);
        //    parameters.Add("@Observaciones", contrato.Numero);
        //    parameters.Add("@HashBC", contrato.Numero);
        //    parameters.Add("@Estado", contrato.Numero);
        //    parameters.Add("@EstadoId", contrato.Numero);
        //    parameters.Add("@UsuarioRegistro", contrato.Numero);

        //}
    }
}
