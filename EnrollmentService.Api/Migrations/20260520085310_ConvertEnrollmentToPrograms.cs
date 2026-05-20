using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnrollmentService.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConvertEnrollmentToPrograms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollments",
                newName: "ProgramId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Enrollments",
                newName: "CourseId");
        }
    }
}
