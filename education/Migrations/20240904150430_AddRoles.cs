using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace education.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // إضافة الأدوار
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (NEWID(), 'Student', 'STUDENT')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (NEWID(), 'Teacher', 'TEACHER')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // إزالة الأدوار
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Name = 'Student'");
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Name = 'Teacher'");
        }
    }
}
