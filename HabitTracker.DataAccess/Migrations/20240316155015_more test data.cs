using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HabitTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class moretestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activitys",
                columns: new[] { "ActivityId", "HabitId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activitys",
                keyColumn: "ActivityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activitys",
                keyColumn: "ActivityId",
                keyValue: 2);
        }
    }
}
