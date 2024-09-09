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
                        if (_dhttemp.IOTSensorType == (iOTSensorType))
                        {
                            return "DHT11Sensor";
                        };
                        break;
                    case "GPSModule":
                        GPSModule _gpstemp = new GPSModule();
                        if (_gpstemp.IOTSensorType == (iOTSensorType))
                        {
                            return "GPSModule";
                        }
                        break;
                    case "UltrasonicSensor":
                        UltrasonicSensor _ultratemp = new UltrasonicSensor();
                        if (_ultratemp.IOTSensorType == (iOTSensorType))
                        {
                            return "UltrasonicSensor";
                        }
                        break;
                    case "CameraSensor":
                        CameraSensor _camtemp = new CameraSensor();
                        if (_camtemp.IOTSensorType == (iOTSensorType))
                        {
                            return "CameraSensor";
                        }
                        break;
                    case "MotionSensor":
                        MotionSensor _motiontemp = new MotionSensor();
                        if (_motiontemp.IOTSensorType == (iOTSensorType))
                        {
                            return "MotionSensor";
                        }
                        break;
                    case "LedSensor":
                        LedSensor _ledtemp = new LedSensor();
                        if (_ledtemp.IOTSensorType == (iOTSensorType))
                        {
                            return "LedSensor";
                        }
                        break;
                    case "LightSensor":
                        LightSensor _lighttemp = new LightSensor();
                        if (_lighttemp.IOTSensorType == (iOTSensorType))
                        {
                            return "LightSensor";
                        }
                        break;
                }

            }

            return null;
        }
    }
}
