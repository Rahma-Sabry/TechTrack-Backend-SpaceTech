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

            // 💾 Database Connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #region Dependency Injection (DEV ONLY)
            // 🧭 Roadmap & Steps
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            builder.Services.AddScoped<RoadmapService>();

            builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();
            builder.Services.AddScoped<RoadmapStepService>();

            // 👤 User Management
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();

            // ⭐ User Reviews
            builder.Services.AddScoped<IUserTechnologyReviewRepository, UserTechnologyReviewRepository>();
            builder.Services.AddScoped<UserTechnologyReviewService>();

            // 🧱 Track & Technology (NEW)
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<TrackService>();

            builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            builder.Services.AddScoped<TechnologyService>();
            #endregion

            // 🧩 Controllers
            builder.Services.AddControllers();

            // 🌐 Swagger/OpenAPI setup
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TechPathNavigator API",
                    Version = "v1",
                    Description = "API for managing technologies, tracks, users, and roadmaps"
                });
            });

            // 🌍 CORS setup
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

            // 🧭 Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechPathNavigator API V1");
                c.RoutePrefix = string.Empty;
            });

            // 🔐 Middlewares
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll");

            // 🚀 Map Controllers
            app.MapControllers();

            app.Run();
        }
    }
}
