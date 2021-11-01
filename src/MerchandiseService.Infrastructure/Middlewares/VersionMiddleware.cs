using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate _) { }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetEntryAssembly()?.GetName().Name ?? "no service";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new {
                version,
                serviceName
            }));
        }
    }
}
