using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class UltrasonicSensorTwin
    {
        double Distance { get; set; }
        public double MinDistance { get; set; }
        public double MaxDistance { get; set; }
        double Duration { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        // Constructor
        public UltrasonicSensorTwin(double minDistance, double maxDistance, double duration)
        {
            MinDistance = minDistance;
            MaxDistance = maxDistance;
            Duration = duration;
            DeviceStatus = new DeviceStatus()
            {
                PowerStatus = PowerStatus.On,
                ConfigurationStatus = ConfigurationStatus.Misconfigured,
                OperationalStatus = OperationalStatus.Error,
                HealthStatus = HealthStatus.Critical,
                MaintenanceStatus = MaintenanceStatus.Required,
                PerformanceStatus = PerformanceStatus.LowAccuracy
            };
        }

        // Methods
        public DeviceStatus StatusCheck()
        {
            if (Duration is 0)
            {
                return new DeviceStatus()
                {
                    PowerStatus = PowerStatus.Off,
                    ConfigurationStatus = ConfigurationStatus.Misconfigured,
                    OperationalStatus = OperationalStatus.Error,
                    HealthStatus = HealthStatus.Critical,
                    MaintenanceStatus = MaintenanceStatus.Required,
                    PerformanceStatus = PerformanceStatus.Unresponsive
                };
            }
            // Calculate distance based on duration of echo
            Distance = Duration * 0.0343 / 2;

            // Check if distance is within valid range
            if (Distance >= MinDistance && Distance <= MaxDistance)
            {
                return new DeviceStatus()
                {
                    PowerStatus = PowerStatus.On,
                    ConfigurationStatus = ConfigurationStatus.Default,
                    OperationalStatus = OperationalStatus.Running,
                    HealthStatus = HealthStatus.Normal,
                    MaintenanceStatus = MaintenanceStatus.NotRequired,
                    PerformanceStatus = PerformanceStatus.HighAccuracy
                };
            }
            else
            {
                return new DeviceStatus()
                {
                    PowerStatus = PowerStatus.On,
                    ConfigurationStatus = ConfigurationStatus.Default,
                    OperationalStatus = OperationalStatus.Error,
                    HealthStatus = HealthStatus.Warning,
                    MaintenanceStatus = MaintenanceStatus.Required,
                    PerformanceStatus = PerformanceStatus.LowAccuracy
                };
            }
        }

    }
}
