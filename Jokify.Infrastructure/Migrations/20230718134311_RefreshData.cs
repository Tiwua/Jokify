using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class RefreshData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("0d3df17d-3d62-4793-a92d-dd96d5285594"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("1b5ad22a-a159-41f8-b086-57eccd1b8cca"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("22a5dc23-b974-49ff-83d7-59ca8f727d43"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("3191090c-017a-4152-9e21-b19e7564f3b0"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("617c2933-81aa-4f10-8989-062cb2fc251a"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("7eae3cff-7c9d-4311-a4ab-480b0a3c6db8"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("c116758b-e273-45a6-af76-2d1019b09635"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("e3e92ed6-3483-461c-adea-fe9c83796700"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cecf262-52f8-460a-a747-5c02bf256842", "AQAAAAEAACcQAAAAEGuz5X0Zc8csg621dykBqJWngYGmuv0jj/JvTe0iDLWeMq+S7B6+a80aS6CwgFnjFg==", "7627a689-488d-4b9e-913e-63fea805a5fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32b81120-1bb9-4adb-b781-85da0bb2656b", "AQAAAAEAACcQAAAAENP4ErFefncEL5hkVXtmf/SmU12aBQ4SRvIWypTkUBatjVImcZhGzugsghDt1nCvdg==", "2f2a6ba8-f93a-4e4e-ac2f-761b8ffdf42e" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("579a91da-b362-41aa-be6f-9397870f352f"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("76e0d6c7-d26f-4514-af26-d4c55551e2b5"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("7e79dba9-96e0-4756-af71-8f18c33cf47a"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("a1c0b73c-ed5f-46d7-8354-1a00010f48ea"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("af29d051-a136-4962-a4aa-9fa39b47b5b8"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("b13ac858-88e5-40e4-82ba-861e9b19c9f9"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("bac428c6-6d51-4605-a9db-2ce3b41c1dea"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("fae1cdfa-595e-4450-bb5d-b731f37ee99e"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("579a91da-b362-41aa-be6f-9397870f352f"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("76e0d6c7-d26f-4514-af26-d4c55551e2b5"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("7e79dba9-96e0-4756-af71-8f18c33cf47a"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("a1c0b73c-ed5f-46d7-8354-1a00010f48ea"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("af29d051-a136-4962-a4aa-9fa39b47b5b8"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("b13ac858-88e5-40e4-82ba-861e9b19c9f9"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("bac428c6-6d51-4605-a9db-2ce3b41c1dea"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("fae1cdfa-595e-4450-bb5d-b731f37ee99e"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02ba7acc-a5b1-4cce-ae26-115c3c0bd4b0", "AQAAAAEAACcQAAAAEOMdSyJK1LVJsU9IigFIQXNrp/uaymqhq9RGVyY+2tv9u4E8Yko19sus5UyEYeGpHg==", "8aa1a2c8-22c9-496f-b0e7-e8727687e1e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83ba70c7-557e-4426-9d05-5abf3a5a497f", "AQAAAAEAACcQAAAAEKf1LCNCJsRlRLalWX4GNsLpkceRlzXVE1+DphLxCUGzlPAO7/8g1cAAdmcBQAAvMw==", "99de26d0-ff82-4647-8c1d-ad7871422d96" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d3df17d-3d62-4793-a92d-dd96d5285594"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("1b5ad22a-a159-41f8-b086-57eccd1b8cca"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("22a5dc23-b974-49ff-83d7-59ca8f727d43"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("3191090c-017a-4152-9e21-b19e7564f3b0"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("617c2933-81aa-4f10-8989-062cb2fc251a"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("7eae3cff-7c9d-4311-a4ab-480b0a3c6db8"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("c116758b-e273-45a6-af76-2d1019b09635"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("e3e92ed6-3483-461c-adea-fe9c83796700"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
