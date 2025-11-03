using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text.Json;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator
{
    public static class SeedData
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.Categories.Any()) return;

            SeedCategories(context);
            SeedSubCategories(context);
            SeedTracks(context);
            SeedTechnologies(context);
            SeedCompanies(context);
            SeedCompanyTechnologies(context);
            SeedRoadmaps(context);
            SeedRoadmapSteps(context);
            SeedInterviewQuestions(context);
            SeedUsers(context);
            SeedUserTechnologyReviews(context);

            context.SaveChanges();
        }

        private static void SeedCategories(ApplicationDbContext context)
        {
            var items = LoadJsonData<Category>("Database/Data/Category.json");
            if (items?.Count > 0) context.Categories.AddRange(items);
        }

        private static void SeedSubCategories(ApplicationDbContext context)
        {
            var items = LoadJsonData<SubCategory>("Database/Data/SubCategory.json");
            if (items?.Count > 0) context.SubCategories.AddRange(items);
        }

        private static void SeedTracks(ApplicationDbContext context)
        {
            var items = LoadJsonData<Track>("Database/Data/Track.json");
            if (items?.Count > 0) context.Tracks.AddRange(items);
        }

        private static void SeedTechnologies(ApplicationDbContext context)
        {
            var items = LoadJsonData<Technology>("Database/Data/Technology.json");
            if (items?.Count > 0) context.Technologies.AddRange(items);
        }

        private static void SeedCompanies(ApplicationDbContext context)
        {
            var items = LoadJsonData<Company>("Database/Data/Company.json");
            if (items?.Count > 0) context.Companies.AddRange(items);
        }

        private static void SeedCompanyTechnologies(ApplicationDbContext context)
        {
            var items = LoadJsonData<CompanyTechnology>("Database/Data/CompanyTechnology.json");
            if (items?.Count > 0) context.CompanyTechnologies.AddRange(items);
        }

        private static void SeedRoadmaps(ApplicationDbContext context)
        {
            var items = LoadJsonData<Roadmap>("Database/Data/Roadmap.json");
            if (items?.Count > 0) context.Roadmaps.AddRange(items);
        }

        private static void SeedRoadmapSteps(ApplicationDbContext context)
        {
            var items = LoadJsonData<RoadmapStep>("Database/Data/RoadmapSteps.json");
            if (items?.Count > 0) context.RoadmapSteps.AddRange(items);
        }

        private static void SeedInterviewQuestions(ApplicationDbContext context)
        {
            var items = LoadJsonData<InterviewQuestion>("Database/Data/InterviewQuestion.json");
            if (items?.Count > 0) context.InterviewQuestions.AddRange(items);
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            var items = LoadJsonData<User>("Database/Data/User.json");
            if (items?.Count > 0) context.Users.AddRange(items);
        }

        private static void SeedUserTechnologyReviews(ApplicationDbContext context)
        {
            var items = LoadJsonData<UserTechnologyReview>("Database/Data/UserTechnologyReview.json");
            if (items?.Count > 0) context.UserTechnologyReviews.AddRange(items);
        }

        private static List<T>? LoadJsonData<T>(string relativePath)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
                if (!File.Exists(fullPath)) return null;

                var json = File.ReadAllText(fullPath);
                return JsonSerializer.Deserialize<List<T>>(json, _jsonOptions);
            }
            catch
            {
                return null;
            }
        }
    }
}