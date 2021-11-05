using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IInspeccionInternaRepository
    {


        IEnumerable<InspeccionInternaParcela> ConsultarInspeccionInternaParcelaPorId(int inspeccionInternaId);

        IEnumerable<InspeccionInternaNorma> ConsultarInspeccionInternaNormasPorId(int inspeccionInternaId);

        IEnumerable<InspeccionInternaNoConformidad> ConsultarInspeccionInternaNoConformidadPorId(int inspeccionInternaId);

        IEnumerable<InspeccionInternaLevantamientoNoConformidad> ConsultarInspeccionInternaLevantamientoNoConformidadPorId(int inspeccionInternaId);


       int ActualizarInspeccionInternaParcela(List<InspeccionInternaParcelaTipo> request, int inspeccionInternaId);

        int ActualizarInspeccionInternaNormas(List<InspeccionInternaNormasTipo> request, int inspeccionInternaId);

        int ActualizarInspeccionInternaNoConformidad(List<InspeccionInternaNoConformidadTipo> request, int inspeccionInternaId);
        
        int ActualizarInspeccionInternaLevantamientoNoConformidad(List<InspeccionInternaLevantamientoNoConformidadTipo> request, int inspeccionInternaId);


    }
}
