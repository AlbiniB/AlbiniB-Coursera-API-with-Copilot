using System.Text.Json;

namespace UserManagementApi.Middleware;

public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private const string ValidToken = "your-secret-token";

    public TokenAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLower();
        if (path != null && path.StartsWith("/users"))
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Missing or invalid Authorization header." }));
                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            if (token != ValidToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Unauthorized access." }));
                return;
            }
        }

        await _next(context);
    }
}