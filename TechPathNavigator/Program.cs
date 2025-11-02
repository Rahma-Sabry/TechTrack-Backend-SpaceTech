using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechPathNavigator.Data;
using TechPathNavigator.Repositories;
using TechPathNavigator.Services;
<<<<<<< HEAD
=======
using TechPathNavigator.Service.Track;
using TechPathNavigator.Service.Technology;
using TechPathNavigator.Common.Middleware;
>>>>>>> osama


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

            // Roadmap & Steps
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            builder.Services.AddScoped<IRoadmapService, RoadmapService>();
<<<<<<< HEAD
            builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();
            builder.Services.AddScoped<IRoadmapStepService, RoadmapStepService>();
=======
            builder.Services.AddScoped<RoadmapService>(); // For controllers that use class directly
            builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();
            builder.Services.AddScoped<IRoadmapStepService, RoadmapStepService>();
            builder.Services.AddScoped<RoadmapStepService>(); // For controllers that use class directly
>>>>>>> osama
            // User Management
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            // User Reviews
            builder.Services.AddScoped<IUserTechnologyReviewRepository, UserTechnologyReviewRepository>();
<<<<<<< HEAD
            builder.Services.AddScoped<UserTechnologyReviewService>();
            // Track & Technology
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<TrackService>();
            builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            builder.Services.AddScoped<TechnologyService>();
=======
            builder.Services.AddScoped<IUserTechnologyReviewService, UserTechnologyReviewService>();
            // Track & Technology
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<ITrackService, TrackService>();
            builder.Services.AddScoped<TrackService>(); // For controllers that use class directly
            builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            builder.Services.AddScoped<ITechnologyService, TechnologyService>();
            builder.Services.AddScoped<TechnologyService>(); // For controllers that use class directly
>>>>>>> osama

            // Category & Subcategory
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

<<<<<<< HEAD
            //Interview Questions
            builder.Services.AddScoped<IInterviewQuestionRepository, InterviewQuestionRepository>();
            builder.Services.AddScoped<InterviewQuestionService>();
=======
            // Company & Company Technology
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<ICompanyTechnologyRepository, CompanyTechnologyRepository>();
            builder.Services.AddScoped<ICompanyTechnologyService, CompanyTechnologyService>();

            //Interview Questions
            builder.Services.AddScoped<IInterviewQuestionRepository, InterviewQuestionRepository>();
            builder.Services.AddScoped<IInterviewQuestionService, InterviewQuestionService>();

            // 🌍 CORS setup
            builder.Services.ConfigureCors();
>>>>>>> osama

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

<<<<<<< HEAD
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

=======
>>>>>>> osama
            var app = builder.Build();

            // 🧭 Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechPathNavigator API V1");
                c.RoutePrefix = string.Empty;
            });

            // 🔐 Middlewares
<<<<<<< HEAD
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll");

            // 🚀 Map Controllers
            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                SeedData.Initialize(scope.ServiceProvider);
            }
=======
            app.UseGlobalExceptionHandler();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCorsMiddleware();

            // 🚀 Map Controllers
            app.MapControllers();

>>>>>>> osama
            app.Run();
        }
    }
}
