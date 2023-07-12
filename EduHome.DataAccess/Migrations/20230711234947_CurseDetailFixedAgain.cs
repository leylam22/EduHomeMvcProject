using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class CurseDetailFixedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assesments",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "CourseDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assesments",
                table: "CourseDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CourseDetails",
                type: "nvarchar(22)",
                maxLength: 22,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "CourseDetails",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
