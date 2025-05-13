using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Path2Grad.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackID");
        }
    }
}
