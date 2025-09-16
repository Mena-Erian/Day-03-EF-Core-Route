using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentInstructorManagerId1To1Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsMngId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsMngId",
                table: "Departments",
                column: "InsMngId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InsMngId",
                table: "Departments",
                column: "InsMngId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InsMngId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InsMngId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InsMngId",
                table: "Departments");
        }
    }
}
