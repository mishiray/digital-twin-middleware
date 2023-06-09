using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.DigitalTwin
{
    public class MotionSensor
    {
        public bool MotionDetected { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        // Constructor
        public MotionSensor()
        {
            MotionDetected = false;
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
        public DeviceStatus UpdateMotionStatus(bool? motionDetected)
        {
            if(motionDetected is null)
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

            if(motionDetected is false)
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

            if(motionDetected is true)
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
