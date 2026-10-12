using System.Net;
using System.Security.Claims;
using System.Text.Json;
using static MonoPraksa.Middleware.AppExceptions;

namespace MonoPraksa.Middleware;

public class ExceptionMiddleware
{
    //next = “što je sljedeće u lancu” (na kraju tvoj controller)
    private readonly RequestDelegate _next;
    //_logger = alat za pisanje grešaka u konzolu.
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "anonymous";
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value ?? "anonymous";
            var method = context.Request.Method;
            var path = context.Request.Path;

            var (status, message) = ex switch
            {
                NotFoundException => (404, ex.Message),
                BadRequestException => (400, ex.Message),
                ConflictException => (409, ex.Message),
                _ => (500, "Došlo je do greške na serveru.")
            };

            if (status == 500)
                _logger.LogError(ex, "Unhandled exception. User: {UserId} ({Email}), Request: {Method} {Path}",
                    userId, email, method, path);
            else
                _logger.LogWarning("{Message}. User: {UserId} ({Email}), Request: {Method} {Path}",
                    ex.Message, userId, email, method, path);

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
        }
    }
}