using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class NewMethodDeviceRelationshipReactionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceOneConditionId",
                table: "DeviceRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                table: "DeviceRelationships");

            migrationBuilder.DropTable(
                name: "DeviceReaction");

            migrationBuilder.CreateTable(
                name: "DeviceOneReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceOneReaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTwoReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTwoReaction", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_DeviceOneReaction_DeviceOneConditionId",
                table: "DeviceRelationships",
                column: "DeviceOneConditionId",
                principalTable: "DeviceOneReaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_DeviceTwoReaction_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId",
                principalTable: "DeviceTwoReaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_DeviceOneReaction_DeviceOneConditionId",
                table: "DeviceRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceRelationships_DeviceTwoReaction_DeviceTwoReactionId",
                table: "DeviceRelationships");

            migrationBuilder.DropTable(
                name: "DeviceOneReaction");

            migrationBuilder.DropTable(
                name: "DeviceTwoReaction");

            migrationBuilder.CreateTable(
                name: "DeviceReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DeviceRelationshipId = table.Column<string>(type: "text", nullable: false),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceReaction_DeviceRelationships_DeviceRelationshipId",
                        column: x => x.DeviceRelationshipId,
                        principalTable: "DeviceRelationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceReaction_DeviceRelationshipId",
                table: "DeviceReaction",
                column: "DeviceRelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceOneConditionId",
                table: "DeviceRelationships",
                column: "DeviceOneConditionId",
                principalTable: "DeviceReaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceRelationships_DeviceReaction_DeviceTwoReactionId",
                table: "DeviceRelationships",
                column: "DeviceTwoReactionId",
                principalTable: "DeviceReaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
