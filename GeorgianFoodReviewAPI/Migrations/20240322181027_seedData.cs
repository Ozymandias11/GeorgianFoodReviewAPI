using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgianFoodReviewAPI.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"), "Meat dishes" },
                    { new Guid("9b95349a-ebd6-4eea-a56e-c761975aac3c"), "Wine" },
                    { new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a"), "Cheese" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"), "United States" },
                    { new Guid("7a803201-2cde-40ab-92d9-64f0c3293658"), "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"), "Khachapuri is a quintessential Georgian dish that has gained international acclaim for its irresistible combination of cheese-filled bread.", "Khachapuri" },
                    { new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"), "Khinkali is a traditional Georgian dumpling known for its savory filling and unique pleated shape.", "Khinkali" },
                    { new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56"), "Chakhokhbili is a traditional Georgian dish made with chicken simmered in a flavorful tomato-based sauce.", "Chakhokhbili" }
                });

            migrationBuilder.InsertData(
                table: "FoodCategory",
                columns: new[] { "CategoryId", "FoodId" },
                values: new object[,]
                {
                    { new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a"), new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72") },
                    { new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"), new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f") },
                    { new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"), new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56") }
                });

            migrationBuilder.InsertData(
                table: "Reviewevers",
                columns: new[] { "RevieweverId", "CountryId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"), new Guid("7a803201-2cde-40ab-92d9-64f0c3293658"), "Michael", "Johnson" },
                    { new Guid("707c77e5-c93f-4156-ad70-3f59a0395c48"), new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"), "Jane", "Smith" },
                    { new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"), new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"), "John", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "FoodId", "RevieweverId", "Title", "rating" },
                values: new object[] { new Guid("8886de1e-b268-48fb-8473-ecb26efc0ac2"), "Absolutely stunning", new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"), new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"), "Khachapuri description", 10.0 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "FoodId", "RevieweverId", "Title", "rating" },
                values: new object[] { new Guid("9743e067-fede-46b9-9fbc-bf74cb647c61"), "Superb", new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"), new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"), "Khinkali description", 10.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "categoryId",
                keyValue: new Guid("9b95349a-ebd6-4eea-a56e-c761975aac3c"));

            migrationBuilder.DeleteData(
                table: "FoodCategory",
                keyColumns: new[] { "CategoryId", "FoodId" },
                keyValues: new object[] { new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a"), new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72") });

            migrationBuilder.DeleteData(
                table: "FoodCategory",
                keyColumns: new[] { "CategoryId", "FoodId" },
                keyValues: new object[] { new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"), new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f") });

            migrationBuilder.DeleteData(
                table: "FoodCategory",
                keyColumns: new[] { "CategoryId", "FoodId" },
                keyValues: new object[] { new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"), new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56") });

            migrationBuilder.DeleteData(
                table: "Reviewevers",
                keyColumn: "RevieweverId",
                keyValue: new Guid("707c77e5-c93f-4156-ad70-3f59a0395c48"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("8886de1e-b268-48fb-8473-ecb26efc0ac2"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("9743e067-fede-46b9-9fbc-bf74cb647c61"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "categoryId",
                keyValue: new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "categoryId",
                keyValue: new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56"));

            migrationBuilder.DeleteData(
                table: "Reviewevers",
                keyColumn: "RevieweverId",
                keyValue: new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"));

            migrationBuilder.DeleteData(
                table: "Reviewevers",
                keyColumn: "RevieweverId",
                keyValue: new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: new Guid("7a803201-2cde-40ab-92d9-64f0c3293658"));
        }
    }
}
