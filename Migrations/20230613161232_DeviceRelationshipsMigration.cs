using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class DeviceRelationshipsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DeviceRelaionshipId = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceReaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceRelationships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DeviceOneId = table.Column<string>(type: "text", nullable: false),
                    DeviceTwoId = table.Column<string>(type: "text", nullable: true),
                    DeviceOneConditionId = table.Column<string>(type: "text", nullable: false),
                    DeviceTwoReactionId = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_DeviceReaction_DeviceOneConditionId",
                        column: x => x.DeviceOneConditionId,
                        principalTable: "DeviceReaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                        column: x => x.DeviceTwoReactionId,
                        principalTable: "DeviceReaction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_IOTDevices_DeviceOneId",
                        column: x => x.DeviceOneId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_IOTDevices_DeviceTwoId",
                        column: x => x.DeviceTwoId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_DeviceOneConditionId",
                table: "DeviceRelationships",
                column: "DeviceOneConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_DeviceOneId",
                table: "DeviceRelationships",
                column: "DeviceOneId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_DeviceTwoId",
                table: "DeviceRelationships",
                column: "DeviceTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceRelationships");

            migrationBuilder.DropTable(
                name: "DeviceReaction");
        }
    }
}
