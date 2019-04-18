using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherForecast.Web
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is Refit.ApiException ex)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                context.Result = new JsonResult(ex.Content);
                context.ExceptionHandled = true;
            }
        }
    }
}
