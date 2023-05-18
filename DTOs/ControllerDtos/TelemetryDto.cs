using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.DTOs.ControllerDtos
{
    public class CreateTelemetryDto
    {
        public GetDHT11SensorDto DHT11Sensor { get; set; }
        public GetGPSModuleDto GPSModule { get; set; }
        public GetUltrasonicSensorDto UltrasonicSensor { get; set; }
        public GetMotionSensorDto MotionSensor { get; set; }
        public GetLedSensorDto LedSensor { get; set; }
        public GetCameraSensorDto CameraSensor { get; set; }
        public GetDeviceStatus DeviceStatus { get; set; }
    }

    public class GetTelemetryDto
    {
        public string Id { get; set; }
        public string IOTDeviceId { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateModified { get; set; }
        
        public GetDHT11SensorDto DHT11SensorData { get; set; }
        public GetGPSModuleDto GPSData { get; set; }
        public GetUltrasonicSensorDto UltrasonicSensorData { get; set; }
        public GetMotionSensorDto MotionSensorData { get; set; }
        public GetLedSensorDto LedSensorData { get; set; }
        public GetCameraSensorDto CameraSensor { get; set; }
        public GetDeviceStatus DeviceStatus { get; set; }
    }

    public class ExportTelemetryData
    {
        public string Id { get; set; }
        public string IOTDeviceId { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateModified { get; set; }

        public string OperationalStatus { get; set; }
        public string PowerStatus { get; set; }
        public string MaintenanceStatus { get; set; }
        public string PerformanceStatus { get; set; }
        public string HealthStatus { get; set; }
        public string ConfigurationStatus { get; set; }

        public string DHT11SensorDeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string DHT11SensorOperationalStatus { get; set; }
        public string DHT11SensorPowerStatus { get; set; }
        public string DHT11SensorMaintenanceStatus { get; set; }
        public string DHT11SensorPerformanceStatus { get; set; }
        public string DHT11SensorHealthStatus { get; set; }
        public string DHT11SensorConfigurationStatus { get; set; }


        public string GPSDeviceId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string GPSOperationalStatus { get; set; }
        public string GPSPowerStatus { get; set; }
        public string GPSMaintenanceStatus { get; set; }
        public string GPSPerformanceStatus { get; set; }
        public string GPSHealthStatus { get; set; }
        public string GPSConfigurationStatus { get; set; }


        public string UltrasonicSensorDeviceId { get; set; }
        public double Distance { get; set; }
        public string UltrasonicSensorOperationalStatus { get; set; }
        public string UltrasonicSensorPowerStatus { get; set; }
        public string UltrasonicSensorMaintenanceStatus { get; set; }
        public string UltrasonicSensorPerformanceStatus { get; set; }
        public string UltrasonicSensorHealthStatus { get; set; }
        public string UltrasonicSensorConfigurationStatus { get; set; }
    }

    public class GetDeviceStatus
    {
        public OperationalStatus OperationalStatus { get; set; }
        public PowerStatus PowerStatus { get; set; }
        public MaintenanceStatus MaintenanceStatus { get; set; }
        public PerformanceStatus PerformanceStatus { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public ConfigurationStatus ConfigurationStatus { get; set; }

        public GetDeviceStatus()
        {
        }

        public GetDeviceStatus(OperationalStatus operationalStatus, PowerStatus powerStatus, MaintenanceStatus maintenanceStatus, 
            PerformanceStatus performanceStatus, HealthStatus healthStatus, ConfigurationStatus configurationStatus)
        {
            OperationalStatus = operationalStatus;
            PowerStatus = powerStatus;
            MaintenanceStatus = maintenanceStatus;
            PerformanceStatus = performanceStatus;
            HealthStatus = healthStatus;
            ConfigurationStatus = configurationStatus;
        }
    }

}
