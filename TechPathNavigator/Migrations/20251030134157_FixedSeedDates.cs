using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPathNavigator.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 13, 39, 4, 972, DateTimeKind.Utc).AddTicks(9120));
        }
    }
}
