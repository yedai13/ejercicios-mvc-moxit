using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddVuelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVuelo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HorarioLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LineaAerea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Demora = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
