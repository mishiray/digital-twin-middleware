using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities.Component;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class VideoSensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public IOTSensorType IOTSensorTypes { get; set; } = IOTSensorType.CameraSensors;

        public string Data { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public VideoSensor()
        {
        }


        public VideoSensor(string deviceId, string data, DeviceStatus deviceStatus, string iotDeviceId, DateTime timeStamp)
        {
            DeviceId = deviceId;
            Data = data;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
            TimeStamp = timeStamp;
        }
    }

    public class GetVideoSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public string Data { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public DateTime TimeStamp { get; set; }
        public GetVideoSensorDto(string deviceId, string data, GetDeviceStatus deviceStatus, string iotDeviceId, DateTime timeStamp)
        {
            DeviceId = deviceId;
            Data = data;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
            TimeStamp = timeStamp;
        }
    }
}
