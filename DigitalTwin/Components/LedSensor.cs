using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class LedSensorTwin
    {
        public bool? IsOn { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        // Constructor
        public LedSensorTwin(bool? isOn)
        {
            IsOn = isOn;
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
        public DeviceStatus StatusCheck()
        {
            if (IsOn is null)
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

            if (IsOn is false)
            {
                return new DeviceStatus()
                {
                    PowerStatus = DTOs.Enums.PowerStatus.On,
                    ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Default,
                    OperationalStatus = DTOs.Enums.OperationalStatus.Running,
                    HealthStatus = DTOs.Enums.HealthStatus.Normal,
                    MaintenanceStatus = DTOs.Enums.MaintenanceStatus.NotRequired,
                    PerformanceStatus = DTOs.Enums.PerformanceStatus.Normal
                };
            }

            if (IsOn is true)
            {
                IsOn = true;
            }

            return new DeviceStatus()
            {
                PowerStatus = DTOs.Enums.PowerStatus.On,
                ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Default,
                OperationalStatus = DTOs.Enums.OperationalStatus.Running,
                HealthStatus = DTOs.Enums.HealthStatus.Normal,
                MaintenanceStatus = DTOs.Enums.MaintenanceStatus.NotRequired,
                PerformanceStatus = DTOs.Enums.PerformanceStatus.Normal
            };
        }
    }
}
