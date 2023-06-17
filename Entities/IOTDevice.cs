using DigitalTwinMiddleware.DTOs.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalTwinMiddleware.Entities
{
    public class IOTDevice : BaseEntity
    {
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public IOTDeviceType? IOTDeviceType { get; set; }
        public IOTSensorType? IOTSensorType { get; set; }
        public IOTType IOTConfigType { get; set; }
        public List<IOTSubDevice> IOTSubDevices { get; set; }
        public List<Telemetry> Telemetries { get; set; }
        public DateTime LastInitiatedConnection { get; set; }

        [InverseProperty("MainIOTDevice")]
        public List<DeviceRelationship> DeviceRelationships { get; set; }
    }

    public class IOTSubDevice : BaseEntity
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }
        public IOTSubDeviceBody IOTSubDeviceBody { get; set; }
    }

    public class IOTSubDeviceBody : BaseEntity
    {
        [Required]
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }
    }
}
