using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IsolatedEnvironmentMethods
{
    /// <summary>
    /// "Configure and ConfigureServices support environment-specific versions of the form Configure<EnvironmentName> and
    /// Configure<EnvironmentName>Services. If a matching Configure<EnvironmentName>Services or Configure<EnvironmentName>
    /// method isn't found, the ConfigureServices or Configure method is used, respectively. This approach is useful
    /// when the app requires configuring startup for several environments with many code differences per environment."
    /// </summary>
    public class Startup
    {
        private string _environmentName;

        /// <summary>
        /// Development Environment ConfigureServices Method
        /// </summary>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            Console.WriteLine("Executing 'ConfigureDevelopmentServices'");
        }

        /// <summary>
        /// Default Environment ConfigureServices Method - for all other environments other than Development.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Executing 'ConfigureServices'");
        }

        /// <summary>
        /// Development Environment Configure Method
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _environmentName = "development";
            app.UseDeveloperExceptionPage();
            
            CommonConfigure(app, env);
        }

        /// <summary>
        /// Staging Environment Configure Method
        /// </summary>
        public void ConfigureStaging(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _environmentName = "staging";
            
            CommonConfigure(app, env);
        }

        /// <summary>
        /// Test Environment Configure Method
        /// </summary>
        public void ConfigureTest(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _environmentName = "test";

            CommonConfigure(app, env);
        }

        /// <summary>
        /// Production Environment Configure Method
        /// </summary>
        public void ConfigureProduction(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            _environmentName = "production";
            
            CommonConfigure(app, env);
        }

        /// <summary>
        /// Default Environment Configure Method
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _environmentName = $"unknown - {env.EnvironmentName}";

            CommonConfigure(app, env);
        }

        /// <summary>
        /// Sometimes, you'll have common code for all environments, nothing stopping you from having
        /// a 'common' method that is called from them.
        /// </summary>
        private void CommonConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Hello, World! Running in {_environmentName}");
                });
            });
        }
    }
}