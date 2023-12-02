using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Tachograph.Services.Web.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        protected readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"\n------------------------------------\n{ex.InnerException?.Message ?? ex.Message}\n------------------------------------");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var message = exception.InnerException?.Message ?? exception.Message;

            switch (exception)
            {
                case ArgumentNullException:
                case ValidationException:
                case FileLoadException:
                    await HanldeErrorResponse(context, message, HttpStatusCode.BadRequest);
                    break;
                case UnauthorizedAccessException:
                    await HanldeErrorResponse(context, message, HttpStatusCode.Unauthorized);
                    break;
                default:
                    await HanldeErrorResponse(context);
                    break;
            }

        }

        private async Task HanldeErrorResponse(HttpContext context, string? message = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            if (message == null)
                message = "SomeErrorWentWrong";

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(new ErrorResponeModel()
            {
                StatusCode = (int)statusCode,
                Message = message
            }.ToString());
        }
    }
}

public class ErrorResponeModel
{
    public virtual int StatusCode { get; set; }
    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
