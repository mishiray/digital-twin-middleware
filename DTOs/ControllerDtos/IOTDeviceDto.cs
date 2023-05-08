using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.DTOs.ControllerDtos
{
    public class ConnectIOTDeviceDto
    {
        [Required]
        public string IOTDeviceId { get; set; }
    }

    public class CreateIOTDeviceDto
    {
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public string Name { get; set; }
        public IOTDeviceType? IOTDeviceType { get; set; }
        public IOTDeviceType? IOTSensorType { get; set; }
        public IOTType IOTConfigType { get; set; }
        public List<CreateIOTSubDeviceDto> IOTSubDevices { get; set; }

    }

    public class UpdateIOTDeviceDto
    {
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public string Name { get; set; }
        public IOTDeviceType? IOTDeviceType { get; set; }
        public IOTDeviceType? IOTSensorType { get; set; }
        public IOTType IOTConfigType { get; set; }
        public List<CreateIOTSubDeviceDto> IOTSubDevices { get; set; }
    }

    public class CreateIOTSubDeviceDto
    {
        public string IOTDeviceId { get; set; }
    }

    public class GetIOTDeviceDto
    {
        public string Id { get; set; }
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string IOTDeviceType { get; set; }
        public string IOTSensorType { get; set; }
        public string IOTConfigType { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime? LastInitiatedConnection { get; set; }
        public List<GetSubIOTDeviceDto> IOTSubDevices { get; set; }
    }

    public class CreateIOTDeviceResponseDto
    {
        public string Id { get; set; }
    }
    public class GetIOTDeviceSummary
    {
        public int TotalDevices { get; set; }
        public int TotalComponentDevices { get; set; }
    }

    public class GetIOTResourceDiscoveryDeviceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IOTDeviceType { get; set; }
        public string IOTSensorType { get; set; }
        public string IOTConfigType { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class GetSubIOTDeviceDto
    {
        public string Id { get; set; }
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string IOTDeviceType { get; set; }
        public string IOTSensorType { get; set; }
        public string IOTConfigType { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime LastInitiatedConnection { get; set; }
    }
}
