using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class IOTDeviceSubFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOTSubDevice_IOTDevices_IOTDeviceId",
                table: "IOTSubDevice");

            migrationBuilder.AlterColumn<string>(
                name: "IOTDeviceId",
                table: "IOTSubDevice",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "IOTSubDeviceBodyId",
                table: "IOTSubDevice",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IOTSubDeviceBody",
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
                    table.PrimaryKey("PK_IOTSubDeviceBody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOTSubDeviceBody_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IOTSubDevice_IOTSubDeviceBodyId",
                table: "IOTSubDevice",
                column: "IOTSubDeviceBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTSubDeviceBody_IOTDeviceId",
                table: "IOTSubDeviceBody",
                column: "IOTDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_IOTSubDevice_IOTDevices_IOTDeviceId",
                table: "IOTSubDevice",
                column: "IOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IOTSubDevice_IOTSubDeviceBody_IOTSubDeviceBodyId",
                table: "IOTSubDevice",
                column: "IOTSubDeviceBodyId",
                principalTable: "IOTSubDeviceBody",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOTSubDevice_IOTDevices_IOTDeviceId",
                table: "IOTSubDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_IOTSubDevice_IOTSubDeviceBody_IOTSubDeviceBodyId",
                table: "IOTSubDevice");

            migrationBuilder.DropTable(
                name: "IOTSubDeviceBody");

            migrationBuilder.DropIndex(
                name: "IX_IOTSubDevice_IOTSubDeviceBodyId",
                table: "IOTSubDevice");

            migrationBuilder.DropColumn(
                name: "IOTSubDeviceBodyId",
                table: "IOTSubDevice");

            migrationBuilder.AlterColumn<string>(
                name: "IOTDeviceId",
                table: "IOTSubDevice",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IOTSubDevice_IOTDevices_IOTDeviceId",
                table: "IOTSubDevice",
                column: "IOTDeviceId",
                principalTable: "IOTDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
