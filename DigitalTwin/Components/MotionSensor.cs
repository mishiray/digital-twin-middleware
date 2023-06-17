using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class MotionSensorTwin
    {
        public bool? MotionDetected { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        // Constructor
        public MotionSensorTwin(bool? motionDetected)
        {
            MotionDetected = motionDetected;
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
            if (MotionDetected is null)
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

            if (MotionDetected is false)
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

            if (MotionDetected is true)
            {
                MotionDetected = true;
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
