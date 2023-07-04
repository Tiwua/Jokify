using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class JokesDataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae621c5e-e3f2-4026-9d36-7c678b707a44", "AQAAAAEAACcQAAAAEM77YRPb7Qsks+abgqnr0UyYUjGg8zD9IAu1pOvwuHy2ecms6P75ODyzQ9vd+o8iVQ==", "1ab9752a-c6d4-4dbf-8c52-3736621d265b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a7e76f-648a-4891-ba78-938aa55305ef", "AQAAAAEAACcQAAAAENRPZL31HMo2sDOEwSXYhDsRNayeLkg2P/y5cHKQEckS2Wxhurmri828Wj4c+oaqoQ==", "756a239f-35a1-4b7e-9c81-98ab4338c2ce" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ddead2d-3713-40cb-973d-5b45cc64bceb"), false, false, false, 3, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("3eab60b5-16fa-4a92-8178-4faa7eff5187"), false, false, false, 4, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("5eafbc21-db10-4ce0-ae9b-59d090a0571a"), false, false, false, 7, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("87484f13-f1f9-4c49-a117-a73280b786ec"), false, false, false, 5, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("8ebbe6a9-5aa9-4115-b73b-beae168bfea3"), false, false, false, 2, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("bdb63ebd-57c9-4c43-b628-a24ae6a165a0"), false, false, false, 1, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("bf36a12e-18e2-43d5-8ec8-10187ff4eae2"), false, false, false, 6, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("f3fdad70-1862-4f6f-943e-7fc0315b67f5"), false, false, false, 8, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("3ddead2d-3713-40cb-973d-5b45cc64bceb"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("3eab60b5-16fa-4a92-8178-4faa7eff5187"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("5eafbc21-db10-4ce0-ae9b-59d090a0571a"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("87484f13-f1f9-4c49-a117-a73280b786ec"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("8ebbe6a9-5aa9-4115-b73b-beae168bfea3"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("bdb63ebd-57c9-4c43-b628-a24ae6a165a0"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("bf36a12e-18e2-43d5-8ec8-10187ff4eae2"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("f3fdad70-1862-4f6f-943e-7fc0315b67f5"));

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
    }
}
