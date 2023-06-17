using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class GPSModuleTwin
    {

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public GPSModuleTwin(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
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

        public DeviceStatus StatusCheck()
        {

            // Check if within valid range
            if (Longitude < 0 || Latitude < 0)
            {
                return new DeviceStatus()
                {
                    PowerStatus = PowerStatus.On,
                    ConfigurationStatus = ConfigurationStatus.Misconfigured,
                    OperationalStatus = OperationalStatus.Error,
                    HealthStatus = HealthStatus.Critical,
                    MaintenanceStatus = MaintenanceStatus.Required,
                    PerformanceStatus = PerformanceStatus.LowAccuracy
                };
            }

            return new DeviceStatus()
            {
                PowerStatus = PowerStatus.On,
                ConfigurationStatus = ConfigurationStatus.Current,
                OperationalStatus = OperationalStatus.Running,
                HealthStatus = HealthStatus.Normal,
                MaintenanceStatus = MaintenanceStatus.NotRequired,
                PerformanceStatus = PerformanceStatus.Normal
            };
        }

    }
}
