using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class DataRestartSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bebe3e0-f1a2-43be-bfe1-e451010d90c4", "AQAAAAEAACcQAAAAEICd33Bnx1mZGX68xNhr4sxyLQfXI0cLDTEe3GcFrw4t+8b4sO/9DMjvAW5ARBjk+g==", "2a59db71-e567-48f0-8b81-a6d06992d181" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae0eca69-802b-43df-814d-d1e3b34447cd", "AQAAAAEAACcQAAAAEJsueFJOcAuoPY4Tjn5C3/LExLOSgF7iHAnTGC87bCBTDHM4Sku2y1yDisH+Z+/CGw==", "e27ed8e1-f0bd-4588-8edb-94530949d141" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("23fb0bc3-9f0e-4075-b845-942c0b365a2f"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("91891362-7d17-41f6-be9b-f4de9d3ed88e"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("9bc6f909-7bc6-41cd-b222-7f37b916f0c9"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("b87cd90f-acbd-43ae-82d8-570d20f4b1c2"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("cc2c8631-95ed-4f98-b49c-b7baf75b5480"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("d19f21ac-0fa0-457a-8006-f807ef390667"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("dfae1df3-9368-41f4-a7e4-f844f93421c8"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("fd808a1e-6938-4b29-b8c8-df6f22f1731a"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
