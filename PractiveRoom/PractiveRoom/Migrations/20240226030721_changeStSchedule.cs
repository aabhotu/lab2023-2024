using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PractiveRoom.Migrations
{
    /// <inheritdoc />
    public partial class changeStSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSchedule_schedule_scheduleId",
                table: "StudentSchedule");

            migrationBuilder.DropColumn(
                name: "calenderId",
                table: "StudentSchedule");

            migrationBuilder.AlterColumn<int>(
                name: "scheduleId",
                table: "StudentSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSchedule_schedule_scheduleId",
                table: "StudentSchedule",
                column: "scheduleId",
                principalTable: "schedule",
                principalColumn: "scheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSchedule_schedule_scheduleId",
                table: "StudentSchedule");

            migrationBuilder.AlterColumn<int>(
                name: "scheduleId",
                table: "StudentSchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "calenderId",
                table: "StudentSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSchedule_schedule_scheduleId",
                table: "StudentSchedule",
                column: "scheduleId",
                principalTable: "schedule",
                principalColumn: "scheduleId");
        }
    }
}
