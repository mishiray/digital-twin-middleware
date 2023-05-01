using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.Interfaces
{
    public interface ITelemetryData
    {
        public string IOTDeviceId { get; set; }
        public IOTDevice IOTDevice { get; set; }

        public DeviceStatus DeviceStatus { get; set; }
    }
}
