using KaphiyQuipu.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGuiaRemisionAlmacenPlantaService
    {           
        GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPlantaPorNotaSalidaAlmacenId(int notaSalidaAlmacenIdId);
        

    }
}
