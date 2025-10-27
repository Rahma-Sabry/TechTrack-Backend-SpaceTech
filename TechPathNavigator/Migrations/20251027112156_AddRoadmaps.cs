using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPathNavigator.Migrations
{
    /// <inheritdoc />
    public partial class AddRoadmaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    RoadmapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.RoadmapId);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapSteps",
                columns: table => new
                {
                    RoadmapStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoadmapId = table.Column<int>(type: "int", nullable: false),
                    StepTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapSteps", x => x.RoadmapStepId);
                    table.ForeignKey(
                        name: "FK_RoadmapSteps_Roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "RoadmapId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_TrackId",
                table: "Roadmaps",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapSteps_RoadmapId",
                table: "RoadmapSteps",
                column: "RoadmapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoadmapSteps");

            migrationBuilder.DropTable(
                name: "Roadmaps");
        }
    }
}
