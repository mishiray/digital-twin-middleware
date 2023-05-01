﻿using DigitalTwinMiddleware.DTOs.Enums;

namespace DigitalTwinMiddleware.Entities
{
    public class CameraSensor : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public string DeviceId { get; set; }
        public List<IOTSensorType> IOTSensorTypes { get; set; } = new List<IOTSensorType>() { IOTSensorType.CameraSensors };

        public byte[] Data { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public CameraSensor()
        {
        }


        public CameraSensor(string deviceId, byte[] data, DeviceStatus deviceStatus, string iotDeviceId)
        {
            DeviceId = deviceId;
            Data = data;
            DeviceStatus = deviceStatus;
            IOTDeviceId = iotDeviceId;
        }
    }
}