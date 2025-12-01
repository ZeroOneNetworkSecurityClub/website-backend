using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using website_backend.Models;

namespace website_backend.Middleware;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = ApiResponse<object>.ErrorResponse(
            "Internal Server Error",
            "An unexpected error occurred. Please try again later."
        );

        // 根据不同异常类型返回更具体的错误信息
        if (exception is ArgumentException argEx)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            response = ApiResponse<object>.ErrorResponse(
                "Bad Request",
                argEx.Message
            );
        }
        else if (exception is KeyNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            response = ApiResponse<object>.ErrorResponse(
                "Not Found",
                "The requested resource was not found."
            );
        }

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}