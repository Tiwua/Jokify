using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    public partial class ResetDbData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2e6fcd7-dd20-4186-92f3-6b963810b664", "AQAAAAEAACcQAAAAEKu9WSznHE7GasGqzmDuQZohjd7UpiBcsKsVYWhFWVEttSqDNV9Xgw9EOKkXrkKW/Q==", "9aab0d87-409b-4997-a486-205f66d93fbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa1a2d5b-4191-43d8-88a7-91b15d244e1b", "AQAAAAEAACcQAAAAEJr8rXmm9ybmJOToErFXVxG4kf05FJxxp99UDIwOAWjNROjNOEQahmCxaZOQSL91Mg==", "9325abf2-914f-4d39-a94e-5752a1beb59f" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1cc701b9-9fa1-45df-ab4e-772bcb8cbf77"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("4495c6d3-d0fe-48ab-8e88-b01bb30def71"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("69ef545f-5463-4c20-9f3d-ef47c36bbdda"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("7d2ae3d7-49ce-4876-ae1e-0de440d00229"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("820fa999-8195-43f1-9bcb-e2a58a8ea820"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("aa9572e8-6451-4a87-849f-a02141c8132b"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("bb978587-8dda-4ba7-8e69-eb20f25c1d1b"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("f5094e6c-724f-4a06-89c2-1d9a689a95d2"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a77a56e8-2ca3-49bc-9cde-76f11fafe06e", "AQAAAAEAACcQAAAAEJRu1GF6qPl1keHupb0ktj36FKZ/ObXQEVTN9ebKvangn/26Z2z92dLne6pgm6sk+g==", "bebc48b2-9aaa-4c3c-9332-93be2f5bd2f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11ade1d7-a27a-4250-835c-7d0df91c9524", "AQAAAAEAACcQAAAAEKMemQD9gZUlYjdO535ei5fP3X2e3Qs+WHhTLkHLjtDqUqL7NdlcJ2zJUrlRhS+KaQ==", "8406a2f8-007f-49c9-a8cd-af4fa4937f0a" });

            migrationBuilder.InsertData(
                table: "Jokes",
                columns: new[] { "Id", "IsDeleted", "IsEdited", "IsPopular", "JokeCategoryId", "LikesCount", "Punchline", "Setup", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("058bd211-a9cc-4a06-9643-f99c7b38a199"), false, false, false, 8, 0, "They don't have the guts!", "Why don't skeletons fight each other?", "Skeletons", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("0cbb7b31-84e9-4243-a2bf-b50be6e5e9e6"), false, false, false, 3, 0, "Who. \r\n Who who? \r\n What are you, an owl?", "Knock, knock.\r\n Who’s there?", "Owl", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("571a1993-9f15-4293-9cc8-eebd69180b52"), false, false, false, 5, 0, "A Carrot.", "What is orange and sounds like a parrot?", "Parrot", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("61a63654-0cf8-4115-a7a3-5be981ce8569"), false, false, false, 4, 0, "So if anyone asks, I’m outstanding.", "I'm going to stand outside.", "Outside", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("91195852-e50d-4235-adfe-65c8b663cb21"), false, false, false, 2, 0, "Because its two - tired.", "A bicycle can't stand on its own", "Bicycle", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("b2e71610-908f-467f-97f3-0db8f277c837"), false, false, false, 1, 0, "Do these genes make me look fat?", "What did the Dna say to the other DNA?", "Fat DNA?", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("c906b719-d9cb-41d1-bfd5-71204768d5b6"), false, false, false, 7, 0, "The Space Bar!", "What’s an astronaut’s favorite part of a computer?", "Favorite PC Part", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" },
                    { new Guid("d9b9aef7-155f-4755-bcb0-9791ebe6df4d"), false, false, false, 6, 0, "Because they make up everything!", "Why don't scientists trust atoms?", "Trust Issues", "cfbab976-a6d3-44c2-bdce-51c3b6b0412c" }
                });
        }
    }
}
