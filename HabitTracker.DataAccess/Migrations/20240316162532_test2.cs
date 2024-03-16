using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activitys",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "ActivityDate",
                value: new DateTime(2024, 3, 16, 11, 25, 31, 957, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "Activitys",
                keyColumn: "ActivityId",
                keyValue: 2,
                column: "ActivityDate",
                value: new DateTime(2024, 3, 11, 11, 25, 31, 957, DateTimeKind.Local).AddTicks(6931));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activitys",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "ActivityDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activitys",
                keyColumn: "ActivityId",
                keyValue: 2,
                column: "ActivityDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
