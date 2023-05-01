using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class TelemetryDataFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "IOTDevices");

            migrationBuilder.AddColumn<string>(
                name: "IOTDeviceId",
                table: "UltrasonicSensor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IOTDeviceId",
                table: "GPSModule",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IOTDeviceId",
                table: "DHT11Sensor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IOTDeviceId",
                table: "CameraSensor",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UltrasonicSensor_IOTDeviceId",
                table: "UltrasonicSensor",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTDevices_UserId",
                table: "IOTDevices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModule_IOTDeviceId",
                table: "GPSModule",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DHT11Sensor_IOTDeviceId",
                table: "DHT11Sensor",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSensor_IOTDeviceId",
                table: "CameraSensor",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CameraSensor_IOTDevices_IOTDeviceId",
                table: "CameraSensor",
                column: "IOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DHT11Sensor_IOTDevices_IOTDeviceId",
                table: "DHT11Sensor",
                column: "IOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPSModule_IOTDevices_IOTDeviceId",
                table: "GPSModule",
                column: "IOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IOTDevices_AspNetUsers_UserId",
                table: "IOTDevices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UltrasonicSensor_IOTDevices_IOTDeviceId",
                table: "UltrasonicSensor",
                column: "IOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CameraSensor_IOTDevices_IOTDeviceId",
                table: "CameraSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_DHT11Sensor_IOTDevices_IOTDeviceId",
                table: "DHT11Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_GPSModule_IOTDevices_IOTDeviceId",
                table: "GPSModule");

            migrationBuilder.DropForeignKey(
                name: "FK_IOTDevices_AspNetUsers_UserId",
                table: "IOTDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_UltrasonicSensor_IOTDevices_IOTDeviceId",
                table: "UltrasonicSensor");

            migrationBuilder.DropIndex(
                name: "IX_UltrasonicSensor_IOTDeviceId",
                table: "UltrasonicSensor");

            migrationBuilder.DropIndex(
                name: "IX_IOTDevices_UserId",
                table: "IOTDevices");

            migrationBuilder.DropIndex(
                name: "IX_GPSModule_IOTDeviceId",
                table: "GPSModule");

            migrationBuilder.DropIndex(
                name: "IX_DHT11Sensor_IOTDeviceId",
                table: "DHT11Sensor");

            migrationBuilder.DropIndex(
                name: "IX_CameraSensor_IOTDeviceId",
                table: "CameraSensor");

            migrationBuilder.DropColumn(
                name: "IOTDeviceId",
                table: "UltrasonicSensor");

            migrationBuilder.DropColumn(
                name: "IOTDeviceId",
                table: "GPSModule");

            migrationBuilder.DropColumn(
                name: "IOTDeviceId",
                table: "DHT11Sensor");

            migrationBuilder.DropColumn(
                name: "IOTDeviceId",
                table: "CameraSensor");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "IOTDevices",
                type: "text",
                nullable: true);
        }
    }
}
