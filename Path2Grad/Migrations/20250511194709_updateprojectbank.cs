using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updateprojectbank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "ProjectsBank",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "Requirements",
                table: "ProjectsBank",
                newName: "ProjectSpecification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "ProjectsBank",
                newName: "AdminID");

            migrationBuilder.RenameColumn(
                name: "ProjectSpecification",
                table: "ProjectsBank",
                newName: "Requirements");
        }
    }
}
