using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updateprojectsadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
              name: "IX_ProjectsAdmin_ProjectID",
              table: "ProjectsAdmin");
            migrationBuilder.DropForeignKey(
                name: "FK__ProjectsA__Proje__787EE5A0",
                table: "ProjectsAdmin");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "ProjectsAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
       name: "IX_ProjectsAdmin_ProjectID",
       table: "ProjectsAdmin",
       column: "ProjectID");
            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "ProjectsAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK__ProjectsA__Proje__787EE5A0",
                table: "ProjectsAdmin",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
