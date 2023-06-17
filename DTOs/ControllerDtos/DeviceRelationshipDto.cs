using DigitalTwinMiddleware.Entities;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.DTOs.ControllerDtos
{
    public class CreateDeviceRelationshipDto
    {
        [Required]
        public string MainIOTDeviceId { get; set; }

        [Required]
        public string DeviceOneId { get; set; }

        public string DeviceTwoId { get; set; }

        public CreateDeviceReactionDto DeviceOneCondition { get; set; }

        public CreateDeviceReactionDto DeviceTwoReaction { get; set; }
    }

    public class CreateDeviceReactionDto
    {
        public string Key { get; set; }
        public Condition Condition { get; set; }
        public string Value { get; set; }
    }

    public class GetDeviceRelationshipDto
    {
        public string Id { get; set; }
        public string MainIOTDeviceId { get; set; }
        public string MainIOTDevice { get; set; }
        public string DeviceOneId { get; set; }
        public string DeviceOne { get; set; }
        public string DeviceTwoId { get; set; }
        public string DeviceTwo { get; set; }
        public GetDeviceReactionDto DeviceOneCondition { get; set; }
        public GetDeviceReactionDto DeviceTwoReaction { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetDeviceReactionDto
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public Condition Condition { get; set; }
        public string Value { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDeviceRelationshipDto
    {
        public string Id { get; set; }
        public string MainIOTDeviceId { get; set; }
        public string DeviceOneId { get; set; }
        public string DeviceTwoId { get; set; }
        public UpdateDeviceReactionDto DeviceOneCondition { get; set; }
        public UpdateDeviceReactionDto DeviceTwoReaction { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDeviceReactionDto
    {
        public string Key { get; set; }
        public Condition Condition { get; set; }
        public string Value { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
    }
}
