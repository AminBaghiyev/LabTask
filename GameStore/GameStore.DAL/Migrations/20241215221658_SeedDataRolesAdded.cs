using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataRolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eeebb659-a56c-461e-8b2e-97cbc1f8c8ed", null, "Admin", "ADMIN" },
                    { "f8f8cb95-f680-4af2-abf8-0554d253695f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeebb659-a56c-461e-8b2e-97cbc1f8c8ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8f8cb95-f680-4af2-abf8-0554d253695f");
        }
    }
}
