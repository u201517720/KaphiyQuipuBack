﻿using System;

namespace KaphiyQuipu.DTO
{
    public class RegistrarActualizarContratoRequestDTO
    {
        public RegistrarActualizarContratoRequestDTO()
        {

        }

        public int ContratoId { get; set; }
        public string Correlativo { get; set; }
        public int SolicitudCompraId { get; set; }
        public int EmpresaId { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
        public string EstadoId { get; set; }
    }
}
