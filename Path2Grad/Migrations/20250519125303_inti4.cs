using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class inti4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorProject_Projects_ProjectId",
                table: "SupervisorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorProject_Supervisors_SupervisorId",
                table: "SupervisorProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupervisorProject",
                table: "SupervisorProject");

            migrationBuilder.RenameTable(
                name: "SupervisorProject",
                newName: "SupervisorProjects");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SupervisorProjects",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_SupervisorProject_SupervisorId",
                table: "SupervisorProjects",
                newName: "IX_SupervisorProjects_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_SupervisorProject_ProjectId",
                table: "SupervisorProjects",
                newName: "IX_SupervisorProjects_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupervisorProjects",
                table: "SupervisorProjects",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorProjects_Projects_ProjectId",
                table: "SupervisorProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorProjects_Supervisors_SupervisorId",
                table: "SupervisorProjects",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorProjects_Projects_ProjectId",
                table: "SupervisorProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorProjects_Supervisors_SupervisorId",
                table: "SupervisorProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupervisorProjects",
                table: "SupervisorProjects");

            migrationBuilder.RenameTable(
                name: "SupervisorProjects",
                newName: "SupervisorProject");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SupervisorProject",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SupervisorProjects_SupervisorId",
                table: "SupervisorProject",
                newName: "IX_SupervisorProject_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_SupervisorProjects_ProjectId",
                table: "SupervisorProject",
                newName: "IX_SupervisorProject_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupervisorProject",
                table: "SupervisorProject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorProject_Projects_ProjectId",
                table: "SupervisorProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorProject_Supervisors_SupervisorId",
                table: "SupervisorProject",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "SupervisorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
