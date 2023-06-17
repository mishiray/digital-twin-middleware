using DigitalTwinMiddleware.Entities.Component;
using DigitalTwinMiddleware.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Entities
{
    public class DeviceRelationship : DbEntity
    {
        [Required]
        public string MainIOTDeviceId { get; set; }
        public IOTDevice MainIOTDevice { get; set; }

        [Required]
        public string DeviceOneId { get; set; }
        public IOTDevice DeviceOne { get; set; }

        public string DeviceTwoId { get; set; }
        public IOTDevice DeviceTwo { get; set; }

        [Required]
        public string DeviceOneConditionId { get; set; }
        public DeviceOneReaction DeviceOneCondition { get; set; }

        [Required]
        public string DeviceTwoReactionId { get; set; }
        public DeviceTwoReaction DeviceTwoReaction { get; set; }

        public static bool CheckRelationship(Condition conditionSource, double value1, double value2)
        {
            switch (conditionSource)
            {
                case Condition.LessThan:
                    return value1 < value2;
                case Condition.GreaterThan:
                    return value1 > value2;
                case Condition.LessThanEqualTo:
                    return value1 <= value2;
                case Condition.GreaterThanEqualTo:
                    return value1 >= value2;
                case Condition.EqualTo:
                    return value1 == value2;
                case Condition.NotEqualTo:
                    return value1 != value2;
                default:
                    return false;
            }
        }
        public static bool CheckRelationship(Condition conditionSource, int value1, int value2)
        {
            switch (conditionSource)
            {
                case Condition.LessThan:
                    return value1 < value2;
                case Condition.GreaterThan:
                    return value1 > value2;
                case Condition.LessThanEqualTo:
                    return value1 <= value2;
                case Condition.GreaterThanEqualTo:
                    return value1 >= value2;
                case Condition.EqualTo:
                    return value1 == value2;
                case Condition.NotEqualTo:
                    return value1 != value2;
                default:
                    return false;
            }
        }
        public static bool CheckRelationship(Condition conditionSource, bool value1, bool value2)
        {
            switch (conditionSource)
            {
                case Condition.EqualTo:
                    return value1 == value2;
                case Condition.NotEqualTo:
                    return value1 != value2;
                default:
                    return false;
            }
        }
        public bool CheckRelationship(Condition conditionSource, string value1, string value2)
        {
            switch (conditionSource)
            {
                case Condition.EqualTo:
                    return value1 == value2;
                case Condition.NotEqualTo:
                    return value1 != value2;
                default:
                    return false;
            }
        }
    }

    public class DeviceOneReaction : BaseEntity, IDeviceReaction
    {
        public string Key { get; set; }
        public Condition Condition { get; set; }
        public string Value { get; set; }

    }

    public class DeviceTwoReaction : BaseEntity, IDeviceReaction
    {
        public string Key { get; set; }
        public Condition Condition { get; set; }
        public string Value { get; set; }
    }

    public enum Condition
    {
        LessThan, GreaterThan, LessThanEqualTo, GreaterThanEqualTo, EqualTo, NotEqualTo
    }
}
