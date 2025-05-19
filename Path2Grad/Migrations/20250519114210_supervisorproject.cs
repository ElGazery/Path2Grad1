using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class supervisorproject : Migration
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

            migrationBuilder.CreateTable(
                name: "SupervisorProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupervisorProject_Supervisors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisors",
                        principalColumn: "SupervisorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorProject_ProjectId",
                table: "SupervisorProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorProject_SupervisorId",
                table: "SupervisorProject",
                column: "SupervisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupervisorProject");

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
