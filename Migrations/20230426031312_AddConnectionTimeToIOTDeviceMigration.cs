using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class AddConnectionTimeToIOTDeviceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DHT11Sensor_Telemetries_TelemetryId",
                table: "DHT11Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_GPSModule_Telemetries_TelemetryId",
                table: "GPSModule");

            migrationBuilder.DropForeignKey(
                name: "FK_UltrasonicSensor_Telemetries_TelemetryId",
                table: "UltrasonicSensor");

            migrationBuilder.DropIndex(
                name: "IX_UltrasonicSensor_TelemetryId",
                table: "UltrasonicSensor");

            migrationBuilder.DropIndex(
                name: "IX_GPSModule_TelemetryId",
                table: "GPSModule");

            migrationBuilder.DropIndex(
                name: "IX_DHT11Sensor_TelemetryId",
                table: "DHT11Sensor");

            migrationBuilder.DropColumn(
                name: "TelemetryId",
                table: "UltrasonicSensor");

            migrationBuilder.DropColumn(
                name: "TelemetryId",
                table: "GPSModule");

            migrationBuilder.DropColumn(
                name: "TelemetryId",
                table: "DHT11Sensor");

            migrationBuilder.AddColumn<string>(
                name: "DHT11SensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPSModuleId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UltrasonicSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInitiatedConnection",
                table: "IOTDevices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_DHT11SensorId",
                table: "Telemetries",
                column: "DHT11SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_GPSModuleId",
                table: "Telemetries",
                column: "GPSModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_UltrasonicSensorId",
                table: "Telemetries",
                column: "UltrasonicSensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_DHT11Sensor_DHT11SensorId",
                table: "Telemetries",
                column: "DHT11SensorId",
                principalTable: "DHT11Sensor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_GPSModule_GPSModuleId",
                table: "Telemetries",
                column: "GPSModuleId",
                principalTable: "GPSModule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_UltrasonicSensor_UltrasonicSensorId",
                table: "Telemetries",
                column: "UltrasonicSensorId",
                principalTable: "UltrasonicSensor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_DHT11Sensor_DHT11SensorId",
                table: "Telemetries");

            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_GPSModule_GPSModuleId",
                table: "Telemetries");

            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_UltrasonicSensor_UltrasonicSensorId",
                table: "Telemetries");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_DHT11SensorId",
                table: "Telemetries");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_GPSModuleId",
                table: "Telemetries");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_UltrasonicSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "DHT11SensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "GPSModuleId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "UltrasonicSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "LastInitiatedConnection",
                table: "IOTDevices");

            migrationBuilder.AddColumn<string>(
                name: "TelemetryId",
                table: "UltrasonicSensor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelemetryId",
                table: "GPSModule",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelemetryId",
                table: "DHT11Sensor",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UltrasonicSensor_TelemetryId",
                table: "UltrasonicSensor",
                column: "TelemetryId");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModule_TelemetryId",
                table: "GPSModule",
                column: "TelemetryId");

            migrationBuilder.CreateIndex(
                name: "IX_DHT11Sensor_TelemetryId",
                table: "DHT11Sensor",
                column: "TelemetryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DHT11Sensor_Telemetries_TelemetryId",
                table: "DHT11Sensor",
                column: "TelemetryId",
                principalTable: "Telemetries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPSModule_Telemetries_TelemetryId",
                table: "GPSModule",
                column: "TelemetryId",
                principalTable: "Telemetries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UltrasonicSensor_Telemetries_TelemetryId",
                table: "UltrasonicSensor",
                column: "TelemetryId",
                principalTable: "Telemetries",
                principalColumn: "Id");
        }
    }
}
