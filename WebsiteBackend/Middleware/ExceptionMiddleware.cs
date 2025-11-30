using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using WebsiteBackend.Utils;

namespace WebsiteBackend.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        
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
            catch (AppException ex)
            {
                _logger.LogError(ex, "Application Error: {Message}", ex.Message);
                await HandleExceptionAsync(httpContext, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception: {Message}", ex.Message);
                await HandleExceptionAsync(httpContext, (int)HttpStatusCode.InternalServerError, "服务器内部错误");
            }
        }
        
        private async Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            
            var response = ApiResponse<object>.ErrorResponse(message);
            
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}