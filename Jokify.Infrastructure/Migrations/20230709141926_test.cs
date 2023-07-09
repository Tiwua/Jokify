using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("0ba2df52-b661-46c1-b6de-e232541f221f"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("0f0dd9d1-663c-42e8-a30f-e851aea33981"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("22549909-6968-4a92-a66c-8895405ecb8d"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("30b62e44-bb9a-4b06-b3b2-da39fcffd2de"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("310300b6-b970-434d-a728-1b0607430abc"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("895741c6-4a07-4722-a0bd-58441ec638cc"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("e34bf823-a6e3-461a-92e2-6f5e54eb5bd7"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("e46b98d6-1c27-4ea2-b5ab-fda048c2c14d"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "439f9ff0-7180-4396-8f54-8f5d721d78bf", "AQAAAAEAACcQAAAAECskOJZ8wcmaHUXkVy6DdQWsALJO5v5LFYsLbTEDWLh64OKtCUNZs6c9/eth/BlcsA==", "9cb43cd0-5688-4c99-922d-c9d3c1601e0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "643f0649-20e8-4bff-b540-c848e608c3af", "AQAAAAEAACcQAAAAEA/PaGUv+KfyPtgG/w2K2Ywf7Ut8hsyDmQB+9NvICnTjESGZLSsb09OXI5cupqCHRQ==", "5a2c4214-d45b-43e5-9e45-6e6020c41625" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("12d8cc80-0c4c-4cbf-b982-a1f2859459d7"), false, false, false, 8, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("59c5356e-8527-4f7f-8b46-f392bceed076"), false, false, false, 1, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("6bffc566-992c-41dd-a9d3-cd16c5d949a3"), false, false, false, 4, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("9ead3475-c348-4055-9f75-b4fb79c251fa"), false, false, false, 3, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("ae9c80f9-f8cd-43c8-a95d-29d345fca156"), false, false, false, 2, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("bd27fbb5-6ad0-4387-b0ab-5afba0d8f8cd"), false, false, false, 7, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("bea54062-561e-4636-9c74-5a1c3d421d58"), false, false, false, 6, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("f40f813a-d22b-4b8d-8b58-8cc962ca8131"), false, false, false, 5, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("12d8cc80-0c4c-4cbf-b982-a1f2859459d7"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("59c5356e-8527-4f7f-8b46-f392bceed076"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("6bffc566-992c-41dd-a9d3-cd16c5d949a3"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("9ead3475-c348-4055-9f75-b4fb79c251fa"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("ae9c80f9-f8cd-43c8-a95d-29d345fca156"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("bd27fbb5-6ad0-4387-b0ab-5afba0d8f8cd"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("bea54062-561e-4636-9c74-5a1c3d421d58"));

            migrationBuilder.DeleteData(
                table: "Jokes",
                keyColumn: "Id",
                keyValue: new Guid("f40f813a-d22b-4b8d-8b58-8cc962ca8131"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52989804-6104-4abd-a14f-02836dbcb956", "AQAAAAEAACcQAAAAELrAr8WE3YcuxzMp357GBAupkq5QQblcGOIJ8pwfS1Qh5cdKw2z5KxDDs/I54URkGw==", "1520e827-8c02-483b-93aa-b999036973f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ec2af8b-3220-4b99-a760-e283e863b20c", "AQAAAAEAACcQAAAAEN5hoVZT/EFggLb9P3ytXALRMALXn5oD1rP8kqOXKiniVjkEjLHgdkZk1vYjMj5/Pg==", "a1fc58f9-83f0-4b9a-8eca-bf20475cde7c" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ba2df52-b661-46c1-b6de-e232541f221f"), false, false, false, 3, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("0f0dd9d1-663c-42e8-a30f-e851aea33981"), false, false, false, 6, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("22549909-6968-4a92-a66c-8895405ecb8d"), false, false, false, 4, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("30b62e44-bb9a-4b06-b3b2-da39fcffd2de"), false, false, false, 5, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("310300b6-b970-434d-a728-1b0607430abc"), false, false, false, 1, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("895741c6-4a07-4722-a0bd-58441ec638cc"), false, false, false, 2, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("e34bf823-a6e3-461a-92e2-6f5e54eb5bd7"), false, false, false, 8, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("e46b98d6-1c27-4ea2-b5ab-fda048c2c14d"), false, false, false, 7, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
