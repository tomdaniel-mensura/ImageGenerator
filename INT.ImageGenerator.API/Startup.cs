using INT.ImageGenerator.Business;
using Mensura.Tools.Api.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace INT.ImageGenerator.API
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _currentEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _currentEnvironment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opts => opts.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddBusinessLayer(_configuration);

            services.AddCoreApiComponents(_configuration, _currentEnvironment);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseCoreApiComponents(env);
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
