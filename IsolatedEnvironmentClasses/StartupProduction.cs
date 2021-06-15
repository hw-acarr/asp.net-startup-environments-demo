using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IsolatedEnvironmentClasses
{
    public class StartupProduction
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Keep it secret, keep it safe");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Hello, World!");
                });
            });
        }
    }
}
