using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwinMiddleware.Entities
{
    public class UltrasonicSensorTwin
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }

        public double Distance { get; set; }

        public List<IOTSensorType> IOTSensorTypes { get; set; }
        public DeviceStatus DeviceStatus { get; set; }

        public UltrasonicSensorTwin()
        {
        }

        public UltrasonicSensorTwin(double distance, string deviceId, DeviceStatus deviceStatus, string iotDeviceId)
        {
            Distance = distance;
            DeviceId = deviceId;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}
