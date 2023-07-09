using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class FillDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ae64ca1c-5403-4f2f-a25d-0a1249145ad3", 0, "52989804-6104-4abd-a14f-02836dbcb956", "someone@gmail.com", false, false, false, null, "SOMEONE@GMAIL.COM", "SOMEONE", "AQAAAAEAACcQAAAAELrAr8WE3YcuxzMp357GBAupkq5QQblcGOIJ8pwfS1Qh5cdKw2z5KxDDs/I54URkGw==", null, false, "1520e827-8c02-483b-93aa-b999036973f8", false, "someone" },
                    { "cfbab976-a6d3-44c2-bdce-51c3b6b0412c", 0, "8ec2af8b-3220-4b99-a760-e283e863b20c", "admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEN5hoVZT/EFggLb9P3ytXALRMALXn5oD1rP8kqOXKiniVjkEjLHgdkZk1vYjMj5/Pg==", null, false, "a1fc58f9-83f0-4b9a-8eca-bf20475cde7c", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "JokeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "One-Liner" },
                    { 2, "Pun" },
                    { 3, "Knock-knock" },
                    { 4, "Wordplay" },
                    { 5, "Riddle" },
                    { 6, "Observational" },
                    { 7, "Dad joke" },
                    { 8, "Dark humor" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3");

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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c");

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JokeCategories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
