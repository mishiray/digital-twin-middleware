using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class CameraSensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }
        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>() { IOTSensorType.CameraSensors };

        public string Data { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public CameraSensor()
        {
        }


        public CameraSensor(string deviceId, string data, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Data = data;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
    public class GetCameraSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public string Data { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetCameraSensorDto(string deviceId,string data, GetDeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Data = data;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
