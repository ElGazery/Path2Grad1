using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updateRequest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_StudentId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "StudentProjectJoinRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProjectJoinRequests_SenderId",
                table: "StudentProjectJoinRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProjectJoinRequests_StudentId1",
                table: "StudentProjectJoinRequests",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_SenderId",
                table: "StudentProjectJoinRequests",
                column: "SenderId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_StudentId",
                table: "StudentProjectJoinRequests",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_StudentId1",
                table: "StudentProjectJoinRequests",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_SenderId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_StudentId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_StudentId1",
                table: "StudentProjectJoinRequests");

            migrationBuilder.DropIndex(
                name: "IX_StudentProjectJoinRequests_SenderId",
                table: "StudentProjectJoinRequests");

            migrationBuilder.DropIndex(
                name: "IX_StudentProjectJoinRequests_StudentId1",
                table: "StudentProjectJoinRequests");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentProjectJoinRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProjectJoinRequests_Students_StudentId",
                table: "StudentProjectJoinRequests",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
