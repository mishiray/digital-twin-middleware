using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Interfaces;
using DigitalTwinMiddleware.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwinMiddleware.Entities
{
    public class DHT11SensorTwin
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }
        public List<IOTSensorType> IOTSensorTypes { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        double MinTemperature { get; set; }
        double MaxTemperature { get; set; }
        double MinHumidity { get; set; }
        double MaxHumidity { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public DHT11SensorTwin()
        {
        }

        public DHT11SensorTwin(string iOTDeviceId, string deviceId, double minTemperature, double maxTemperature,
            double minHumidity, double maxHumidity, DeviceStatus deviceStatus)
        {
            IOTDeviceId = iOTDeviceId;
            DeviceId = deviceId;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            MinHumidity = minHumidity;
            MaxHumidity = maxHumidity;
            DeviceStatus = deviceStatus;
        }

        // Methods
        public DeviceStatus StatusCheck(double temperatureRawValue, double humidityRawValue)
        {
            Temperature = MapValue(temperatureRawValue, 0, 1023, -40, 125);
            Humidity = MapValue(humidityRawValue, 0, 1023, 0, 100);

            // Check if temperature is within valid range
            if (Temperature < MinTemperature)
            {
                Temperature = MinTemperature;
            }
            else if (Temperature > MaxTemperature)
            {
                Temperature = MaxTemperature;
            }
            else
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

            // Check if humidity is within valid range
            if (Humidity < MinHumidity)
            {
                Humidity = MinHumidity;
            }
            else if (Humidity > MaxHumidity)
            {
                Humidity = MaxHumidity;
            }
            else
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

            return new DeviceStatus()
            {
                PowerStatus = DTOs.Enums.PowerStatus.On,
                ConfigurationStatus = DTOs.Enums.ConfigurationStatus.Current,
                OperationalStatus = DTOs.Enums.OperationalStatus.Running,
                HealthStatus = DTOs.Enums.HealthStatus.Normal,
                MaintenanceStatus = DTOs.Enums.MaintenanceStatus.NotRequired,
                PerformanceStatus = DTOs.Enums.PerformanceStatus.Normal
            };
        }
        private double MapValue(double value, double inMin, double inMax, double outMin, double outMax)
        {
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
