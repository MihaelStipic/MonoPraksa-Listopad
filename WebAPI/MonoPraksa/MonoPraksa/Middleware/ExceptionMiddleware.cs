using System.Net;
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
            var (status, message) = ex switch
            {
                NotFoundException => (404, ex.Message),
                BadRequestException => (400, ex.Message),
                ConflictException => (409, ex.Message),
                _ => (500, "Došlo je do greške na serveru.")
            };

            if (status == 500) _logger.LogError(ex, "Unhandled exception");
            else _logger.LogWarning("{Message}", ex.Message);

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
        }
    }
}