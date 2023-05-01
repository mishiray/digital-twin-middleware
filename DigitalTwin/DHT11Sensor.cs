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

        public DeviceStatus DeviceStatus { get; set; }

        public DHT11SensorTwin()
        {
        }

        public DHT11SensorTwin(string deviceId, double temperature, double humidity, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Temperature = temperature;
            Humidity = humidity;
            DeviceStatus = deviceStatus;

            IOTDeviceId = iotDeviceId;
        }
    }
}
