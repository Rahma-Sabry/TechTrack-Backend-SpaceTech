using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Models;

namespace TechPathNavigator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapStep> RoadmapSteps { get; set; }
        public DbSet<InterviewQuestion> InterviewQuestions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyTechnology> CompanyTechnologies { get; set; }
        public DbSet<UserTechnologyReview> UserTechnologyReviews { get; set; }
        public DbSet<User> Users { get; set; } // if you added User


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubCategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.SubCategory)
                .WithMany(s => s.Tracks)
                .HasForeignKey(t => t.SubCategoryId);

            modelBuilder.Entity<Technology>()
                .HasOne(t => t.Track)
                .WithMany(tr => tr.Technologies)
                .HasForeignKey(t => t.TrackId);

            // Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Backend Development", Description = "Server-side programming" },
                new Category { CategoryId = 2, CategoryName = "Frontend Development", Description = "Client-side development" },
                new Category { CategoryId = 3, CategoryName = "Mobile Development", Description = "Building mobile applications" }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { SubCategoryId = 1, CategoryId = 1, SubCategoryName = "C# & .NET", Description = "Learn backend with .NET", DifficultyLevel = "Intermediate", EstimatedDuration = 120 },
                new SubCategory { SubCategoryId = 2, CategoryId = 1, SubCategoryName = "Node.js", Description = "JavaScript backend development", DifficultyLevel = "Intermediate", EstimatedDuration = 100 },
                new SubCategory { SubCategoryId = 3, CategoryId = 2, SubCategoryName = "React", Description = "Frontend with React", DifficultyLevel = "Beginner", EstimatedDuration = 90 }
            );

            modelBuilder.Entity<Track>().HasData(
                new Track { TrackId = 1, SubCategoryId = 1, TrackName = "ASP.NET Web API", Description = "RESTful APIs with .NET", DifficultyLevel = "Intermediate", EstimatedDuration = 150 },
                new Track { TrackId = 2, SubCategoryId = 2, TrackName = "Express.js Backend", Description = "Server-side Node.js development", DifficultyLevel = "Intermediate", EstimatedDuration = 120 },
                new Track { TrackId = 3, SubCategoryId = 3, TrackName = "React Basics", Description = "Frontend development with React", DifficultyLevel = "Beginner", EstimatedDuration = 80 }
            );

            modelBuilder.Entity<Technology>().HasData(
                new Technology { TechnologyId = 1, TrackId = 1, TechnologyName = "C#", Description = "Language for .NET backend", CreatedAt = new DateTime(2025, 01, 01) },
                new Technology { TechnologyId = 2, TrackId = 1, TechnologyName = "Entity Framework Core", Description = "ORM for .NET", CreatedAt = new DateTime(2025, 01, 01) },
                new Technology { TechnologyId = 3, TrackId = 2, TechnologyName = "Node.js", Description = "JavaScript runtime", CreatedAt = new DateTime(2025, 01, 01) },
                new Technology { TechnologyId = 4, TrackId = 3, TechnologyName = "React", Description = "Frontend library", CreatedAt = new DateTime(2025, 01, 01) }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "Microsoft", Industry = "Technology", WebsiteUrl = "https://microsoft.com", Description = "Software and cloud company" },
                new Company { CompanyId = 2, CompanyName = "Google", Industry = "Technology", WebsiteUrl = "https://google.com", Description = "Search and AI company" }
            );

            modelBuilder.Entity<CompanyTechnology>().HasData(
                new CompanyTechnology { CompanyTechnologyId = 1, CompanyId = 1, TechnologyId = 1, UsageLevel = "primary", Notes = "Used heavily in backend systems" },
                new CompanyTechnology { CompanyTechnologyId = 2, CompanyId = 2, TechnologyId = 3, UsageLevel = "primary", Notes = "Used for scalable services" }
            );

            modelBuilder.Entity<Roadmap>().HasData(
                new Roadmap { RoadmapId = 1, TrackId = 1, Title = "Backend Developer Roadmap", Description = "Steps to become backend developer" }
            );

            modelBuilder.Entity<RoadmapStep>().HasData(
                new RoadmapStep { RoadmapStepId = 1, RoadmapId = 1, StepTitle = "Learn C# Basics", StepDescription = "Understand syntax and OOP", StepOrder = 1 },
                new RoadmapStep { RoadmapStepId = 2, RoadmapId = 1, StepTitle = "Learn ASP.NET Web API", StepDescription = "Build REST APIs", StepOrder = 2 }
            );

            modelBuilder.Entity<InterviewQuestion>().HasData(
                new InterviewQuestion { QuestionId = 1, TechnologyId = 1, QuestionText = "Explain the difference between value and reference types in C#.", DifficultyLevel = "Intermediate", QuestionType = "Technical", SampleAnswer = "Value types store data directly; reference types store references." },
                new InterviewQuestion { QuestionId = 2, TechnologyId = 3, QuestionText = "What is the event loop in Node.js?", DifficultyLevel = "Intermediate", QuestionType = "Technical", SampleAnswer = "It manages asynchronous operations in Node.js runtime." }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "admin", Email = "admin@example.com", PasswordHash = "CHANGE_ME_HASH" }
            );

            modelBuilder.Entity<UserTechnologyReview>().HasData(
                new UserTechnologyReview { ReviewId = 1, UserId = 1, TechnologyId = 1, Rating = 5, ReviewText = "Excellent technology for backend." }
            );

        }
    }
}
