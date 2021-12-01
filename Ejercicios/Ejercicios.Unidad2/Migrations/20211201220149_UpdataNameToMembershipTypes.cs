﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejercicios.Unidad2.Migrations
{
    public partial class UpdataNameToMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Pay as You Go' WHERE Id =1");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Monthly' WHERE Id =2");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Quarterly' WHERE Id =3");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Annual' WHERE Id =4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
