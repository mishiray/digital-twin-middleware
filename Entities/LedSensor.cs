using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class LedSensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public IOTSensorType IOTSensorType { get; set; } = IOTSensorType.LedSensor;

        public bool IsOn { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public LedSensor()
        {
        }

        public LedSensor(string iOTDeviceId, bool isOn, DeviceStatus deviceStatus, string deviceId)
        {
            DeviceId = deviceId;
            IOTDeviceId = iOTDeviceId;
            IsOn = isOn;
            DeviceStatus = deviceStatus;
        }
    }

    public class GetLedSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public bool IsOn { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetLedSensorDto(string deviceId, bool isOn, GetDeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            IsOn = isOn;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
