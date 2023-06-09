﻿// <auto-generated />
using System;
using DigitalTwinMiddleware.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DigitalTwinMiddleware.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230609161527_AddCameraData")]
    partial class AddCameraData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.CameraSensor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<byte[]>("Data")
                        .HasColumnType("bytea");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<int[]>("IOTSensorTypes")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("CameraSensor");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.DefaultLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("DefaultLogs");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.DeviceStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("ConfigurationStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HealthStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("MaintenanceStatus")
                        .HasColumnType("integer");

                    b.Property<int>("OperationalStatus")
                        .HasColumnType("integer");

                    b.Property<int>("PerformanceStatus")
                        .HasColumnType("integer");

                    b.Property<int>("PowerStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DeviceStatus");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.DHT11Sensor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<double>("Humidity")
                        .HasColumnType("double precision");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<int[]>("IOTSensorTypes")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("DHT11Sensor");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.GPSModule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<int[]>("IOTSensorTypes")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("GPSModule");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTDevice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<int>("IOTConfigType")
                        .HasColumnType("integer");

                    b.Property<int?>("IOTDeviceType")
                        .HasColumnType("integer");

                    b.Property<int?>("IOTSensorType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastInitiatedConnection")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IOTDevices");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTSubDevice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<string>("IOTSubDeviceBodyId")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("IOTDeviceId");

                    b.HasIndex("IOTSubDeviceBodyId");

                    b.ToTable("IOTSubDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTSubDeviceBody", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IOTDeviceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("IOTSubDeviceBody");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.LedSensor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<int[]>("IOTSensorTypes")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOn")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("LedSensor");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.MotionSensor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<int[]>("IOTSensorTypes")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("MotionDetected")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("MotionSensor");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.Telemetry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CameraSensorId")
                        .HasColumnType("text");

                    b.Property<string>("DHT11SensorId")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<string>("GPSModuleId")
                        .HasColumnType("text");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LedSensorId")
                        .HasColumnType("text");

                    b.Property<string>("MotionSensorId")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UltrasonicSensorId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CameraSensorId");

                    b.HasIndex("DHT11SensorId");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("GPSModuleId");

                    b.HasIndex("IOTDeviceId");

                    b.HasIndex("LedSensorId");

                    b.HasIndex("MotionSensorId");

                    b.HasIndex("UltrasonicSensorId");

                    b.ToTable("Telemetries");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.UltrasonicSensor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("DeviceStatusId")
                        .HasColumnType("text");

                    b.Property<double>("Distance")
                        .HasColumnType("double precision");

                    b.Property<double>("Duration")
                        .HasColumnType("double precision");

                    b.Property<string>("IOTDeviceId")
                        .HasColumnType("text");

                    b.Property<int[]>("IOTSensorTypes")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId");

                    b.HasIndex("IOTDeviceId");

                    b.ToTable("UltrasonicSensor");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.CameraSensor", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId");

                    b.Navigation("DeviceStatus");

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.DHT11Sensor", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId");

                    b.Navigation("DeviceStatus");

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.GPSModule", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId");

                    b.Navigation("DeviceStatus");

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTDevice", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTSubDevice", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany("IOTSubDevices")
                        .HasForeignKey("IOTDeviceId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTSubDeviceBody", "IOTSubDeviceBody")
                        .WithMany()
                        .HasForeignKey("IOTSubDeviceBodyId");

                    b.Navigation("IOTDevice");

                    b.Navigation("IOTSubDeviceBody");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTSubDeviceBody", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.LedSensor", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId");

                    b.Navigation("DeviceStatus");

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.MotionSensor", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId");

                    b.Navigation("DeviceStatus");

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.Telemetry", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.CameraSensor", "CameraSensor")
                        .WithMany()
                        .HasForeignKey("CameraSensorId");

                    b.HasOne("DigitalTwinMiddleware.Entities.DHT11Sensor", "DHT11Sensor")
                        .WithMany()
                        .HasForeignKey("DHT11SensorId");

                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.GPSModule", "GPSModule")
                        .WithMany()
                        .HasForeignKey("GPSModuleId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany("Telemetries")
                        .HasForeignKey("IOTDeviceId");

                    b.HasOne("DigitalTwinMiddleware.Entities.LedSensor", "LedSensor")
                        .WithMany()
                        .HasForeignKey("LedSensorId");

                    b.HasOne("DigitalTwinMiddleware.Entities.MotionSensor", "MotionSensor")
                        .WithMany()
                        .HasForeignKey("MotionSensorId");

                    b.HasOne("DigitalTwinMiddleware.Entities.UltrasonicSensor", "UltrasonicSensor")
                        .WithMany()
                        .HasForeignKey("UltrasonicSensorId");

                    b.Navigation("CameraSensor");

                    b.Navigation("DHT11Sensor");

                    b.Navigation("DeviceStatus");

                    b.Navigation("GPSModule");

                    b.Navigation("IOTDevice");

                    b.Navigation("LedSensor");

                    b.Navigation("MotionSensor");

                    b.Navigation("UltrasonicSensor");
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.UltrasonicSensor", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.DeviceStatus", "DeviceStatus")
                        .WithMany()
                        .HasForeignKey("DeviceStatusId");

                    b.HasOne("DigitalTwinMiddleware.Entities.IOTDevice", "IOTDevice")
                        .WithMany()
                        .HasForeignKey("IOTDeviceId");

                    b.Navigation("DeviceStatus");

                    b.Navigation("IOTDevice");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalTwinMiddleware.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DigitalTwinMiddleware.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitalTwinMiddleware.Entities.IOTDevice", b =>
                {
                    b.Navigation("IOTSubDevices");

                    b.Navigation("Telemetries");
                });
#pragma warning restore 612, 618
        }
    }
}
