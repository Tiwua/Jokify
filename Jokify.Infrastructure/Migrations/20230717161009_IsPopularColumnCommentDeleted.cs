using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class IsPopularColumnCommentDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Popular flag that shows if the comment is popular");
        }
    }
}
