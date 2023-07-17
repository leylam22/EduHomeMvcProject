using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class AddEventSpeakersToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventsDetails_EventId",
                table: "EventsDetails");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDetails_EventId",
                table: "EventsDetails",
                column: "EventId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventsDetails_EventId",
                table: "EventsDetails");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDetails_EventId",
                table: "EventsDetails",
                column: "EventId");
        }
    }
}
