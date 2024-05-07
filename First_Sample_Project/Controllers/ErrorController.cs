using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First_Sample_Project.Controllers
{
    public class ErrorController : Controller
    {

        private readonly ILogger _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger=logger;
        }

        public IActionResult Exception()
        {
            var exceptiondetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if(exceptiondetails!=null)
            {
                _logger.LogError(exceptiondetails.Path, "Path of the exception details and exception", exceptiondetails.Error.Message);
            }

            ViewBag.Exceptionpath=exceptiondetails.Path;
            ViewBag.ExceptionMessage=exceptiondetails.Error.Message;
            ViewBag.Exceptionstacktrace=exceptiondetails.Error.StackTrace;

            return View("Exception");
        }

        public IActionResult StatusCodeResult(int? statuscode)
        {
            var statuscodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            if (statuscode == 404)
            {
                ViewBag.Display="Sorry your requested response 404 was not found";
            }
            else if (statuscode == 500)
            {
                ViewBag.Display = "Sorry Internal Server error message.";
            }
            else
            {
                ViewBag.Display = "An error occurred while processing your request.";
            }
            return View();
        }


    }
}
