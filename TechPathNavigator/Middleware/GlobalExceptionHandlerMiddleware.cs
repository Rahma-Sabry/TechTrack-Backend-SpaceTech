using FluentValidation;
using System.Net;
using System.Text.Json;

namespace TechPathNavigator.Middleware
{
    /// <summary>
    /// Global exception handler middleware
    /// Catches all unhandled exceptions and returns consistent error responses
    /// </summary>
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionHandlerMiddleware> _logger)
        {
            _next = next;
            this._logger = _logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private record ErrorResponse(int StatusCode, string Message, object Errors);

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                ValidationException validationEx => new ErrorResponse(
                    (int)HttpStatusCode.BadRequest,
                    "Validation failed",
                    validationEx.Errors.Select(e => new
                    {
                        Property = e.PropertyName,
                        Error = e.ErrorMessage
                    })
                ),
                KeyNotFoundException => new ErrorResponse(
                    (int)HttpStatusCode.NotFound,
                    exception.Message,
                    null
                ),
                UnauthorizedAccessException => new ErrorResponse(
                    (int)HttpStatusCode.Unauthorized,
                    "Unauthorized access",
                    null
                ),
                _ => new ErrorResponse(
                    (int)HttpStatusCode.InternalServerError,
                    "An internal server error occurred",
                    null
                )
            };

            context.Response.StatusCode = response.StatusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    /// <summary>
    /// Extension method to add global exception handler
    /// </summary>
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
