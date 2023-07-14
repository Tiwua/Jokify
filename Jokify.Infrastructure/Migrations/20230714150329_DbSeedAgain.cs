using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class DbSeedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f803314c-65d0-4eca-b7bd-9cd45c133aa2", "AQAAAAEAACcQAAAAEGREYfOHchf7w/TurMH6DD9pYzmxbhdVYWJiEI8Nppfz2uLYkJynxaPiRR67GuadQA==", "388c3d49-6151-406c-b922-c461670e78bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb292e67-5863-4e49-bcdf-77cf25cb5a0a", "AQAAAAEAACcQAAAAEFXilZzon3hkm9JqjIKnN9IgBFGHI8RtW7A0iZvAlcG79ZlX44AVAfREBkKCiPfs1g==", "0b49b519-9900-413d-8750-47f4f8d2e00e" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0423bf40-cecd-4a48-8477-732cad376035"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("0fc38d8f-57dc-48d5-aa7a-903006d8b5f3"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("15de6b2b-a9fc-433f-8a75-a971a989ab69"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("1a544538-d2b7-4db9-b2e4-a9a29a788ec7"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("243ba82b-7b1c-47f1-a4de-e21fe3ffcc87"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("96c26e52-7ccf-4411-a9b9-743f508f64a2"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("a86ff06f-1391-41c5-ba9f-421bb99d6b7f"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("e3ef35aa-768a-4cb3-82f7-a03361491c1f"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1f74c69-60a3-4f5c-b201-0f41b63a7b6d", "AQAAAAEAACcQAAAAEImLPf79mjUmo7FDaOtskda+Y64kGpasod0clk+LJzAkkYBXYAwp1hrWFMwAYaFyNA==", "b8c1f2b2-5e1c-494c-9d26-924a4aee2ed0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cfee77c-4440-43fd-b0a2-6457a280daa4", "AQAAAAEAACcQAAAAEMI/L/oYLcsaZvgJdIdW/cAZhOdUhdneFW101JqZFCoCNCMVygzB5J0gpAw5UbfuAQ==", "b1236076-5cef-48d2-9804-8771e83f1f10" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("2df3bc59-a3d0-4e34-a4b5-e8c43772be87"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("575d4d44-9f1d-463c-ad8c-b45e681d8381"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("60e1b00c-1be2-4209-adc8-e3d341053c49"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("86a51b82-528f-4354-8849-2ca9f5d4d55b"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("9a31b573-a5b3-450f-97ff-1f2503491d2c"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("abbde552-3afc-4dec-8b52-f18eec662583"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("cdf7c0ab-a48a-440f-842f-4d0c5f9f4e51"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("dffc3c28-7396-4594-9f6e-9190357cc4b8"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
