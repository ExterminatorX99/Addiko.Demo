using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DB.Migrations
{
    public partial class CombineFirstLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Primatelji");

            migrationBuilder.RenameColumn(
                name: "Prezime",
                table: "Primatelji",
                newName: "ImePrezime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImePrezime",
                table: "Primatelji",
                newName: "Prezime");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Primatelji",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
