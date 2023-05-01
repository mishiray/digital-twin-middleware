using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class AddMotionSensorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MotionSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MotionSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "text", nullable: true),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    IOTSensorTypes = table.Column<int[]>(type: "integer[]", nullable: true),
                    MotionDetected = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotionSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MotionSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_MotionSensorId",
                table: "Telemetries",
                column: "MotionSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensor_DeviceStatusId",
                table: "MotionSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensor_IOTDeviceId",
                table: "MotionSensor",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_MotionSensor_MotionSensorId",
                table: "Telemetries",
                column: "MotionSensorId",
                principalTable: "MotionSensor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_MotionSensor_MotionSensorId",
                table: "Telemetries");

            migrationBuilder.DropTable(
                name: "MotionSensor");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_MotionSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "MotionSensorId",
                table: "Telemetries");
        }
    }
}
