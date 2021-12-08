using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO.Seguridad
{
    public class UsuarioDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Empresa { get; set; }
        public string Role { get; set; }
    }
}
