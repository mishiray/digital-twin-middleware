using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class GPSModule : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>() { IOTSensorType.GPSSensors };

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public GPSModule()
        {
        }

        public GPSModule(string deviceId, double longitude, double latitude, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Longitude = longitude;
            Latitude = latitude;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }

    public class GetGPSModuleDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public GetDeviceStatus DeviceStatus { get; set; }
        public GetGPSModuleDto(string deviceId, double longitude, double latitude, GetDeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Longitude = longitude;
            Latitude = latitude;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
