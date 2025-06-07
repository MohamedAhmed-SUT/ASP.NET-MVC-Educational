using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace education.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b050c23a-e99d-4d3a-af4c-94c4d1689f60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e6f43c-3a88-4de5-9159-829ed61732e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "533e94b2-e36b-4fb3-af2f-ad341427ca24", "c2246370-5d36-4471-b481-bc210d1bf0af", "Admin", "ADMIN" },
                    { "a8ff8de9-7954-4dde-85b1-70ea5cfbf73b", "09f61870-33ec-45c7-b78f-776eaa6cc352", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "533e94b2-e36b-4fb3-af2f-ad341427ca24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8ff8de9-7954-4dde-85b1-70ea5cfbf73b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b050c23a-e99d-4d3a-af4c-94c4d1689f60", "6eac4249-6849-4320-9b5a-69c3d85649a9", "User", "user" },
                    { "e8e6f43c-3a88-4de5-9159-829ed61732e7", "c5853203-1b75-49ba-a82c-ae43becd0c5a", "Admin", "admin" }
                });
        }
    }
}
