using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updateadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ProjectsB__Admin__7B5B524B",
                table: "ProjectsBank");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsBank_AdminID",
                table: "ProjectsBank");

         

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "ProjectsBank");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "ProjectsBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBank_AdminID",
                table: "ProjectsBank",
                column: "AdminId");

         

            migrationBuilder.AddForeignKey(
                name: "FK__ProjectsB__Admin__7B5B524B",
                table: "ProjectsBank",
                column: "AdminId",
                principalTable: "ProjectsAdmin",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
