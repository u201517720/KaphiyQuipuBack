using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Email
{
    public class ParametroEmail
    {
        public int IdReferencia { get; set; }
        public string Asunto { get; set; }
        public string Para { get; set; }
        public string ConCopia { get; set; }
        public string Plantilla { get; set; }
        public string Mensaje { get; set; }
        public bool IsHtml { get; set; }
    }
}
