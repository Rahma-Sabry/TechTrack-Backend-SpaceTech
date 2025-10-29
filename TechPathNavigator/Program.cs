using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechPathNavigator.Data;
using TechPathNavigator.Repositories;
using TechPathNavigator.Services;

namespace TechPathNavigator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #region Dependency Injection
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            builder.Services.AddScoped<RoadmapService>();

            builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();
            builder.Services.AddScoped<RoadmapStepService>();

            // ✅ Keep only dev branch services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<IUserTechnologyReviewRepository, UserTechnologyReviewRepository>();
            builder.Services.AddScoped<UserTechnologyReviewService>();
            #endregion

            // Add services to the container.
            builder.Services.AddControllers();

            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TechPathNavigator API",
                    Version = "v1",
                    Description = "API for managing users and technology reviews"
                });
            });

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechPathNavigator API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
