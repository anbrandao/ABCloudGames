using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AndreBrandaoCloudGamesApi.ExceptionsBase
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext exceptioncontext)
        {
            if (exceptioncontext.Exception is AndreBrandaoCloudGamesException)
                HandleProjectException(exceptioncontext);
            else
                HandleUnknownException(exceptioncontext);
        }
        public void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException validationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(validationException.ErrorMessages));
            }

        }
        public void HandleUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.INTERNAL_SYSTEM_ERROR));
        }
    }
}
