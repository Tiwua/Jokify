using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class JokeRatingRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Jokes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98d34200-820d-4e28-a775-4232ee7591e8", "AQAAAAEAACcQAAAAEFo0HJ4XehXN+e+lVrzOZ+BLr4hldHrNHf+2lbjtywp1RxvAiFZvF49Sh9JKBCVvRQ==", "5c1e2222-5b97-45a1-8c77-e936c69dc8ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ab2e83-3dd7-4b8f-a506-d666e68a85c0", "AQAAAAEAACcQAAAAEHjyhYd82KuFdtoWCMDNpJOvWQ/N6/U1YaHcjNs7Ji2XKgAUuTdqxCnrIDqRPliaPA==", "f68be2f7-e159-42a0-be47-0ff2aeb47057" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Jokes",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Rating of the joke");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2f5c8b4-f32f-4d9e-a7f8-79f3a2eb85b8", "AQAAAAEAACcQAAAAEID2cZ0uL9Pxyxoy+dbPeuqODHY0+T9coxqPYyH399aaGb8bf+rBjU0NfOeUN8O6cw==", "4c27d62c-e890-4055-ba39-46aa7caa510e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca4b6d0c-fa80-4308-9664-22521cff2392", "AQAAAAEAACcQAAAAEMwVXPQyzi1N7380Q+F3yV7DPDdR9Ykf4hP5/7DMsmNnQTcVtepPr2dr4wMBYB6VnQ==", "8ec9b559-2783-45cb-b8e9-b6e0f5ced33f" });
        }
    }
}
