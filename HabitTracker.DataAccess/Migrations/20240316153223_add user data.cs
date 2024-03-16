using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HabitTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adduserdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "gsnyder87@gmail.com", "Greg", "Snyder" },
                    { 2, "joolyj27@yahoo.com", "Julie", "Jastremski" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
