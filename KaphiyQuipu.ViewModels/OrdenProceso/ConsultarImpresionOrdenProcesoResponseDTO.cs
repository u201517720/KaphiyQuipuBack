﻿using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.DTO
{
    public class ConsultarImpresionOrdenProcesoResponseDTO
    {
        public ConsultarImpresionOrdenProcesoResponseDTO()
        {
            listOrdenProceso = new List<OrdenProcesoDTO>();
            listDetalleOrdenProceso = new List<OrdenProcesoDetalle>();
        }

        public IEnumerable<OrdenProcesoDTO> listOrdenProceso { get; set; }
        public IEnumerable<OrdenProcesoDetalle> listDetalleOrdenProceso { get; set; }
    }
}
