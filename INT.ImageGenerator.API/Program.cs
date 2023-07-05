using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace INT.ImageGenerator.API
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
