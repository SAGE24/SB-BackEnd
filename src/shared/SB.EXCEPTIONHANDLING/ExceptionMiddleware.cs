using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SB.EXCEPTIONHANDLING.Dtos;
using System.Net;

namespace SB.EXCEPTIONHANDLING;
public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string message = $"Se ha producido un error al procesar solicitud: {ex.Message}";
            _logger.LogError(ex, message);

            var response = context.Response;

            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = (int)httpStatusCode;

                ErrorException errorResult = new((int)httpStatusCode, message);

                await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
            }
        }
    }
}
