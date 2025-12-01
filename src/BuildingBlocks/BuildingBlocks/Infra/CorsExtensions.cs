using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Infra
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddDefaultCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Default", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            return services;
        }

        public static IApplicationBuilder UseDefaultCors(this IApplicationBuilder app)
        {
            app.UseCors("Default");
            return app;
        }
    }

}
