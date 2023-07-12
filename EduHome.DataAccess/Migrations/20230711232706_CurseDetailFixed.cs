using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class CurseDetailFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssesmentId",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageOptionId",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "CourseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_AssesmentId",
                table: "CourseDetails",
                column: "AssesmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_LanguageOptionId",
                table: "CourseDetails",
                column: "LanguageOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_SkillId",
                table: "CourseDetails",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetails_Assesments_AssesmentId",
                table: "CourseDetails",
                column: "AssesmentId",
                principalTable: "Assesments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetails_Languages_LanguageOptionId",
                table: "CourseDetails",
                column: "LanguageOptionId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetails_SkillLevels_SkillId",
                table: "CourseDetails",
                column: "SkillId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetails_Assesments_AssesmentId",
                table: "CourseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetails_Languages_LanguageOptionId",
                table: "CourseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetails_SkillLevels_SkillId",
                table: "CourseDetails");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetails_AssesmentId",
                table: "CourseDetails");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetails_LanguageOptionId",
                table: "CourseDetails");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetails_SkillId",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "AssesmentId",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "LanguageOptionId",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "CourseDetails");
        }
    }
}
