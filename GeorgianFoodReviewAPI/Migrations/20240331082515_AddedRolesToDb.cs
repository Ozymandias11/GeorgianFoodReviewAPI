using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgianFoodReviewAPI.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2112ef06-4f21-444e-b7d5-3552bfde505d", "5ddfb67d-d5d4-4c6b-a998-4168a6c7a5b0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32da7acc-9637-4488-adeb-d58224a994fc", "71d62882-f26d-41fb-a2fd-00abb1541585", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2112ef06-4f21-444e-b7d5-3552bfde505d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32da7acc-9637-4488-adeb-d58224a994fc");
        }
    }
}
