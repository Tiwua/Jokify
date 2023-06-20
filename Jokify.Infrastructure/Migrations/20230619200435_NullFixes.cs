using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class NullFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "836a3fd6-d6ff-4218-a9cf-59bc31c27789", "AQAAAAEAACcQAAAAEI2rlYCu50PopkyPsw6rmYEfNDMBpfdln8aOWwc3Y5RkrLusyU30+ZoF3slXxUfJrw==", "1fd2d6f4-25e3-4227-9598-82222d817263" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ab8ba28-85fa-41ba-8bf0-36137833db75", "AQAAAAEAACcQAAAAEIAikrFPp18Nkeeef+T5DA0gJyp4T0ZH03JUwB4QLy5FEX8EYnS151jOIwNlYmAd8w==", "755dfd23-2dd8-4a50-ac41-f2564348328f" });
        }
    }
}
