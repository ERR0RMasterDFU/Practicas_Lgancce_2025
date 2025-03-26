using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PeliculasApi.Excepciones
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // COMPROBAMOS SI LA EXCEPCIÓN ES DEL TIPO "EntityNotFoundException"
            if (context.Exception is EntityNotFoundException ex)
            {
                // CREA UNA RESPUESTA
                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = "Entidad no encontrada",
                    Detail = ex.Message,
                };

                // INFORMACIÓN ADICIONAL
                context.Result = new ObjectResult(problemDetails)
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };

                // MARCAR EXCEPCIÓN COMO MANEJADA
                context.ExceptionHandled = true;
            }
        }
    }
}
