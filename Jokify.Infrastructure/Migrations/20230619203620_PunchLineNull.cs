using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class PunchLineNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Punchline",
                table: "Jokes",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                comment: "Funniest part of the joke",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Funniest part of the joke");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed8b90b4-1a95-4848-b329-0e7fbbd7fbcc", "AQAAAAEAACcQAAAAEPPewqW15dqjWrNwuThk+mz244yg/F27Nq3VAfb/IeVdS5pE7qM9hBLnEku2RcWLnA==", "344d8896-ddf5-45e2-8e8b-ccc4c4bdd683" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb66c0bd-5e94-47b2-8031-48b94a4c00f0", "AQAAAAEAACcQAAAAEFe//zRsSIJj7h1c9+D6YML+o1S9HcMj4Tqe739XoPeu15f0C042Zact2hzdLhnfeg==", "ab546148-7d6a-43a7-89ac-016510bd499a" });
        }
    }
}
