using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Adapter
{
    public class AuditResponse
    {
        //public string idTransaccion { get; set; }

        //0 -> Operación con éxito
        //1 -> Faltan parámetros de entrada
        //2 -> No se encontraron datos
        //-1 -> Error de Timeout en bD
        //-2 -> Error de disponibilidad en bd
        //-3 -> Error de timeout en servicio
        //-4 -> Error de disponibilidad en bd
        //-5 -> Ocurrio un error inesperado
        /// <summary>
        ///  Código de respuesta de la solicitud
        /// </summary>
        public string codigoRespuesta { get; set; }
        /// <summary>
        ///  Mensaje de respuesta de la solicitud
        /// </summary>
        public string mensajeRespuesta { get; set; }

        //Ok = 200,
        //Creado = 201,
        //PeticionIncorrecta = 400,
        //NoAutorizado = 401,
        //NoEncontrado = 404,
        //ErrorInterno = 500,
        //ServicioNoDisponible = 503,
        //TimeOut = 504

        /// <summary>
        ///  Código de error de la solicitud
        /// </summary>
        public Int32 statusCode { get; set; }
    }
}
