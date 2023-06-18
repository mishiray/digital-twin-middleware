using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class LightSensorTwin
    {
        public bool? Value { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        // Constructor
        public LightSensorTwin(bool? value)
        {
            Value = value;
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
            if (Value is null)
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

            if (Value is false)
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

            if (Value is true)
            {
                Value = true;
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
