using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "HiringDate", "InsMngId", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 70, new DateOnly(2025, 9, 16), null, 0, "Digital" },
                    { 80, new DateOnly(2025, 9, 16), null, 0, "Marketing" },
                    { 90, new DateOnly(2025, 9, 16), null, 0, "Salles" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 90);
        }
    }
}
