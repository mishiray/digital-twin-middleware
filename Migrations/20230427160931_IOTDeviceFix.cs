using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class IOTDeviceFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IOTType",
                table: "IOTDevices",
                newName: "IOTConfigType");

            migrationBuilder.AddColumn<int[]>(
                name: "IOTSensorTypes",
                table: "UltrasonicSensor",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CameraSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "IOTDevices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IOTDeviceType",
                table: "IOTDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IOTSensorType",
                table: "IOTDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "IOTSensorTypes",
                table: "GPSModule",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "IOTSensorTypes",
                table: "DHT11Sensor",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CameraSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    IOTSensorTypes = table.Column<int[]>(type: "integer[]", nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true),
                    DeviceStatusId = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CameraSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IOTSubDevice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOTSubDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOTSubDevice_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_CameraSensorId",
                table: "Telemetries",
                column: "CameraSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSensor_DeviceStatusId",
                table: "CameraSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTSubDevice_IOTDeviceId",
                table: "IOTSubDevice",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_CameraSensor_CameraSensorId",
                table: "Telemetries",
                column: "CameraSensorId",
                principalTable: "CameraSensor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_CameraSensor_CameraSensorId",
                table: "Telemetries");

            migrationBuilder.DropTable(
                name: "CameraSensor");

            migrationBuilder.DropTable(
                name: "IOTSubDevice");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_CameraSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "IOTSensorTypes",
                table: "UltrasonicSensor");

            migrationBuilder.DropColumn(
                name: "CameraSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "IOTDevices");

            migrationBuilder.DropColumn(
                name: "IOTDeviceType",
                table: "IOTDevices");

            migrationBuilder.DropColumn(
                name: "IOTSensorType",
                table: "IOTDevices");

            migrationBuilder.DropColumn(
                name: "IOTSensorTypes",
                table: "GPSModule");

            migrationBuilder.DropColumn(
                name: "IOTSensorTypes",
                table: "DHT11Sensor");

            migrationBuilder.RenameColumn(
                name: "IOTConfigType",
                table: "IOTDevices",
                newName: "IOTType");
        }
    }
}
