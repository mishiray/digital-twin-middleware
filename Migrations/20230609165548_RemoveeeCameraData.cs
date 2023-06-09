using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class RemoveeeCameraData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_CameraSensor_CameraSensorId",
                table: "Telemetries");

            migrationBuilder.DropTable(
                name: "CameraSensor");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_CameraSensorId",
                table: "Telemetries");

            migrationBuilder.DropColumn(
                name: "CameraSensorId",
                table: "Telemetries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CameraSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CameraSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "text", nullable: true),
                    IOTDeviceId = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    IOTSensorTypes = table.Column<int[]>(type: "integer[]", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CameraSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CameraSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
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
                name: "IX_CameraSensor_IOTDeviceId",
                table: "CameraSensor",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_CameraSensor_CameraSensorId",
                table: "Telemetries",
                column: "CameraSensorId",
                principalTable: "CameraSensor",
                principalColumn: "Id");
        }
    }
}
