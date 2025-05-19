using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class inti6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Projects_ProjectId",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Supervisors_ProjectId",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Supervisors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Supervisors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_ProjectId",
                table: "Supervisors",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Projects_ProjectId",
                table: "Supervisors",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectID");
        }
    }
}
