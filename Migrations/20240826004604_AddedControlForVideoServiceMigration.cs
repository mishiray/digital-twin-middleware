using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class AddedControlForVideoServiceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_VideoSensorId",
                table: "Telemetries",
                column: "VideoSensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_CameraSensor_VideoSensorId",
                table: "Telemetries",
                column: "VideoSensorId",
                principalTable: "CameraSensor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_CameraSensor_VideoSensorId",
                table: "Telemetries");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_VideoSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "VideoSensorId",
                table: "Telemetries");
        }
    }
}
