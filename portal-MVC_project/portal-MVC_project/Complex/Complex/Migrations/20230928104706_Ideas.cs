using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Complex.Migrations
{
    /// <inheritdoc />
    public partial class Ideas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Courses_CourseID",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_CourseID",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Skills",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CourseID",
                table: "Skills",
                newName: "IX_Skills_CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Materials",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_CourseID",
                table: "Materials",
                newName: "IX_Materials_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Courses_CourseId",
                table: "Skills",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_CourseId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Skills",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CourseId",
                table: "Skills",
                newName: "IX_Skills_CourseID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Materials",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                newName: "IX_Materials_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Courses_CourseID",
                table: "Materials",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Courses_CourseID",
                table: "Skills",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
