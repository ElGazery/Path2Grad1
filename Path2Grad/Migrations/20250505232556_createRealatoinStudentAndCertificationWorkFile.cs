using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class createRealatoinStudentAndCertificationWorkFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "InternshipWorkFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "InternshipCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InternshipWorkFiles_StudentId",
                table: "InternshipWorkFiles",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipCertificates_StudentId",
                table: "InternshipCertificates",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternshipCertificates_Students_StudentId",
                table: "InternshipCertificates",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternshipWorkFiles_Students_StudentId",
                table: "InternshipWorkFiles",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternshipCertificates_Students_StudentId",
                table: "InternshipCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_InternshipWorkFiles_Students_StudentId",
                table: "InternshipWorkFiles");

            migrationBuilder.DropIndex(
                name: "IX_InternshipWorkFiles_StudentId",
                table: "InternshipWorkFiles");

            migrationBuilder.DropIndex(
                name: "IX_InternshipCertificates_StudentId",
                table: "InternshipCertificates");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "InternshipWorkFiles");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "InternshipCertificates");
        }
    }
}
