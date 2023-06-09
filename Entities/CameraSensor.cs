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


        public CameraSensor(string deviceId, byte[] data, string iotDeviceId)
        {
            DeviceId = deviceId;
            Data = Convert.ToBase64String(data);
            IOTDeviceId = iotDeviceId;
        }
        public CameraSensor(string deviceId, byte[] data, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Data = Convert.ToBase64String(data);
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
    public class GetCameraSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public byte[] Data { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetCameraSensorDto(string deviceId, byte[] Data, GetDeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Data = Data;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
