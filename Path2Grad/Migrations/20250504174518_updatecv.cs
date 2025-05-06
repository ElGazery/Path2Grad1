using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updatecv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CV_Students_StudentID",
                table: "CV");

            migrationBuilder.DropIndex(
                name: "IX_CV_StudentID",
                table: "CV");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "CV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CV_StudentID",
                table: "CV",
                column: "StudentID",
                unique: true,
                filter: "[StudentID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CV_Students_StudentID",
                table: "CV",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CV_Students_StudentID",
                table: "CV");

            migrationBuilder.DropIndex(
                name: "IX_CV_StudentID",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CV");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "CV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CV_StudentID",
                table: "CV",
                column: "StudentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CV_Students_StudentID",
                table: "CV",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
