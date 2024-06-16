using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatiKopru.Migrations
{
    /// <inheritdoc />
    public partial class ThirdDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonationType",
                table: "Donations",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonationType",
                table: "Donations");
        }
    }
}
