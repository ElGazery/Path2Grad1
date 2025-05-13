using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Students_StudentID",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_StudentID",
                table: "Tracks");

            //migrationBuilder.DropColumn(
            //    name: "Description",
            //    table: "Tracks");

            //migrationBuilder.DropColumn(
            //    name: "Link",
            //    table: "Tracks");

            //migrationBuilder.DropColumn(
            //    name: "StudentID",
            //    table: "Tracks");

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrackItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackItem_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplet = table.Column<bool>(type: "bit", nullable: true),
                    TrackItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLesson_TrackItem_TrackItemId",
                        column: x => x.TrackItemId,
                        principalTable: "TrackItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TrackId",
                table: "Students",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLesson_TrackItemId",
                table: "ItemLesson",
                column: "TrackItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackItem_TrackId",
                table: "TrackItem",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ItemLesson");

            migrationBuilder.DropTable(
                name: "TrackItem");

            migrationBuilder.DropIndex(
                name: "IX_Students_TrackId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Students");

            //migrationBuilder.AddColumn<string>(
            //    name: "Description",
            //    table: "Tracks",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Link",
            //    table: "Tracks",
            //    type: "nvarchar(255)",
            //    maxLength: 255,
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "StudentID",
            //    table: "Tracks",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_StudentID",
                table: "Tracks",
                column: "StudentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Students_StudentID",
                table: "Tracks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
