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
        public string Location { get; set; }

        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>() { IOTSensorType.GPSSensors };

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public GPSModule()
        {
        }

        public GPSModule(string deviceId, double longitude, double latitude, DeviceStatus deviceStatus, string iotDeviceId, DateTime timeStamp, string location)
        {
            DeviceId = deviceId;
            Longitude = longitude;
            Latitude = latitude;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
            TimeStamp = timeStamp;
            Location = location;    
        }
    }

    public class GetGPSModuleDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public string DeviceId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public GetDeviceStatus DeviceStatus { get; set; }
        public string Location { get; set; }
        public GetGPSModuleDto(string deviceId, double longitude, double latitude, GetDeviceStatus deviceStatus, string iotDeviceId, DateTime timeStamp, string location)
        {
            DeviceId = deviceId;
            Longitude = longitude;
            Latitude = latitude;
            DeviceStatus = deviceStatus;
            TimeStamp = timeStamp;
            IOTDeviceId = iotDeviceId;
            Location = location;
        }
    }
}
