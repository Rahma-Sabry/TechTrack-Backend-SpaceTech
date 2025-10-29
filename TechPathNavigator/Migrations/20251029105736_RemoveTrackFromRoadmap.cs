using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPathNavigator.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrackFromRoadmap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TechnologyId",
                table: "Roadmaps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_TechnologyId",
                table: "Roadmaps",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roadmaps_Technologies_TechnologyId",
                table: "Roadmaps",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roadmaps_Technologies_TechnologyId",
                table: "Roadmaps");

            migrationBuilder.DropIndex(
                name: "IX_Roadmaps_TechnologyId",
                table: "Roadmaps");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Roadmaps");
        }
    }
}
