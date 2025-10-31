using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TechPathNavigator.BLL.Validations.Category;
using TechPathNavigator.DAL.Repositories.Generic;
using TechPathNavigator.DAL.Data;
using TechPathNavigator.Repositories;
using TechPathNavigator.Services;

namespace TechPathNavigator.Configurations
{
    /// <summary>
    /// Centralized dependency injection configuration
    /// Separates DI setup from Program.cs for better maintainability
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers all application services and dependencies
        /// </summary>
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Database Configuration
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TechPathNavigator")));

            // Generic Repository Pattern
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Specific Repositories
            RegisterRepositories(services);

            // Business Services
            RegisterServices(services);

            // AutoMapper Configuration
            services.AddAutoMapper(typeof(Program).Assembly);

            // FluentValidation Configuration
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CategoryPostDtoValidator>();

            return services;
        }

        /// <summary>
        /// Registers all repository implementations
        /// </summary>
        private static void RegisterRepositories(IServiceCollection services)
        {
            // Category & SubCategory
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

            // Track & Technology
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();

            // Roadmap & Steps
            services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();

            // Company & CompanyTechnology
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyTechnologyRepository, CompanyTechnologyRepository>();

            // Interview Questions
            services.AddScoped<IInterviewQuestionRepository, InterviewQuestionRepository>();

            // User & Reviews
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTechnologyReviewRepository, UserTechnologyReviewRepository>();
        }

        /// <summary>
        /// Registers all service implementations
        /// </summary>
        private static void RegisterServices(IServiceCollection services)
        {
            // Category & SubCategory Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();

            // Track & Technology Services
            services.AddScoped<TrackService>();
            services.AddScoped<TechnologyService>();

            // Roadmap Services
            services.AddScoped<IRoadmapService, RoadmapService>();
            services.AddScoped<IRoadmapStepService, RoadmapStepService>();

            // Company Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyTechnologyService, CompanyTechnologyService>();

            // Interview Question Services
            services.AddScoped<IInterviewQuestionService, InterviewQuestionService>();

            // User Services
            services.AddScoped<UserService>();
            services.AddScoped<IUserTechnologyReviewService, UserTechnologyReviewService>();
        }
    }
}
