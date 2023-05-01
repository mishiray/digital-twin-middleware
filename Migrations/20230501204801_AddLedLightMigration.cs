using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class AddLedLightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LedSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LedSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "text", nullable: true),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    IOTSensorTypes = table.Column<int[]>(type: "integer[]", nullable: true),
                    IsOn = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LedSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LedSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_LedSensorId",
                table: "Telemetries",
                column: "LedSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_LedSensor_DeviceStatusId",
                table: "LedSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LedSensor_IOTDeviceId",
                table: "LedSensor",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_LedSensor_LedSensorId",
                table: "Telemetries",
                column: "LedSensorId",
                principalTable: "LedSensor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_LedSensor_LedSensorId",
                table: "Telemetries");

            migrationBuilder.DropTable(
                name: "LedSensor");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_LedSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "LedSensorId",
                table: "Telemetries");
        }
    }
}
