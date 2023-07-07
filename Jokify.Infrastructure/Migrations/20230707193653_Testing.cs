using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class Testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("645f4ee4-caf4-46de-bf7e-83ae77dfd745"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("73a3e779-9849-4a31-a175-6ef73ad7430d"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("9def542e-a1a6-42b7-89ca-60c246428af7"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("b7e348ce-32dd-4981-ac1b-3aa02e9e322e"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("d1cd1753-1f43-451a-9284-a0cd8dd2065d"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("db2bb755-1b80-4275-8846-b3dad659806a"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("fb9b6073-589b-4d03-bd6e-27bfbd5d33f9"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("ffa72e27-b697-4786-933c-d82051be99f3"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08e0403a-7edf-4e12-8d70-9647cd9d7582", "AQAAAAEAACcQAAAAENVwsfuHA3VjlHa4VY0VIHmuE/B8DlVJ0Qxky7sQxeO9YTkKcLbE263B9b+3d2Q9zg==", "34fa2c0d-1228-48cc-866b-99c52d043e50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "550140a4-4941-48b2-b0a5-c32627acba33", "AQAAAAEAACcQAAAAEAnkNw7s1YuqT661kgNorN6i9eJ6KXCKnAmCefrJNN2ykwXbcvKb/Xo0Y8pqikiHSQ==", "e562db52-82b0-4cc1-90a7-f65865402e1b" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("020d1e23-1832-4a94-ba00-c3342ad8dca0"), false, false, false, 1, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("2790eb00-987c-474b-b730-040fab7f7355"), false, false, false, 2, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("48f74a33-4a5f-4bfe-84d0-f57fdffc42f6"), false, false, false, 6, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("4cc5721b-c600-43c6-bc4d-1d380e20d0f3"), false, false, false, 7, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("5df2d72f-2b16-4c29-8a8c-5a2b935ca818"), false, false, false, 5, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("7641c4f1-55d7-408d-a019-e5d11b4f8b09"), false, false, false, 8, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("b0bf6b1d-0fce-4f35-b4d6-da147563d505"), false, false, false, 3, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("e059cc43-098b-4e3f-96be-46c06633dccd"), false, false, false, 4, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("020d1e23-1832-4a94-ba00-c3342ad8dca0"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("2790eb00-987c-474b-b730-040fab7f7355"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("48f74a33-4a5f-4bfe-84d0-f57fdffc42f6"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("4cc5721b-c600-43c6-bc4d-1d380e20d0f3"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("5df2d72f-2b16-4c29-8a8c-5a2b935ca818"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("7641c4f1-55d7-408d-a019-e5d11b4f8b09"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("b0bf6b1d-0fce-4f35-b4d6-da147563d505"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("e059cc43-098b-4e3f-96be-46c06633dccd"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0bbb764-61b9-409d-9ae9-7f9ff841ce14", "AQAAAAEAACcQAAAAELhOGl7iUHL/2moVXcDp8DEuh+VVQ4OyroHcPXtZSwEIYWNWd7uZGjvz/8njCUuszQ==", "6976ca3e-b8c9-40b1-b0f0-7844faa7b862" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2496887-caaf-4bf8-95b7-32dbdd30b168", "AQAAAAEAACcQAAAAEBXaADzedG+uCVA51eDBGU3K8CZ9hRpmNtgKVcMmrpiWkTk+yp8nWDOuDWisM54XIw==", "5bcb41a8-c5db-40a8-b8dd-99ae2a738335" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("645f4ee4-caf4-46de-bf7e-83ae77dfd745"), false, false, false, 6, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("73a3e779-9849-4a31-a175-6ef73ad7430d"), false, false, false, 7, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("9def542e-a1a6-42b7-89ca-60c246428af7"), false, false, false, 5, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("b7e348ce-32dd-4981-ac1b-3aa02e9e322e"), false, false, false, 1, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("d1cd1753-1f43-451a-9284-a0cd8dd2065d"), false, false, false, 8, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("db2bb755-1b80-4275-8846-b3dad659806a"), false, false, false, 3, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("fb9b6073-589b-4d03-bd6e-27bfbd5d33f9"), false, false, false, 4, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("ffa72e27-b697-4786-933c-d82051be99f3"), false, false, false, 2, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
