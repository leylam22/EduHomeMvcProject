using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class TeacherTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    About = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hobbies = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageDegree = table.Column<int>(type: "int", nullable: false),
                    TeamLeaderDegree = table.Column<int>(type: "int", nullable: false),
                    DevelopmentDegree = table.Column<int>(type: "int", nullable: false),
                    DesignDegree = table.Column<int>(type: "int", nullable: false),
                    InnovationDegree = table.Column<int>(type: "int", nullable: false),
                    CommunicationDegree = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherDetails_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetails_TeacherId",
                table: "TeacherDetails",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherDetails");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
