using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class DbDataFill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d59fd0ee-239f-4ae6-b222-e4b7cf8010e2", "AQAAAAEAACcQAAAAECNGzmjVuYpXPMbwqsBAViBGylSSDGHoYakOPEmIMfXplPGu1d8FDB93sjdoxV3ahA==", "e7e9c781-143d-469f-a672-cf1d21176290" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2950540e-6b41-4a1a-b39b-2b22c06afbd0", "AQAAAAEAACcQAAAAENVqqIrYSf6/h12AeFEhi0tdmDc3+75jAn5F0kNtc0kGzig0tIDN5+N8aUTqdL+Idw==", "93d956d5-15a9-4781-8c61-85102989a1c8" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a3bd55a-9cff-4b07-ad86-c426d449d0a9"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("1e517099-7f88-4410-829e-82c577bc8f2a"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("26b883bc-aefc-456e-a864-3d248ece73ab"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("84f2c8d7-918d-4acc-8c84-79f5454031e9"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("953c93e4-ce19-4c41-8161-b15e5cf703f9"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("996ab34d-316b-414e-af7a-013eeeeeeeba"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("be0093d3-3910-4044-a4e4-ad24034a535a"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("ce964a8b-1b37-4b8e-8094-19f1521e52d2"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "969d8abf-b760-4471-8577-d9638ef9e4bc", "AQAAAAEAACcQAAAAELlfXK0tb/94zZ8YKDOkL3qfZ6S2Je/qn7+4MTCnTV5LrTD34f14iwMzkftpuCXLUA==", "bc4b2664-1728-487f-81c2-fc7cbbb458d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6eb9f41-d206-44bb-b0f1-d2b5c045e92d", "AQAAAAEAACcQAAAAEDz5DW0+tKmHPvw2Dvn8inozSeBYMYVd99OAP1kcJVehRt4awktPezsHhufHw5CIGA==", "bc10cb3e-486f-49af-a909-eb208ecd5ec6" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d4b7552-6d11-4939-b2ec-c5445a588366"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("21e63118-d1a6-48b3-bab1-0db7ad60cfa5"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("2d8b1467-a250-43ca-a81e-7f5968cf6595"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("2fde1421-a2ec-4043-af10-333f41ca31be"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("4eab5983-6dbb-4b4e-9c23-d7c1f016b207"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("607abed4-8cf3-4345-8652-25bf2ae8a3fb"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("6832efdf-4244-4b71-8bd7-3b84f372616a"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("6a753b11-1570-4f78-a0de-3713904acf89"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
