using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class ForgottenUserColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsForgotten",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForgotten",
                table: "AspNetUsers");
        }
    }
}
