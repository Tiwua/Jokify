using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class JokeTitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Jokes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Title of the joke");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae64ca1c-5403-4f2f-a25d-0a1249145ad3", 0, "a4c0cd1f-8e19-4f68-a9b4-471b84378b7f", "someone@gmail.com", false, false, false, null, "SOMEONE@GMAIL.COM", "SOMEONE", "AQAAAAEAACcQAAAAEEj4ZEHvINiGAsPsSK2VgesRZIAnWa1hdqNUC0q1Xs0I7XdpigHOWso+kJUJRBHQqg==", null, false, "bb99bff8-de19-435d-8d97-48963c1e7e0e", false, "someone" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cfbab976-a6d3-44c2-bdce-51c3b6b0412c", 0, "9de21f75-ba0a-40d8-a31e-fcef3a169a06", "admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEK2c5YbMEMAZLLUUnsF9pPwroZUvkGC/YCSWPAJAeWfvtdEXt9a9JDmhaHxdpAgAIw==", null, false, "0ee7d1e5-446e-4351-9baf-e514117dfe11", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Jokes");
        }
    }
}
