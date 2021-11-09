using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRecepcionMateriaPrimaRepository
    {
        IEnumerable<ConsultaGuiaRecepcionMateriaPrimaDTO> Consultar(ConsultarGuiaRecepcionMateriaPrimaRequestDTO request);
        string Registrar(GuiaRecepcionMateriaPrima guia);
        IEnumerable<ConsultarPorIdGuiaRecepcionMateriaPrimaDTO> ConsultarPorId(int guiaRecepcionId);
        IEnumerable<AgricultoresGuiaRecepcionMateriaPrimaDTO> ObtenerAgricultores(int guiaRecepcionId);
        IEnumerable<GuiaRecepcionMateriaPrimaControlCalidadDTO> ObtenerControlesCalidad(int guiaRecepcionId);
    }
}
