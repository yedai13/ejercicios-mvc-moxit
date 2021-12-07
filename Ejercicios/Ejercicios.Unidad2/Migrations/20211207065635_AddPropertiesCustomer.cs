using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejercicios.Unidad2.Migrations
{
    public partial class AddPropertiesCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrivingLicense",
                table: "Customer",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customer",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeUser",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrivingLicense",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Customer");
        }
    }
}
