using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatiKopru.Migrations
{
    /// <inheritdoc />
    public partial class SeventhDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SahipAdi",
                table: "Hayvanlar");

            migrationBuilder.DropColumn(
                name: "SahipSoyadi",
                table: "Hayvanlar");

            migrationBuilder.AddColumn<int>(
                name: "SahipId",
                table: "Hayvanlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_SahipId",
                table: "Hayvanlar",
                column: "SahipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hayvanlar_tblUsers_SahipId",
                table: "Hayvanlar",
                column: "SahipId",
                principalTable: "tblUsers",
                principalColumn: "Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hayvanlar_tblUsers_SahipId",
                table: "Hayvanlar");

            migrationBuilder.DropIndex(
                name: "IX_Hayvanlar_SahipId",
                table: "Hayvanlar");

            migrationBuilder.DropColumn(
                name: "SahipId",
                table: "Hayvanlar");

            migrationBuilder.AddColumn<string>(
                name: "SahipAdi",
                table: "Hayvanlar",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SahipSoyadi",
                table: "Hayvanlar",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
