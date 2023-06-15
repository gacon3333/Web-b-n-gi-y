using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register IHttpContextAccessor
        services.AddHttpContextAccessor();

        // Other service registrations
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configuration code
    }
}
