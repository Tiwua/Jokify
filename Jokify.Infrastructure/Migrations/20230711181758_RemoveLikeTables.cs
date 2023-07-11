using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class RemoveLikeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavoritesJokes_Likes_LikeId",
                table: "UsersFavoritesJokes");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_UsersFavoritesJokes_LikeId",
                table: "UsersFavoritesJokes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeId",
                table: "UsersFavoritesJokes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign Key referencing Joke"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign Key referencing the User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoritesJokes_LikeId",
                table: "UsersFavoritesJokes",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_JokeId",
                table: "Likes",
                column: "JokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavoritesJokes_Likes_LikeId",
                table: "UsersFavoritesJokes",
                column: "LikeId",
                principalTable: "Likes",
                principalColumn: "Id");
        }
    }
}
