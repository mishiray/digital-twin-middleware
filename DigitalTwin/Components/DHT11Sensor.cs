using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using DigitalTwinMiddleware.Interfaces;
using DigitalTwinMiddleware.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwinMiddleware.DigitalTwin.Components
{
    public class DHT11SensorTwin
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        double MinTemperature { get; set; }
        double MaxTemperature { get; set; }
        double MinHumidity { get; set; }
        double MaxHumidity { get; set; }

        public DeviceStatus DeviceStatus { get; set; }
        

        public DHT11SensorTwin(double minTemperature, double maxTemperature,
            double minHumidity, double maxHumidity)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            MinHumidity = minHumidity;
            MaxHumidity = maxHumidity;
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
                    PowerStatus = PowerStatus.On,
                    ConfigurationStatus = ConfigurationStatus.Misconfigured,
                    OperationalStatus = OperationalStatus.Error,
                    HealthStatus = HealthStatus.Critical,
                    MaintenanceStatus = MaintenanceStatus.Required,
                    PerformanceStatus = PerformanceStatus.LowAccuracy
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
                    PowerStatus = PowerStatus.On,
                    ConfigurationStatus = ConfigurationStatus.Misconfigured,
                    OperationalStatus = OperationalStatus.Error,
                    HealthStatus = HealthStatus.Critical,
                    MaintenanceStatus = MaintenanceStatus.Required,
                    PerformanceStatus = PerformanceStatus.LowAccuracy
                };
            }

            return new DeviceStatus()
            {
                PowerStatus = PowerStatus.On,
                ConfigurationStatus = ConfigurationStatus.Current,
                OperationalStatus = OperationalStatus.Running,
                HealthStatus = HealthStatus.Normal,
                MaintenanceStatus = MaintenanceStatus.NotRequired,
                PerformanceStatus = PerformanceStatus.Normal
            };
        }
        private double MapValue(double value, double inMin, double inMax, double outMin, double outMax)
        {
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
