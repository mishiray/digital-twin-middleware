using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class LightSensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>() { IOTSensorType.LightSensors };

        public bool Value { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public LightSensor()
        {
        }

        public LightSensor(string iOTDeviceId, bool value, DeviceStatus deviceStatus, string deviceId)
        {
            DeviceId = deviceId;
            IOTDeviceId = iOTDeviceId;
            Value = value;
            DeviceStatus = deviceStatus;
        }
    }

    public class GetLightSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public bool Value { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetLightSensorDto(string deviceId, bool value, GetDeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Value = value;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
