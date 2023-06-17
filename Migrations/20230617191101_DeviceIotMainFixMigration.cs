using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class DeviceIotMainFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainIOTDeviceId",
                table: "DeviceRelationships",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_MainIOTDeviceId",
                table: "DeviceRelationships",
                column: "MainIOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_IOTDevices_MainIOTDeviceId",
                table: "DeviceRelationships",
                column: "MainIOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_IOTDevices_MainIOTDeviceId",
                table: "DeviceRelationships");

            migrationBuilder.DropIndex(
                name: "IX_DeviceRelationships_MainIOTDeviceId",
                table: "DeviceRelationships");

            migrationBuilder.DropColumn(
                name: "MainIOTDeviceId",
                table: "DeviceRelationships");
        }
    }
}
