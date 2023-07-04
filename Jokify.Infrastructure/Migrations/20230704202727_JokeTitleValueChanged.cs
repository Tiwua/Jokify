using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class JokeTitleValueChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Jokes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Title of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Title of the joke");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf57123f-a554-491d-ab14-d31226cd8e23", "AQAAAAEAACcQAAAAEK+trPWBsIoQjYD6M+5EWR3tRGtOBQo6RT69bMgggMSdxhULHOZrZGRWYEpjREROMg==", "6efa84d8-a59c-425c-aeaf-921dc9f57a51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26c860cf-7c84-4f9c-83ad-ad0e668b51eb", "AQAAAAEAACcQAAAAEPFjfCXTKSWYX2ZPIOTSxA9y7As1IG6vu9Pb6IRzkUcgmk/d5704Y3x42MYrQaFDRg==", "c3ffed0c-a469-442d-aa0e-b98e152f38b5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Jokes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Title of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Title of the joke");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4c0cd1f-8e19-4f68-a9b4-471b84378b7f", "AQAAAAEAACcQAAAAEEj4ZEHvINiGAsPsSK2VgesRZIAnWa1hdqNUC0q1Xs0I7XdpigHOWso+kJUJRBHQqg==", "bb99bff8-de19-435d-8d97-48963c1e7e0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9de21f75-ba0a-40d8-a31e-fcef3a169a06", "AQAAAAEAACcQAAAAEK2c5YbMEMAZLLUUnsF9pPwroZUvkGC/YCSWPAJAeWfvtdEXt9a9JDmhaHxdpAgAIw==", "0ee7d1e5-446e-4351-9baf-e514117dfe11" });
        }
    }
}
