using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> _logger)
        {
            this.logger = _logger;
        }

        [Route("/error")]
        public IActionResult Error() => Problem();

        [Route("/error-logger")]
        public IActionResult ErrorLogger()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            this.logger.Log(LogLevel.Error, context.Error.Message);

            return Problem();
        }

        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
         [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }
    }
}
