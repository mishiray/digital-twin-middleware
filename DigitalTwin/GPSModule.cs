using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class GPSModuleTwin
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public List<IOTSensorType> IOTSensorTypes { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public GPSModuleTwin()
        {
        }

        public GPSModuleTwin(string deviceId, double longitude, double latitude, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Longitude = longitude;
            Latitude = latitude;
            DeviceStatus = deviceStatus;

            IOTDeviceId = iotDeviceId;
        }
    }
}
