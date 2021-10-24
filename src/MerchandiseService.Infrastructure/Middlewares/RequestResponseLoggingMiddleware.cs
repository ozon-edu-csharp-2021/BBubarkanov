using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.ContentType == "application/grpc") {
                await _next(context);
                return;
            }
            LogRequest(context);
            await _next(context);
            LogResponse(context);
        }

        private void LogRequest(HttpContext context)
        {
            try {
                var request = context.Request;
                var logMessage = new StringBuilder();
                logMessage.AppendLine("Request Information");
                logMessage.AppendLine("Route: " + GetRoute(context));
                logMessage.AppendLine(DividingLine);
                
                logMessage.AppendLine("Headers");
                foreach (var (key, value) in request.Headers) {
                    logMessage.AppendLine(key + ": " + value);
                }
                logMessage.AppendLine(DividingLine);
                
                _logger.LogInformation(logMessage.ToString());
            }
            catch (Exception e) {
                _logger.LogError(e, "Could not log request body");
            }
        }
        
        private void LogResponse(HttpContext context)
        {
            try {
                var response = context.Response;
                var logMessage = new StringBuilder();
                logMessage.AppendLine("Response Information");
                logMessage.AppendLine("Route: " + GetRoute(context));
                logMessage.AppendLine(DividingLine);

                logMessage.AppendLine("Headers");
                foreach (var (key, value) in response.Headers) {
                    logMessage.AppendLine(key + ": " + value);
                }
                logMessage.AppendLine(DividingLine);

                _logger.LogInformation(logMessage.ToString());
            }
            catch (Exception e) {
                _logger.LogError(e, "Could not log response body");
            }
        }

        private static string DividingLine => new('-', 100);
        
        private static string GetRoute(HttpContext context) =>
            context.Request.Host + context.Request.Path + context.Request.QueryString;
    }
}
