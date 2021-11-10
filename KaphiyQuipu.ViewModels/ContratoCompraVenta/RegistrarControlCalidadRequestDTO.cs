﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarControlCalidadRequestDTO
    {
        public RegistrarControlCalidadRequestDTO()
        {
            controles = new List<RegistrarControlCalidadDTO>();
        }

        public List<RegistrarControlCalidadDTO> controles { get; set; }
    }

    public class RegistrarControlCalidadDTO
    {
        public RegistrarControlCalidadDTO()
        {

        }

        public int ContratoSocioFincaId { get; set; }
        public decimal Humedad { get; set; }
        public string Observaciones { get; set; }
        public string ListaOlores { get; set; }
        public string ListaColores { get; set; }
        public string UsuarioCreacion { get; set; }
        public string HashBC { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
