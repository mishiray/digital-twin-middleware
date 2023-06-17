using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using System.Reflection;

namespace DigitalTwinMiddleware.Extensions
{
    public static class TelemetryExtensions
    {
        public static string GetClassBySensor(this Telemetry telemetry, IOTSensorType iOTSensorType)
        {
            // Get the type of the object
            Type type = telemetry.GetType();

            // Get all properties of the object
            PropertyInfo[] properties = type.GetProperties();

            foreach (var propInfo in properties)
            {
                switch (propInfo.Name)
                {
                    case "DHT11Sensor":
                        DHT11Sensor _dhttemp = new DHT11Sensor();
                        _dhttemp.IOTSensorTypes.Contains(iOTSensorType);
                        return "DHT11Sensor";
                    case "GPSModule":
                        GPSModule _gpstemp = new GPSModule();
                        _gpstemp.IOTSensorTypes.Contains(iOTSensorType);
                        return "GPSModule";
                    case "UltrasonicSensor":
                        UltrasonicSensor _ultratemp = new UltrasonicSensor();
                        _ultratemp.IOTSensorTypes.Contains(iOTSensorType);
                        return "UltrasonicSensor";
                    case "CameraSensor":
                        CameraSensor _camtemp = new CameraSensor();
                        _camtemp.IOTSensorTypes.Contains(iOTSensorType);
                        return "CameraSensor";
                    case "MotionSensor":
                        MotionSensor _motiontemp = new MotionSensor();
                        _motiontemp.IOTSensorTypes.Contains(iOTSensorType);
                        return "MotionSensor";
                    case "LedSensor":
                        LedSensor _ledtemp = new LedSensor();
                        _ledtemp.IOTSensorTypes.Contains(iOTSensorType);
                        return "LedSensor";
                }

            }

            return null;
        }
    }
}
