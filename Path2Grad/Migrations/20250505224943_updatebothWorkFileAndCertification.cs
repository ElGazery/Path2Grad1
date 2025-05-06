using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updatebothWorkFileAndCertification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Internshi__Inter__5535A963",
                table: "InternshipCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK__Internshi__Inter__52593CB8",
                table: "InternshipWorkFiles");

            migrationBuilder.AlterColumn<int>(
                name: "InternshipID",
                table: "InternshipWorkFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InternshipID",
                table: "InternshipCertificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK__Internshi__Inter__5535A963",
                table: "InternshipCertificates",
                column: "InternshipID",
                principalTable: "Internships",
                principalColumn: "InternshipID");

            migrationBuilder.AddForeignKey(
                name: "FK__Internshi__Inter__52593CB8",
                table: "InternshipWorkFiles",
                column: "InternshipID",
                principalTable: "Internships",
                principalColumn: "InternshipID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Internshi__Inter__5535A963",
                table: "InternshipCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK__Internshi__Inter__52593CB8",
                table: "InternshipWorkFiles");

            migrationBuilder.AlterColumn<int>(
                name: "InternshipID",
                table: "InternshipWorkFiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InternshipID",
                table: "InternshipCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Internshi__Inter__5535A963",
                table: "InternshipCertificates",
                column: "InternshipID",
                principalTable: "Internships",
                principalColumn: "InternshipID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Internshi__Inter__52593CB8",
                table: "InternshipWorkFiles",
                column: "InternshipID",
                principalTable: "Internships",
                principalColumn: "InternshipID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
