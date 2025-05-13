using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class updateProjectFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ProjectFi__Proje__74AE54BC",
                table: "ProjectField");

            migrationBuilder.DropColumn(
                name: "ProjectField",
                table: "ProjectField");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "ProjectField",
                newName: "ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "ProjectField",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectField_FieldId",
                table: "ProjectField",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectField_Fields_FieldId",
                table: "ProjectField",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectField_Projects_ProjectId",
                table: "ProjectField",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectField_Fields_FieldId",
                table: "ProjectField");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectField_Projects_ProjectId",
                table: "ProjectField");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_ProjectField_FieldId",
                table: "ProjectField");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "ProjectField");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectField",
                newName: "ProjectID");

            migrationBuilder.AddColumn<string>(
                name: "ProjectField",
                table: "ProjectField",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK__ProjectFi__Proje__74AE54BC",
                table: "ProjectField",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
