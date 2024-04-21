using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03b4027c-d3ab-454a-bfe3-0e038a55fcf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50f446af-6a6c-422b-93d9-520d5d7b5b4e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9937cb35-4a71-4b26-95d9-385fa208c03b", null, "Admin", "ADMIN" },
                    { "d8819e18-b9c0-4412-852f-2f455a11236b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9937cb35-4a71-4b26-95d9-385fa208c03b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8819e18-b9c0-4412-852f-2f455a11236b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03b4027c-d3ab-454a-bfe3-0e038a55fcf5", null, "Admin", "ADMIN" },
                    { "50f446af-6a6c-422b-93d9-520d5d7b5b4e", null, "User", "USER" }
                });
        }
    }
}
