﻿using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.DTO
{
    public class GenerarLoteRequestDTO
    {
        public List<TablaIdsTipo> NotasIngresoAlmacenId { get; set; }

        public String Usuario { get; set; }
        public int EmpresaId { get; set; }
        public string AlmacenId { get; set; }
        public string ProductoId
        { get; set; }

        public string SubProductoId
        { get; set; }

        public string TipoCertificacionId
        { get; set; }
    }
}
