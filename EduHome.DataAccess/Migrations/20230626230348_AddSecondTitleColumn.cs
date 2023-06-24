using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class AddSecondTitleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondTitle",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondTitle",
                table: "Sliders");
        }
    }
}
