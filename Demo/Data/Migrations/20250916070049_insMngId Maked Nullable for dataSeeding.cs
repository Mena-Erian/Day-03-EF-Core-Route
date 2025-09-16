using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class insMngIdMakedNullablefordataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_InsMngId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "InsMngId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsMngId",
                table: "Departments",
                column: "InsMngId",
                unique: true,
                filter: "[InsMngId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_InsMngId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "InsMngId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsMngId",
                table: "Departments",
                column: "InsMngId",
                unique: true);
        }
    }
}
