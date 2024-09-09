using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    public partial class UpdateDatabseMigrationForSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceOneReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceOneReaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperationalStatus = table.Column<int>(type: "int", nullable: false),
                    PowerStatus = table.Column<int>(type: "int", nullable: false),
                    MaintenanceStatus = table.Column<int>(type: "int", nullable: false),
                    PerformanceStatus = table.Column<int>(type: "int", nullable: false),
                    HealthStatus = table.Column<int>(type: "int", nullable: false),
                    ConfigurationStatus = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTwoReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTwoReaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IOTDevices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTDeviceType = table.Column<int>(type: "int", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: true),
                    IOTConfigType = table.Column<int>(type: "int", nullable: false),
                    LastInitiatedConnection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOTDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOTDevices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CameraSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DeviceRelationships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MainIOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceOneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceTwoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceOneConditionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceTwoReactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_DeviceOneReaction_DeviceOneConditionId",
                        column: x => x.DeviceOneConditionId,
                        principalTable: "DeviceOneReaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_DeviceTwoReaction_DeviceTwoReactionId",
                        column: x => x.DeviceTwoReactionId,
                        principalTable: "DeviceTwoReaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_DeviceRelationships_IOTDevices_MainIOTDeviceId",
                        column: x => x.MainIOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DHT11Sensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DHT11Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DHT11Sensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DHT11Sensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GPSModule",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPSModule_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GPSModule_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IOTSubDeviceBody",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LedSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    IsOn = table.Column<bool>(type: "bit", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LedSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LedSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LightSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<bool>(type: "bit", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MotionSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    MotionDetected = table.Column<bool>(type: "bit", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotionSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MotionSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UltrasonicSensor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    IOTSensorType = table.Column<int>(type: "int", nullable: false),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UltrasonicSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UltrasonicSensor_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UltrasonicSensor_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IOTSubDevice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IOTSubDeviceBodyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOTSubDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOTSubDevice_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IOTSubDevice_IOTSubDeviceBody_IOTSubDeviceBodyId",
                        column: x => x.IOTSubDeviceBodyId,
                        principalTable: "IOTSubDeviceBody",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Telemetries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IOTDeviceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DHT11SensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GPSModuleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UltrasonicSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CameraSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VideoSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MotionSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LedSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LightSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telemetries_CameraSensor_CameraSensorId",
                        column: x => x.CameraSensorId,
                        principalTable: "CameraSensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_CameraSensor_VideoSensorId",
                        column: x => x.VideoSensorId,
                        principalTable: "CameraSensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_DeviceStatus_DeviceStatusId",
                        column: x => x.DeviceStatusId,
                        principalTable: "DeviceStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_DHT11Sensor_DHT11SensorId",
                        column: x => x.DHT11SensorId,
                        principalTable: "DHT11Sensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_GPSModule_GPSModuleId",
                        column: x => x.GPSModuleId,
                        principalTable: "GPSModule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_IOTDevices_IOTDeviceId",
                        column: x => x.IOTDeviceId,
                        principalTable: "IOTDevices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_LedSensor_LedSensorId",
                        column: x => x.LedSensorId,
                        principalTable: "LedSensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_LightSensor_LightSensorId",
                        column: x => x.LightSensorId,
                        principalTable: "LightSensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_MotionSensor_MotionSensorId",
                        column: x => x.MotionSensorId,
                        principalTable: "MotionSensor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Telemetries_UltrasonicSensor_UltrasonicSensorId",
                        column: x => x.UltrasonicSensorId,
                        principalTable: "UltrasonicSensor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSensor_DeviceStatusId",
                table: "CameraSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSensor_IOTDeviceId",
                table: "CameraSensor",
                column: "IOTDeviceId");

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
                column: "DeviceTwoReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRelationships_MainIOTDeviceId",
                table: "DeviceRelationships",
                column: "MainIOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DHT11Sensor_DeviceStatusId",
                table: "DHT11Sensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DHT11Sensor_IOTDeviceId",
                table: "DHT11Sensor",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModule_DeviceStatusId",
                table: "GPSModule",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModule_IOTDeviceId",
                table: "GPSModule",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTDevices_UserId",
                table: "IOTDevices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTSubDevice_IOTDeviceId",
                table: "IOTSubDevice",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTSubDevice_IOTSubDeviceBodyId",
                table: "IOTSubDevice",
                column: "IOTSubDeviceBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_IOTSubDeviceBody_IOTDeviceId",
                table: "IOTSubDeviceBody",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_LedSensor_DeviceStatusId",
                table: "LedSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LedSensor_IOTDeviceId",
                table: "LedSensor",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_LightSensor_DeviceStatusId",
                table: "LightSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LightSensor_IOTDeviceId",
                table: "LightSensor",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensor_DeviceStatusId",
                table: "MotionSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensor_IOTDeviceId",
                table: "MotionSensor",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_CameraSensorId",
                table: "Telemetries",
                column: "CameraSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_DeviceStatusId",
                table: "Telemetries",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_DHT11SensorId",
                table: "Telemetries",
                column: "DHT11SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_GPSModuleId",
                table: "Telemetries",
                column: "GPSModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_IOTDeviceId",
                table: "Telemetries",
                column: "IOTDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_LedSensorId",
                table: "Telemetries",
                column: "LedSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_LightSensorId",
                table: "Telemetries",
                column: "LightSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_MotionSensorId",
                table: "Telemetries",
                column: "MotionSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_UltrasonicSensorId",
                table: "Telemetries",
                column: "UltrasonicSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetries_VideoSensorId",
                table: "Telemetries",
                column: "VideoSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_UltrasonicSensor_DeviceStatusId",
                table: "UltrasonicSensor",
                column: "DeviceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UltrasonicSensor_IOTDeviceId",
                table: "UltrasonicSensor",
                column: "IOTDeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DefaultLogs");

            migrationBuilder.DropTable(
                name: "DeviceRelationships");

            migrationBuilder.DropTable(
                name: "IOTSubDevice");

            migrationBuilder.DropTable(
                name: "Telemetries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DeviceOneReaction");

            migrationBuilder.DropTable(
                name: "DeviceTwoReaction");

            migrationBuilder.DropTable(
                name: "IOTSubDeviceBody");

            migrationBuilder.DropTable(
                name: "CameraSensor");

            migrationBuilder.DropTable(
                name: "DHT11Sensor");

            migrationBuilder.DropTable(
                name: "GPSModule");

            migrationBuilder.DropTable(
                name: "LedSensor");

            migrationBuilder.DropTable(
                name: "LightSensor");

            migrationBuilder.DropTable(
                name: "MotionSensor");

            migrationBuilder.DropTable(
                name: "UltrasonicSensor");

            migrationBuilder.DropTable(
                name: "DeviceStatus");

            migrationBuilder.DropTable(
                name: "IOTDevices");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
