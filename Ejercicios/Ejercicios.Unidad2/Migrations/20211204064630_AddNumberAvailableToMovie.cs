using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejercicios.Unidad2.Migrations
{
    public partial class AddNumberAvailableToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "NumberAvailable",
                table: "Movie",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.Sql("UPDATE Movie SET NumberAvailable = NumberInStock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Movie");
        }
    }
}
