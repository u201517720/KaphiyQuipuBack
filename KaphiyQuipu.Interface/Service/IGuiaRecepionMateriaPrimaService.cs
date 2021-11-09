using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGuiaRecepionMateriaPrimaService
    {
        List<ConsultaGuiaRecepcionMateriaPrimaDTO> Consultar(ConsultarGuiaRecepcionMateriaPrimaRequestDTO request);
        string Registrar(RegistrarActualizarGuiaRecepcionRequestDTO request);
        ConsultarPorIdGuiaRecepcionMateriaPrimaDTO ConsultarPorId(ConsultarPorIdGuiaRecepcionMateriaPrimaRequestDTO request);
    }
}
