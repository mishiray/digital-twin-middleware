using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Interfaces;
using System.Reflection;

namespace DigitalTwinMiddleware.Entities
{
    public class Telemetry : BaseEntity, ITelemetryData
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public DHT11Sensor DHT11Sensor { get; set; }
        public GPSModule GPSModule { get; set; }
        public UltrasonicSensor UltrasonicSensor { get; set; }
        public CameraSensor CameraSensor { get; set; }
        public CameraSensor VideoSensor { get; set; }
        public MotionSensor MotionSensor { get; set; }
        public LedSensor LedSensor { get; set; }
        public LightSensor LightSensor { get; set; }

        public DeviceStatus DeviceStatus { get; set; }
    }
}
