using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Delete flag that shows if the comment has been deleted"),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, comment: "Edit flag that shows if the comment has been edited"),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false, comment: "Popular flag that shows if the comment is popular")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                },
                comment: "Joke comment");

            migrationBuilder.CreateTable(
                name: "JokeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JokeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jokes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary Key"),
                    Setup = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Introduction part of the joke"),
                    Punchline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Funniest part of the joke"),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: false, comment: "Rating of the joke"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Delete flag that shows if the joke has been deleted"),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, comment: "Edit flag that shows if the joke has been edited"),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false, comment: "Popular flag that shows if the joke is popular"),
                    JokeCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Foreign Key referencing JokeCategory"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign Key referencing User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jokes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jokes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jokes_JokeCategories_JokeCategoryId",
                        column: x => x.JokeCategoryId,
                        principalTable: "JokeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Joke for the WebApp");

            migrationBuilder.CreateTable(
                name: "JokesComments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key refering comment of the joke"),
                    JokeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key refering the joke")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JokesComments", x => new { x.CommentId, x.JokeId });
                    table.ForeignKey(
                        name: "FK_JokesComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JokesComments_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersFavoritesJokes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary key refering user's favorite joke"),
                    JokeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key refering the joke")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFavoritesJokes", x => new { x.UserId, x.JokeId });
                    table.ForeignKey(
                        name: "FK_UsersFavoritesJokes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersFavoritesJokes_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersJokes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary key refering user's created joke"),
                    JokeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key refering the joke")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersJokes", x => new { x.UserId, x.JokeId });
                    table.ForeignKey(
                        name: "FK_UsersJokes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersJokes_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jokes_JokeCategoryId",
                table: "Jokes",
                column: "JokeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jokes_UserId",
                table: "Jokes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JokesComments_JokeId",
                table: "JokesComments",
                column: "JokeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoritesJokes_JokeId",
                table: "UsersFavoritesJokes",
                column: "JokeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersJokes_JokeId",
                table: "UsersJokes",
                column: "JokeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JokesComments");

            migrationBuilder.DropTable(
                name: "UsersFavoritesJokes");

            migrationBuilder.DropTable(
                name: "UsersJokes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Jokes");

            migrationBuilder.DropTable(
                name: "JokeCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
