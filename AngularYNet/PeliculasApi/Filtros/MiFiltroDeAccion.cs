using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PeliculasApi.Filtros
{
    public class MiFiltroDeAccion : IActionFilter
    {

        private readonly Logger<MiFiltroDeAccion> logger;

        public MiFiltroDeAccion(Logger<MiFiltroDeAccion> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("ANTES");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("DESPUÉS");
        }
    }
}
