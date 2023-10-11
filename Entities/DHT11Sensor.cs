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
    public class DHT11Sensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }
        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>(){ IOTSensorType.TemperatureSensors, IOTSensorType.HumiditySensors };

        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public DHT11Sensor()
        {
        }

        public DHT11Sensor(string deviceId, double temperature, double humidity, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Temperature = temperature;
            Humidity = humidity;
            DeviceStatus = deviceStatus;

            IOTDeviceId = iotDeviceId;
        }
    }

    public class GetDHT11SensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetDHT11SensorDto(string deviceId, double temperature, double humidity, GetDeviceStatus deviceStatus, string iotDeviceId, DateTime timeStamp)
        {
            DeviceId = deviceId;
            Temperature = temperature;
            Humidity = humidity;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
            TimeStamp = timeStamp;
        }
    }
}
