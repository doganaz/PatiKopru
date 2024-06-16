using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatiKopru.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hayvanlar",
                columns: table => new
                {
                    Hayvanid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Cins = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Tur = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SahipAdi = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    SahipSoyadi = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvanlar", x => x.Hayvanid);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Adres = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Userid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hayvanlar");

            migrationBuilder.DropTable(
                name: "tblUsers");
        }
    }
}
