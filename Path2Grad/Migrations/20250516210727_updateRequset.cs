using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updateRequset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProjectJoinRequests_Projects_ProjectId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "StudentProjectJoinRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "StudentProjectJoinRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProjectJoinRequests_Projects_ProjectId",
                table: "StudentProjectJoinRequests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProjectJoinRequests_Projects_ProjectId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "StudentProjectJoinRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProjectJoinRequests_Projects_ProjectId",
                table: "StudentProjectJoinRequests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
