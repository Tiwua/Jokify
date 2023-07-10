using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class LikesCountPropAddedToJoke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Jokes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Likes of the joke");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Jokes");
        }
    }
}
