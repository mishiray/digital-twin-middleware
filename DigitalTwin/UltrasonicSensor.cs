using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwinMiddleware.Entities
{
    public class UltrasonicSensorTwin
    {
        double Distance { get; set; }
        double MinDistance { get; set; }
        double MaxDistance { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        // Constructor
        public UltrasonicSensorTwin(double minDistance, double maxDistance)
        {
            MinDistance = minDistance;
            MaxDistance = maxDistance;
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

        public UltrasonicSensorTwin()
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

        // Methods
        public DeviceStatus UpdateDistance(double duration)
        {
            if(duration is 0)
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.Off,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Misconfigured,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Error,
                    HealthStatus = DTOs.Enums.HealthStatus.Critical,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.Required,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.Unresponsive
                };
            }
            // Calculate distance based on duration of echo
            Distance = duration * 0.0343 / 2;

            // Check if distance is within valid range
            if (Distance >= MinDistance && Distance <= MaxDistance)
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.On,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Default,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Running,
                    HealthStatus = DTOs.Enums.HealthStatus.Normal,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.NotRequired,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.HighAccuracy
                };
            }
            else
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.On,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Default,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Error,
                    HealthStatus = DTOs.Enums.HealthStatus.Warning,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.Required,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.LowAccuracy
                };
            }
        }

    }
}
