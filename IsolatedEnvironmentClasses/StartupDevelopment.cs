using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IsolatedEnvironmentClasses
{
    public class StartupDevelopment
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Individual Startup Class for DEVELOPMENT");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Hello, World! Running in DEVELOPMENT MODE");
                });
            });
        }
    }
}
