using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.ERC20
{
    public struct Functions
    {
        public struct Usuario
        {
            public static string FUNCTION_VALIDATE_USER = "validateUser";
            public static string FUNCTION_GET_USER = "getUser";
            public static string FUNCTION_TOTAL_USERS = "totalUsers";
            public static string FUNCTION_USERS = "users";
        }

        public struct SolicitudCompra
        {
            public static string AGREGAR_SOLICITUD = "agregarSolicitud";
            public static string OBTENER_SOLICITUD = "obtenerSolicitud";
            public static string OBTENER_TOTAL_SOLICITUD = "obtenerTotalSolicitudes";
        }

        public  struct ContratoCompra
        {
            public static string AGREGAR_CONTRATO = "agregarContrato";
            public static string OBTENER_CONTRATO = "obtenerContrato";
            public static string AGREGAR_AGRICULTOR = "agregarAgricultor";
            public static string OBTENER_AGRICULTORES = "obtenerAgricultores";

            public static string AGREGAR_CONTROL_CALIDAD = "agregarControlCalidad";
            public static string OBTENER_CONTROL_CALIDAD = "obtenerControlCalidad";
            public static string AGREGAR_ANALISIS_FISICO_CAFE = "agregarAnalisisFisicoCafe";
            public static string OBTENER_ANALISIS_FISICO_CAFE = "obtenerAnalisisFisicoCafe";
        }
    }
}
