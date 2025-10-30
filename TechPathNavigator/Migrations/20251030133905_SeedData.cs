using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechPathNavigator.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Backend Development", "Server-side programming" },
                    { 2, "Frontend Development", "Client-side development" },
                    { 3, "Mobile Development", "Building mobile applications" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "Description", "Industry", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, "Microsoft", "Software and cloud company", "Technology", "https://microsoft.com" },
                    { 2, "Google", "Search and AI company", "Technology", "https://google.com" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "UserName" },
                values: new object[] { 1, "admin@example.com", "CHANGE_ME_HASH", "admin" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryId", "CategoryId", "Description", "DifficultyLevel", "EstimatedDuration", "SubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Learn backend with .NET", "Intermediate", 120, "C# & .NET" },
                    { 2, 1, "JavaScript backend development", "Intermediate", 100, "Node.js" },
                    { 3, 2, "Frontend with React", "Beginner", 90, "React" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "Description", "DifficultyLevel", "EstimatedDuration", "SubCategoryId", "TrackName" },
                values: new object[,]
                {
                    { 1, "RESTful APIs with .NET", "Intermediate", 150, 1, "ASP.NET Web API" },
                    { 2, "Server-side Node.js development", "Intermediate", 120, 2, "Express.js Backend" },
                    { 3, "Frontend development with React", "Beginner", 80, 3, "React Basics" }
                });

            migrationBuilder.InsertData(
                table: "Roadmaps",
                columns: new[] { "RoadmapId", "Description", "TechnologyId", "Title", "TrackId" },
                values: new object[] { 1, "Steps to become backend developer", null, "Backend Developer Roadmap", 1 });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "CreatedAt", "Description", "TechnologyName", "TrackId", "VideoUrl" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(8540), "Language for .NET backend", "C#", 1, null },
                    { 2, new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(9120), "ORM for .NET", "Entity Framework Core", 1, null },
                    { 3, new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(9120), "JavaScript runtime", "Node.js", 2, null },
                    { 4, new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(9120), "Frontend library", "React", 3, null }
                });

            migrationBuilder.InsertData(
                table: "CompanyTechnologies",
                columns: new[] { "CompanyTechnologyId", "CompanyId", "Notes", "TechnologyId", "UsageLevel" },
                values: new object[,]
                {
                    { 1, 1, "Used heavily in backend systems", 1, "primary" },
                    { 2, 2, "Used for scalable services", 3, "primary" }
                });

            migrationBuilder.InsertData(
                table: "InterviewQuestions",
                columns: new[] { "QuestionId", "DifficultyLevel", "QuestionText", "QuestionType", "SampleAnswer", "TechnologyId" },
                values: new object[,]
                {
                    { 1, "Intermediate", "Explain the difference between value and reference types in C#.", "Technical", "Value types store data directly; reference types store references.", 1 },
                    { 2, "Intermediate", "What is the event loop in Node.js?", "Technical", "It manages asynchronous operations in Node.js runtime.", 3 }
                });

            migrationBuilder.InsertData(
                table: "RoadmapSteps",
                columns: new[] { "RoadmapStepId", "RoadmapId", "StepDescription", "StepOrder", "StepTitle" },
                values: new object[,]
                {
                    { 1, 1, "Understand syntax and OOP", 1, "Learn C# Basics" },
                    { 2, 1, "Build REST APIs", 2, "Learn ASP.NET Web API" }
                });

            migrationBuilder.InsertData(
                table: "UserTechnologyReviews",
                columns: new[] { "ReviewId", "Rating", "ReviewText", "TechnologyId", "UserId" },
                values: new object[] { 1, 5, "Excellent technology for backend.", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CompanyTechnologies",
                keyColumn: "CompanyTechnologyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompanyTechnologies",
                keyColumn: "CompanyTechnologyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InterviewQuestions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InterviewQuestions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoadmapSteps",
                keyColumn: "RoadmapStepId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoadmapSteps",
                keyColumn: "RoadmapStepId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserTechnologyReviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roadmaps",
                keyColumn: "RoadmapId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
