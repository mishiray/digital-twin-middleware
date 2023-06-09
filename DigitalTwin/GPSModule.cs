﻿using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class GPSModuleTwin
    {

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public GPSModuleTwin()
        {
            DeviceStatus = new DeviceStatus()
            {
                PowerStatus = DTOs.Enums.PowerStatus.On,
                ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Misconfigured,
                OperationalStatus = DTOs.Enums.OperationalStatus.Error,
                HealthStatus = DTOs.Enums.HealthStatus.Critical,
                MaintenanceStatus = DTOs.Enums.MaintenanceStatus.Required,
                PerformanceStatus = DTOs.Enums.PerformanceStatus.LowAccuracy
            };
        }

        public GPSModuleTwin(double longitude, double latitude, DeviceStatus deviceStatus)
        {
            Longitude = longitude;
            Latitude = latitude;
            DeviceStatus = deviceStatus;
        }

        public DeviceStatus StatusCheck(double longitude, double latitude)
        {
            
            // Check if within valid range
            if (longitude < 0 || latitude < 0)
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.On,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Misconfigured,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Error,
                    HealthStatus = DTOs.Enums.HealthStatus.Critical,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.Required,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.LowAccuracy
                };
            }

            this.Longitude = longitude;
            this.Latitude = latitude;

            return new DeviceStatus()
            {
                PowerStatus = DTOs.Enums.PowerStatus.On,
                ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Current,
                OperationalStatus = DTOs.Enums.OperationalStatus.Running,
                HealthStatus = DTOs.Enums.HealthStatus.Normal,
                MaintenanceStatus = DTOs.Enums.MaintenanceStatus.NotRequired,
                PerformanceStatus = DTOs.Enums.PerformanceStatus.Normal
            };
        }

    }
}
