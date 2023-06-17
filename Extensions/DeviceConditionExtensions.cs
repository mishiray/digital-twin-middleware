using DigitalTwinMiddleware.Entities;
using DigitalTwinMiddleware.Entities.Component;
using DigitalTwinMiddleware.Interfaces;

namespace DigitalTwinMiddleware.Extensions
{
    public static class DeviceConditionExtensions
    {
        public static DeviceOneReaction GetValue(this DeviceOneReaction source, string selector)
        {
            if (string.IsNullOrEmpty(selector))
            {
                return null;
            }

            if (source.Key == selector)
            {
                return source;
            }

            return null;
        }

        public static DeviceTwoReaction GetValue(this DeviceTwoReaction source, string selector)
        {
            if (string.IsNullOrEmpty(selector))
            {
                return null;
            }

            if (source.Key == selector)
            {
                return source;
            }

            return null;
        }

    }
}
