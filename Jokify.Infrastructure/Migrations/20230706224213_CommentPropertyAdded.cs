using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class CommentPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of creation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5da0b6f-87db-425b-b508-cca21282d6f0", "AQAAAAEAACcQAAAAECG1GGeb80/lw62gFYFNiMOWW/cyfvtz8nByh8nEHg8jQkH41LSDGrAhqIwEth76jw==", "1731acb9-c50c-43fa-a372-480f39091882" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b87ec4f-769b-40a7-a8db-abfdc817bb5b", "AQAAAAEAACcQAAAAEPWfnLHhOx6BZRHyDTZOW/CWtfj/T60A0V/G1fArfYfPvPzg13faUn9wPjAi319djw==", "9c2dcbae-fc5c-4876-b205-a95f24ed0e18" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f95cdc6-2c32-454e-b538-d28992243586"), false, false, false, 5, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("24d4167a-c645-43a6-ba49-6668ba6f1a26"), false, false, false, 3, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("3044806e-8b5b-4b98-8558-aeee3aa2f7ff"), false, false, false, 1, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("32196f98-b817-49ea-abe6-05980c6c618a"), false, false, false, 4, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("430875be-7fa3-4545-b967-1f7af28326f7"), false, false, false, 2, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("744668b7-1c9d-4742-beaa-f7717992d156"), false, false, false, 7, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("e531026f-e440-4553-839f-f26f08825072"), false, false, false, 6, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("eb3065a8-b0af-40c5-83ad-d8f6f404de62"), false, false, false, 8, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("1f95cdc6-2c32-454e-b538-d28992243586"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("24d4167a-c645-43a6-ba49-6668ba6f1a26"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("3044806e-8b5b-4b98-8558-aeee3aa2f7ff"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("32196f98-b817-49ea-abe6-05980c6c618a"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("430875be-7fa3-4545-b967-1f7af28326f7"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("744668b7-1c9d-4742-beaa-f7717992d156"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("e531026f-e440-4553-839f-f26f08825072"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("eb3065a8-b0af-40c5-83ad-d8f6f404de62"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comments");

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
    }
}
