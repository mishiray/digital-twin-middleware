using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class CameraSensorTwin
    {

        public string Data { get; set; }
        public bool? IsPoweredOn { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        public CameraSensorTwin(bool? isPoweredOn, string data)
        {
            IsPoweredOn = isPoweredOn;
            Data = data;
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
            if (IsPoweredOn is null)
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.Off,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Misconfigured,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Error,
                    HealthStatus = DTOs.Enums.HealthStatus.Critical,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.Required,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.LowAccuracy
                };
            }

            if (IsPoweredOn is false)
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.Off,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Default,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Offline,
                    HealthStatus = DTOs.Enums.HealthStatus.Offline,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.Required,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.Unresponsive
                };
            }

            // Check if within valid range
            if (IsPoweredOn is true && Data == null)
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
