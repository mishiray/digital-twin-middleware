using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class DeviceRelationshipReactionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                table: "DeviceRelationships");

            migrationBuilder.DropIndex(
                name: "IX_DeviceRelationships_DeviceTwoReactionId",
                table: "DeviceRelationships");

            migrationBuilder.RenameColumn(
                name: "DeviceRelaionshipId",
                table: "DeviceReaction",
                newName: "DeviceRelationshipId");

            migrationBuilder.AddColumn<string>(
                name: "LightSensorId",
                table: "Telemetries",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceTwoReactionId",
                table: "DeviceRelationships",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LightSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "text", nullable: true),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    IOTSensorTypes = table.Column<int[]>(type: "integer[]", nullable: true),
                    Value = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LightSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_LightSensorId",
                table: "Telemetries",
                column: "LightSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceReaction_DeviceRelationshipId",
                table: "DeviceReaction",
                column: "DeviceRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_LightSensor_DeviceStatusId",
                table: "LightSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LightSensor_IOTDeviceId",
                table: "LightSensor",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceReaction_DeviceRelationships_DeviceRelationshipId",
                table: "DeviceReaction",
                column: "DeviceRelationshipId",
                principalTable: "DeviceRelationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId",
                principalTable: "DeviceReaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_LightSensor_LightSensorId",
                table: "Telemetries",
                column: "LightSensorId",
                principalTable: "LightSensor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceReaction_DeviceRelationships_DeviceRelationshipId",
                table: "DeviceReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                table: "DeviceRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_LightSensor_LightSensorId",
                table: "Telemetries");

            migrationBuilder.DropTable(
                name: "LightSensor");

            migrationBuilder.DropIndex(
                name: "IX_Telemetries_LightSensorId",
                table: "Telemetries");

            migrationBuilder.DropIndex(
                name: "IX_DeviceRelationships_DeviceTwoReactionId",
                table: "DeviceRelationships");

            migrationBuilder.DropIndex(
                name: "IX_DeviceReaction_DeviceRelationshipId",
                table: "DeviceReaction");

            migrationBuilder.DropColumn(
                name: "LightSensorId",
                table: "Telemetries");

            migrationBuilder.RenameColumn(
                name: "DeviceRelationshipId",
                table: "DeviceReaction",
                newName: "DeviceRelaionshipId");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceTwoReactionId",
                table: "DeviceRelationships",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId",
                principalTable: "DeviceReaction",
                principalColumn: "Id");
        }
    }
}
