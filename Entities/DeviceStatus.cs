using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;

namespace DigitalTwinMiddleware.Entities
{
    public class DeviceStatus : BaseEntity
    {
        public OperationalStatus OperationalStatus { get; set; }
        public PowerStatus PowerStatus { get; set; }
        public MaintenanceStatus MaintenanceStatus { get; set; }
        public PerformanceStatus PerformanceStatus { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public ConfigurationStatus ConfigurationStatus { get; set; }

        public DeviceStatus()
        {
        }

        public DeviceStatus(OperationalStatus operationalStatus, PowerStatus powerStatus,
            MaintenanceStatus maintenanceStatus, PerformanceStatus performanceStatus, HealthStatus healthStatus, ConfigurationStatus configurationStatus)
        {
            OperationalStatus = operationalStatus;
            PowerStatus = powerStatus;
            MaintenanceStatus = maintenanceStatus;
            PerformanceStatus = performanceStatus;
            HealthStatus = healthStatus;
            ConfigurationStatus = configurationStatus;
        }

        public virtual GetDeviceStatusString ToString()
        {
            return new GetDeviceStatusString()
            {
                ConfigurationStatus = ConfigurationStatus.ToString(),
                HealthStatus = HealthStatus.ToString(),
                MaintenanceStatus = MaintenanceStatus.ToString(),
                OperationalStatus = OperationalStatus.ToString(),
                PerformanceStatus = PerformanceStatus.ToString(),
                PowerStatus = PowerStatus.ToString()
            };
        }
    }
}
