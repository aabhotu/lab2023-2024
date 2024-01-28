using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PractiveRoom.Migrations
{
    /// <inheritdoc />
    public partial class upSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSchedule_schedule_Scheduleid",
                table: "StudentSchedule");

            migrationBuilder.RenameColumn(
                name: "Scheduleid",
                table: "StudentSchedule",
                newName: "scheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSchedule_Scheduleid",
                table: "StudentSchedule",
                newName: "IX_StudentSchedule_scheduleId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "schedule",
                newName: "scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSchedule_schedule_scheduleId",
                table: "StudentSchedule",
                column: "scheduleId",
                principalTable: "schedule",
                principalColumn: "scheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSchedule_schedule_scheduleId",
                table: "StudentSchedule");

            migrationBuilder.RenameColumn(
                name: "scheduleId",
                table: "StudentSchedule",
                newName: "Scheduleid");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSchedule_scheduleId",
                table: "StudentSchedule",
                newName: "IX_StudentSchedule_Scheduleid");

            migrationBuilder.RenameColumn(
                name: "scheduleId",
                table: "schedule",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSchedule_schedule_Scheduleid",
                table: "StudentSchedule",
                column: "Scheduleid",
                principalTable: "schedule",
                principalColumn: "id");
        }
    }
}
