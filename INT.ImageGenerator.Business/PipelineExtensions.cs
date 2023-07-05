using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;
using System.Reflection;
using Unsplash.Api;
using Unsplash;
using INT.ImageGenerator.Business.Managers.Interfaces;
using INT.ImageGenerator.Business.Managers;

namespace INT.ImageGenerator.Business
{
    public static class PipelineExtensions
    {
        public static IServiceCollection AddBusinessLayer(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(PipelineExtensions).GetTypeInfo().Assembly);

            // Unsplash API
            services.AddTransient<IPhotosApi>(x =>
                new UnsplashClient(new ClientOptions { AccessKey = "Get your own :)" })
                    .Photos);

            // DALL-E API
            services.AddTransient<IOpenAIAPI>(x =>
                new OpenAIAPI("NOPE :)"));

            services.AddTransient<IKittenManager, KittenManager>();
            services.AddTransient<IAIManager, AIManager>();

            return services;
        }
    }
}
