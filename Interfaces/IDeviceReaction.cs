using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.Interfaces
{
    public interface IDeviceReaction
    {
        public string Key { get; set; }
        public Condition Condition { get; set; }
        public string Value { get; set; }
    }
}
