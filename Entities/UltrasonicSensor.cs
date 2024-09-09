using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwinMiddleware.Entities
{
    public class UltrasonicSensor : BaseEntity, ITelemetryData
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public double Duration { get; set; }

        public string DeviceId { get; set; }

        public double Distance { get; set; }

        public IOTSensorType IOTSensorType { get; set; } = IOTSensorType.ProximitySensors;
        public DeviceStatus DeviceStatus { get; set; }

        public UltrasonicSensor()
        {
        }

        public UltrasonicSensor(double distance, string deviceId, DeviceStatus deviceStatus, string iotDeviceId, double duration, DateTime timeStamp)
        {
            Distance = distance;
            DeviceId = deviceId;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
            Duration = duration;
            TimeStamp = timeStamp;
        }
    }
    public class GetUltrasonicSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public GetDeviceStatus DeviceStatus { get; set; }
        public DateTime TimeStamp { get; set; }
        public GetUltrasonicSensorDto(string deviceId, double distance, GetDeviceStatus deviceStatus,string iOTDeviceId, double duration, DateTime timeStamp)
        {
            IOTDeviceId = iOTDeviceId;
            DeviceId = deviceId;
            Distance = distance;
            Duration = duration;
            DeviceStatus = deviceStatus;
            TimeStamp = timeStamp;
        }
    }
}
