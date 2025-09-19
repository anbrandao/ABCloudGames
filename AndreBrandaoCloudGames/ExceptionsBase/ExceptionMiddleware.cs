using AspNet.CorrelationIdGenerator;
using System.Net;
using System.Text.Json;

namespace AndreBrandaoCloudGamesApi.ExceptionsBase
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly ICorrelationIdGenerator _correlationIdGenerator;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, ICorrelationIdGenerator correlationIdGenerator)
        {
            _logger = logger;
            _correlationIdGenerator = correlationIdGenerator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next) 
        { 
            try
            {
                await next(context);
            } 
            catch (Exception ex)
            {
                var correlationId = _correlationIdGenerator.Get();
                _logger.LogError(ex, "Erro não tratado. CorrelationId: {CorrelationId}", correlationId);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is ErrorOnValidationException validationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var json = JsonSerializer.Serialize(new ResponseErrorJson(validationException.ErrorMessages));
                await context.Response.WriteAsync(json);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var json = JsonSerializer.Serialize(new ResponseErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
                await context.Response.WriteAsync(json);
            }
        }
    }
}
