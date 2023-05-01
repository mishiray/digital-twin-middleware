using DigitalTwinMiddleware.Interfaces;

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
        public MotionSensor MotionSensor { get; set; }

        public DeviceStatus DeviceStatus { get; set; }
    }
}
