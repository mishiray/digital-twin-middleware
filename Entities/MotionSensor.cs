using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class MotionSensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>() { IOTSensorType.MotionSensors };

        public bool MotionDetected { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public MotionSensor()
        {
        }

        public MotionSensor(string iOTDeviceId, bool motionDetected, DeviceStatus deviceStatus, string deviceId)
        {
            DeviceId = deviceId;
            IOTDeviceId = iOTDeviceId;
            MotionDetected = motionDetected;
            DeviceStatus = deviceStatus;
        }
    }

    public class GetMotionSensorDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public bool MotionDetected { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetMotionSensorDto(string deviceId, bool motionDetected, GetDeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            MotionDetected = motionDetected;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
