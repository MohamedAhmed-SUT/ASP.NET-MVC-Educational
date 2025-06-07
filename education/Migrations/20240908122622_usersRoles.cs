using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace education.Migrations
{
    /// <inheritdoc />
    public partial class usersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f798b5-e9e8-4fba-a1de-74ce09d84f97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99293ada-ccab-4d79-8f4c-2408476455e8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a617078-e12e-4f10-a13e-a732f21f1faa", "2670b097-af5d-415f-9b71-0e8169f6290e", "Admin", "admin" },
                    { "c4d73cf2-fd35-4b83-a7d6-8b35178cbd73", "1e80d29c-362b-4df9-a65b-69591d949ca7", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a617078-e12e-4f10-a13e-a732f21f1faa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d73cf2-fd35-4b83-a7d6-8b35178cbd73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45f798b5-e9e8-4fba-a1de-74ce09d84f97", "81a17c9e-7f50-415a-8b7c-e85c92462585", "User", "user" },
                    { "99293ada-ccab-4d79-8f4c-2408476455e8", "448bc243-3d79-4e9f-834a-b3684ee8c24e", "Admin", "admin" }
                });
        }
    }
}
