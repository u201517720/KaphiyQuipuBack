using KaphiyQuipu.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGuiaRemisionAlmacenService
    {           
        GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaSalidaAlmacenId(int guiaRemisionAlmacenId);
        

    }
}
