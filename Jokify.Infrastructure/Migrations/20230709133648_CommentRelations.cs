using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class CommentRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JokesComments",
                table: "JokesComments");

            migrationBuilder.DropIndex(
                name: "IX_JokesComments_JokeId",
                table: "JokesComments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Jokes");

            migrationBuilder.AlterColumn<string>(
                name: "Punchline",
                table: "Jokes",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                comment: "Funniest part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Funniest part of the joke");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Jokes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Title of the joke");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of creation");

            migrationBuilder.AddColumn<Guid>(
                name: "JokeId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JokesComments",
                table: "JokesComments",
                columns: new[] { "JokeId", "CommentId" });

            migrationBuilder.CreateIndex(
                name: "IX_JokesComments_CommentId",
                table: "JokesComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_JokeId",
                table: "Comments",
                column: "JokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Jokes_JokeId",
                table: "Comments",
                column: "JokeId",
                principalTable: "Jokes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Jokes_JokeId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JokesComments",
                table: "JokesComments");

            migrationBuilder.DropIndex(
                name: "IX_JokesComments_CommentId",
                table: "JokesComments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_JokeId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "JokeId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Punchline",
                table: "Jokes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Funniest part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldComment: "Funniest part of the joke");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Jokes",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rating of the joke");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JokesComments",
                table: "JokesComments",
                columns: new[] { "CommentId", "JokeId" });

            migrationBuilder.CreateIndex(
                name: "IX_JokesComments_JokeId",
                table: "JokesComments",
                column: "JokeId");
        }
    }
}
