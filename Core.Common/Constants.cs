using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public struct Constants
    {
        public struct TrazabilidadBC
        {
            public const string INGRESO_PLANTA_ACOPIO = "INGRESO_PLANTA_ACOPIO";
            public const string ENVIO_PLANTA_TRANSFORMADORA = "ENVIO_PLANTA_TRANSFORMADORA";
            public const string RECEPCION_MATERIA_PRIMA_PLANTA = "RECEPCION_MATERIA_PRIMA_PLANTA";
            public const string AUTORIZAR_TRANSFORMACION = "AUTORIZAR_TRANSFORMACION";
            public const string INICIAR_TRANSFORMACION = "INICIAR_TRANSFORMACION";
            //public const string TRANSFORMACION_MATERIA_PRIMA_A_CAFE_TERMINADA = "TRANSFORMACION_MATERIA_PRIMA_A_CAFE_TERMINADA";
            public const string ENVIO_CAFE_HACIA_COOPERATIVA = "ENVIO_CAFE_HACIA_COOPERATIVA";
            public const string RECEPCION_CAFE_PROCESADO_POR_COOPERATIVA = "RECEPCION_CAFE_PROCESADO_POR_COOPERATIVA";
            public const string ENVIO_CAFE_HACIA_DISTRIBUIDORA = "ENVIO_CAFE_HACIA_DISTRIBUIDORA";
            public const string CONFIRMAR_RECEPCION_MATERIA_PROCESADA = "CONFIRMAR_RECEPCION_MATERIA_PROCESADA";
        }
    }
}
