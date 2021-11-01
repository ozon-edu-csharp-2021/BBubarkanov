﻿using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.Interceptors;
using MerchandiseService.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            return builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options => {
                    options.SwaggerDoc("v1", new OpenApiInfo {
                        Title = "MerchandiseService.Api", Version = "v1"
                    });
                
                    options.CustomSchemaIds(x => x.FullName);
                });
                services.AddControllers(options => {
                    options.Filters.Add<GlobalExceptionFilter>();
                });
                services.AddGrpc(options => {
                    options.Interceptors.Add<LoggingInterceptor>();
                });
            });
        }
    }
}
