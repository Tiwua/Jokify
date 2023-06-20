using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ae64ca1c-5403-4f2f-a25d-0a1249145ad3", 0, "836a3fd6-d6ff-4218-a9cf-59bc31c27789", "someone@gmail.com", false, false, false, null, "SOMEONE@GMAIL.COM", "SOMEONE", "AQAAAAEAACcQAAAAEI2rlYCu50PopkyPsw6rmYEfNDMBpfdln8aOWwc3Y5RkrLusyU30+ZoF3slXxUfJrw==", null, false, "1fd2d6f4-25e3-4227-9598-82222d817263", false, "someone" },
                    { "cfbab976-a6d3-44c2-bdce-51c3b6b0412c", 0, "9ab8ba28-85fa-41ba-8bf0-36137833db75", "admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEIAikrFPp18Nkeeef+T5DA0gJyp4T0ZH03JUwB4QLy5FEX8EYnS151jOIwNlYmAd8w==", null, false, "755dfd23-2dd8-4a50-ac41-f2564348328f", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "JokeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "One-Liner" },
                    { 2, "Pun" },
                    { 3, "Knock-knock" },
                    { 4, "Wordplay" },
                    { 5, "Riddle" },
                    { 6, "Observational" },
                    { 7, "Dad joke" },
                    { 8, "Dark humor" }
                });
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

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
