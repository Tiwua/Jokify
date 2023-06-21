using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class JokeEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae64ca1c-5403-4f2f-a25d-0a1249145ad3", 0, "a977125f-c272-4b65-bdd9-ee306a39b539", "someone@gmail.com", false, false, false, null, "SOMEONE@GMAIL.COM", "SOMEONE", "AQAAAAEAACcQAAAAEO654rj/WC2/TBXUNVUdTGS/K2ajHtWLxbj4p9L7cmRG84XS6l6iZMH26bt04cNQUA==", null, false, "98a6b517-628f-4666-b402-3a012e55f602", false, "someone" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cfbab976-a6d3-44c2-bdce-51c3b6b0412c", 0, "0786e880-e229-448b-9ef9-a81ae173c3ee", "admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEAaoWSCZY70UVPVclt5KpKQxUZctnLjYhCo2DqpPIsIh36lZk47LRpPZG4sCGnxqNg==", null, false, "bc75c5a4-8d5f-4b2c-8a3b-69672c0c123a", false, "admin" });
        }
    }
}
