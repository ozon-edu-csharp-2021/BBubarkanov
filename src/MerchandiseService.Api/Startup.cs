using MerchandiseService.Api.GrpcServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGrpcService<MerchGrpcService>();
                endpoints.MapControllers();
            });
        }
    }
}
