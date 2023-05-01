using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class AddDeviceStatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceStatusId",
                table: "UltrasonicSensor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceStatusId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceStatusId",
                table: "GPSModule",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceStatusId",
                table: "DHT11Sensor",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OperationalStatus = table.Column<int>(type: "integer", nullable: false),
                    PowerStatus = table.Column<int>(type: "integer", nullable: false),
                    MaintenanceStatus = table.Column<int>(type: "integer", nullable: false),
                    PerformanceStatus = table.Column<int>(type: "integer", nullable: false),
                    HealthStatus = table.Column<int>(type: "integer", nullable: false),
                    ConfigurationStatus = table.Column<int>(type: "integer", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UltrasonicSensor_DeviceStatusId",
                table: "UltrasonicSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_DeviceStatusId",
                table: "Telemetries",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModule_DeviceStatusId",
                table: "GPSModule",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DHT11Sensor_DeviceStatusId",
                table: "DHT11Sensor",
                column: "DeviceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DHT11Sensor_DeviceStatus_DeviceStatusId",
                table: "DHT11Sensor",
                column: "DeviceStatusId",
                principalTable: "DeviceStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPSModule_DeviceStatus_DeviceStatusId",
                table: "GPSModule",
                column: "DeviceStatusId",
                principalTable: "DeviceStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_DeviceStatus_DeviceStatusId",
                table: "Telemetries",
                column: "DeviceStatusId",
                principalTable: "DeviceStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UltrasonicSensor_DeviceStatus_DeviceStatusId",
                table: "UltrasonicSensor",
                column: "DeviceStatusId",
                principalTable: "DeviceStatus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DHT11Sensor_DeviceStatus_DeviceStatusId",
                table: "DHT11Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_GPSModule_DeviceStatus_DeviceStatusId",
                table: "GPSModule");

            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_DeviceStatus_DeviceStatusId",
                table: "Telemetries");

            migrationBuilder.DropForeignKey(
                name: "FK_UltrasonicSensor_DeviceStatus_DeviceStatusId",
                table: "UltrasonicSensor");

            migrationBuilder.DropTable(
                name: "DeviceStatus");

            migrationBuilder.DropIndex(
                name: "IX_UltrasonicSensor_DeviceStatusId",
                table: "UltrasonicSensor");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_DeviceStatusId",
                table: "Telemetries");

            migrationBuilder.DropIndex(
                name: "IX_GPSModule_DeviceStatusId",
                table: "GPSModule");

            migrationBuilder.DropIndex(
                name: "IX_DHT11Sensor_DeviceStatusId",
                table: "DHT11Sensor");

            migrationBuilder.DropColumn(
                name: "DeviceStatusId",
                table: "UltrasonicSensor");

            migrationBuilder.DropColumn(
                name: "DeviceStatusId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "DeviceStatusId",
                table: "GPSModule");

            migrationBuilder.DropColumn(
                name: "DeviceStatusId",
                table: "DHT11Sensor");
        }
    }
}
