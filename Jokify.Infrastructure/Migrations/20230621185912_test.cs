using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a977125f-c272-4b65-bdd9-ee306a39b539", "AQAAAAEAACcQAAAAEO654rj/WC2/TBXUNVUdTGS/K2ajHtWLxbj4p9L7cmRG84XS6l6iZMH26bt04cNQUA==", "98a6b517-628f-4666-b402-3a012e55f602" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0786e880-e229-448b-9ef9-a81ae173c3ee", "AQAAAAEAACcQAAAAEAaoWSCZY70UVPVclt5KpKQxUZctnLjYhCo2DqpPIsIh36lZk47LRpPZG4sCGnxqNg==", "bc75c5a4-8d5f-4b2c-8a3b-69672c0c123a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
