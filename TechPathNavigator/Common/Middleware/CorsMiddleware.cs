using Microsoft.AspNetCore.Builder;

namespace TechPathNavigator.Common.Middleware
{
    public static class CorsMiddleware
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }

        public static void UseCorsMiddleware(this WebApplication app)
        {
            app.UseCors("AllowAll");
        }
    }
}

