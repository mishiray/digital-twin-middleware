using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.DigitalTwin
{
    public class TelemetryReport 
    {
        public DateTime Timestamp { get; set; }
        //public List<TwinReport> Reports { get; set; }
        public TwinReport DHT11SensorData { get; set; }
        public TwinReport GPSData { get; set; }
        public TwinReport UltrasonicSensorData { get; set; }
        public TwinReport MotionSensorData { get; set; }
        public TwinReport LedSensorData { get; set; }
        public TwinReport LightSensorData { get; set; }
        public TwinReport CameraSensor { get; set; }
    }

    public class TwinReport
    {
        public string DeviceName { get; set; }
        public GetDeviceStatusString DeviceStatus { get; set; }

        public List<ReactTwinReport> Reactions { get; set; }
    }

    public class ReactTwinReport
    {
        public string DeviceName { get; set; }
        public bool WorkingProperly { get; set; }
        public List<string> Errors { get; set; }
    }
}
