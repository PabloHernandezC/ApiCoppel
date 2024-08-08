using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCoppel.Errores
{
    public class ApiErrorResponse
    {

        public int StatusCode { get; set; }
        public string Mensaje { get; set; }

        public ApiErrorResponse(int statusCode, string mensaje = null)
        {
            StatusCode = statusCode;
            Mensaje = mensaje ?? GetMensajeStatusCode(statusCode);
        }

        private string GetMensajeStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Se ha realizado una solicitud no valida",
                401 => "No estas Autorizado para este recurso",
                404 => "Recurso no Encontrado",
                500 => "Error interno en el Servidor",
                _ => null
            };
        }
    }
}
