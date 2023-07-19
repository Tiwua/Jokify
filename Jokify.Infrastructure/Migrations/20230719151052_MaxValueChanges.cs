using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class MaxValueChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Setup",
                table: "Jokes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Introduction part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldComment: "Introduction part of the joke");

            migrationBuilder.AlterColumn<string>(
                name: "Punchline",
                table: "Jokes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Funniest part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldComment: "Funniest part of the joke");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

          }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Setup",
                table: "Jokes",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                comment: "Introduction part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Introduction part of the joke");

            migrationBuilder.AlterColumn<string>(
                name: "Punchline",
                table: "Jokes",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                comment: "Funniest part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Funniest part of the joke");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
