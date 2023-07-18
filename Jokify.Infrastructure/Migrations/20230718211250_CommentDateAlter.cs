using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class CommentDateAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2(0)",
                nullable: false,
                comment: "Date of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of creation");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                comment: "Date of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldComment: "Date of creation");
        }
    }
}
