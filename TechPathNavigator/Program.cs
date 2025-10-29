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
            #region 
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            builder.Services.AddScoped<RoadmapService>();
            
            builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();
            builder.Services.AddScoped<RoadmapStepService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<CategoryService>();

            builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            builder.Services.AddScoped<SubCategoryService>();
            #endregion



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // ✅ Register Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TechPathNavigator API",
                    Version = "v1",
                    Description = "API for managing categories and subcategories"
                });
            });
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

            // Enable Swagger UI (remove Dev-only guard so it runs when you want to test)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechPathNavigator API V1");
                c.RoutePrefix = string.Empty; // 👈 important to open at root
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
