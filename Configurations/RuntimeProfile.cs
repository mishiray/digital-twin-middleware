using AutoMapper;
using DigitalTwinMiddleware.DTOs;
using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;

namespace DigitalTwinMiddleware.Configurations
{
    public  class RuntimeProfile : Profile
    {
        public RuntimeProfile()
        {

            #region User Mappings
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.UserName, option => option
                .MapFrom(src => src.Email));

            CreateMap<User, GetUserDto>();
            #endregion

            #region IOTDevice Mappings
            CreateMap<CreateIOTDeviceDto, IOTDevice>()
                .ForMember(dest => dest.IOTSubDevices, option => option
                .MapFrom(src => src.IOTSubDevices.Select(c => new IOTSubDevice()
                {
                    IOTSubDeviceBody = new IOTSubDeviceBody()
                    {
                        IOTDeviceId = c.IOTDeviceId
                    }
                })));
            CreateMap<UpdateIOTDeviceDto, IOTDevice>()
                .ForMember(dest => dest.IOTSubDevices, option => option
                .MapFrom(src => src.IOTSubDevices.Select(c => new IOTSubDevice()
                {
                    IOTSubDeviceBody = new IOTSubDeviceBody()
                    {
                        IOTDeviceId = c.IOTDeviceId
                    }
                })));
            CreateMap<IOTDevice, GetIOTResourceDiscoveryDeviceDto>();
            CreateMap<IOTDevice, CreateIOTDeviceResponseDto>();
            CreateMap<IOTDevice, GetIOTDeviceDto>()
                .ForMember(dest => dest.IOTSubDevices, option => option
                .MapFrom(src => src.IOTSubDevices.Select(c => new GetSubIOTDeviceDto()
                {
                    Id = c.IOTSubDeviceBody.IOTDevice.Id,
                    DeviceId = c.IOTSubDeviceBody.IOTDevice.DeviceId,
                    IOTConfigType = c.IOTSubDeviceBody.IOTDevice.IOTConfigType.ToString(),
                    IOTSensorType = c.IOTSubDeviceBody.IOTDevice.IOTSensorType.ToString(),
                    IOTDeviceType = c.IOTSubDeviceBody.IOTDevice.IOTDeviceType.ToString(),
                    IsActive = c.IOTSubDeviceBody.IOTDevice.IsActive,
                    LastInitiatedConnection = c.IOTSubDeviceBody.IOTDevice.LastInitiatedConnection,
                    Name = c.IOTSubDeviceBody.IOTDevice.Name,
                    TimeStamp = c.IOTSubDeviceBody.IOTDevice.TimeStamp
                })));
            #endregion

            #region Telemetry Mappings
            CreateMap<CreateTelemetryDto, Telemetry>()
                .ForMember(dest => dest.DeviceStatus, option => option
                .MapFrom(src => new DeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus)))
                .ForMember(dest => dest.GPSModule, option => option
                .MapFrom(src => src.GPSModule == null ? null : new GPSModule(src.GPSModule.DeviceId, src.GPSModule.Longitude, src.GPSModule.Latitude, new DeviceStatus(src.GPSModule.DeviceStatus.OperationalStatus, src.GPSModule.DeviceStatus.PowerStatus, 
                src.GPSModule.DeviceStatus.MaintenanceStatus, src.GPSModule.DeviceStatus.PerformanceStatus, src.GPSModule.DeviceStatus.HealthStatus, src.GPSModule.DeviceStatus.ConfigurationStatus), src.GPSModule.IOTDeviceId, src.GPSModule.TimeStamp, src.GPSModule.Location)))
                .ForMember(dest => dest.UltrasonicSensor, option => option
                .MapFrom(src => src.UltrasonicSensor == null ? null : new UltrasonicSensor(src.UltrasonicSensor.Distance, src.UltrasonicSensor.DeviceId, new DeviceStatus(src.UltrasonicSensor.DeviceStatus.OperationalStatus, src.UltrasonicSensor.DeviceStatus.PowerStatus,
                src.UltrasonicSensor.DeviceStatus.MaintenanceStatus, src.UltrasonicSensor.DeviceStatus.PerformanceStatus, src.UltrasonicSensor.DeviceStatus.HealthStatus, src.UltrasonicSensor.DeviceStatus.ConfigurationStatus), src.UltrasonicSensor.IOTDeviceId, src.UltrasonicSensor.Duration, src.UltrasonicSensor.TimeStamp)))
                .ForMember(dest => dest.DHT11Sensor, option => option
                .MapFrom(src => src.DHT11Sensor == null ? null : new DHT11Sensor(src.DHT11Sensor.DeviceId, src.DHT11Sensor.Temperature, src.DHT11Sensor.Humidity, new DeviceStatus(src.DHT11Sensor.DeviceStatus.OperationalStatus, src.DHT11Sensor.DeviceStatus.PowerStatus,
                src.DHT11Sensor.DeviceStatus.MaintenanceStatus, src.DHT11Sensor.DeviceStatus.PerformanceStatus, src.DHT11Sensor.DeviceStatus.HealthStatus, src.DHT11Sensor.DeviceStatus.ConfigurationStatus), src.DHT11Sensor.IOTDeviceId)))
                .ForMember(dest => dest.MotionSensor, option => option
                .MapFrom(src => src.MotionSensor == null ? null : new MotionSensor(src.MotionSensor.IOTDeviceId, src.MotionSensor.MotionDetected, new DeviceStatus(src.MotionSensor.DeviceStatus.OperationalStatus, src.MotionSensor.DeviceStatus.PowerStatus,
                src.MotionSensor.DeviceStatus.MaintenanceStatus, src.MotionSensor.DeviceStatus.PerformanceStatus, src.MotionSensor.DeviceStatus.HealthStatus, src.MotionSensor.DeviceStatus.ConfigurationStatus), src.MotionSensor.DeviceId, src.MotionSensor.TimeStamp)))
                .ForMember(dest => dest.CameraSensor, option => option
                .MapFrom(src => src.CameraSensor == null ? null : new CameraSensor(src.CameraSensor.DeviceId, src.CameraSensor.Data, new DeviceStatus(src.CameraSensor.DeviceStatus.OperationalStatus, src.CameraSensor.DeviceStatus.PowerStatus,
                src.CameraSensor.DeviceStatus.MaintenanceStatus, src.CameraSensor.DeviceStatus.PerformanceStatus, src.CameraSensor.DeviceStatus.HealthStatus, src.CameraSensor.DeviceStatus.ConfigurationStatus), src.CameraSensor.IOTDeviceId, src.CameraSensor.TimeStamp)))
                .ForMember(dest => dest.LedSensor, option => option
                .MapFrom(src => src.LedSensor == null ? null : new LedSensor(src.LedSensor.IOTDeviceId, src.LedSensor.IsOn, new DeviceStatus(src.LedSensor.DeviceStatus.OperationalStatus, src.LedSensor.DeviceStatus.PowerStatus,
                src.LedSensor.DeviceStatus.MaintenanceStatus, src.LedSensor.DeviceStatus.PerformanceStatus, src.LedSensor.DeviceStatus.HealthStatus, src.LedSensor.DeviceStatus.ConfigurationStatus), src.LedSensor.DeviceId)))
                .ForMember(dest => dest.LightSensor, option => option
                .MapFrom(src => src.LightSensor == null ? null : new LightSensor(src.LightSensor.IOTDeviceId, src.LightSensor.Value, new DeviceStatus(src.LightSensor.DeviceStatus.OperationalStatus, src.LightSensor.DeviceStatus.PowerStatus,
                src.LightSensor.DeviceStatus.MaintenanceStatus, src.LightSensor.DeviceStatus.PerformanceStatus, src.LightSensor.DeviceStatus.HealthStatus, src.LightSensor.DeviceStatus.ConfigurationStatus), src.LightSensor.DeviceId)));

            CreateMap<Telemetry, GetTelemetryDto>()
                .ForMember(dest => dest.DeviceStatus, option => option
                .MapFrom(src => new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus)))
                .ForMember(dest => dest.GPSData, option => option
                .MapFrom(src =>src.GPSModule == null ? null : new GetGPSModuleDto(src.GPSModule.DeviceId, src.GPSModule.Longitude, src.GPSModule.Latitude, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.GPSModule.IOTDeviceId, src.GPSModule.TimeStamp, src.GPSModule.Location)))
                .ForMember(dest => dest.UltrasonicSensorData, option => option
                .MapFrom(src => src.UltrasonicSensor == null ? null : new GetUltrasonicSensorDto(src.UltrasonicSensor.DeviceId, src.UltrasonicSensor.Distance, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.UltrasonicSensor.IOTDeviceId, src.UltrasonicSensor.Duration, src.UltrasonicSensor.TimeStamp)))
                .ForMember(dest => dest.DHT11SensorData, option => option
                .MapFrom(src => src.DHT11Sensor == null ? null : new GetDHT11SensorDto(src.DHT11Sensor.DeviceId, src.DHT11Sensor.Temperature, src.DHT11Sensor.Humidity, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.DHT11Sensor.IOTDeviceId, src.DHT11Sensor.TimeStamp)))
                .ForMember(dest => dest.MotionSensorData, option => option
                .MapFrom(src => src.MotionSensor == null ? null : new GetMotionSensorDto(src.MotionSensor.DeviceId, src.MotionSensor.MotionDetected, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.MotionSensor.IOTDeviceId, src.MotionSensor.TimeStamp)))
                .ForMember(dest => dest.CameraSensor, option => option
                .MapFrom(src => src.CameraSensor == null ? null : new GetCameraSensorDto(src.CameraSensor.DeviceId, src.CameraSensor.Data, null, src.CameraSensor.IOTDeviceId, src.CameraSensor.TimeStamp)))
                .ForMember(dest => dest.LedSensorData, option => option
                .MapFrom(src => src.LedSensor == null ? null : new GetLedSensorDto(src.LedSensor.DeviceId, src.LedSensor.IsOn, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.LedSensor.IOTDeviceId)))
                .ForMember(dest => dest.LightSensorData, option => option
                .MapFrom(src => src.LightSensor == null ? null : new GetLightSensorDto(src.LightSensor.DeviceId, src.LightSensor.Value, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.LightSensor.IOTDeviceId)));

            CreateMap<Telemetry, ExportTelemetryData>()
                .ForMember(dest => dest.MaintenanceStatus, option => option
                .MapFrom(src => src.DeviceStatus.MaintenanceStatus))
                .ForMember(dest => dest.PerformanceStatus, option => option
                .MapFrom(src => src.DeviceStatus.PerformanceStatus))
                .ForMember(dest => dest.HealthStatus, option => option
                .MapFrom(src => src.DeviceStatus.HealthStatus))
                .ForMember(dest => dest.PowerStatus, option => option
                .MapFrom(src => src.DeviceStatus.PowerStatus))
                .ForMember(dest => dest.ConfigurationStatus, option => option
                .MapFrom(src => src.DeviceStatus.ConfigurationStatus))
                .ForMember(dest => dest.OperationalStatus, option => option
                .MapFrom(src => src.DeviceStatus.OperationalStatus))

                .ForMember(dest => dest.GPSDeviceId, option => option
                .MapFrom(src => src.GPSModule.DeviceId))
                .ForMember(dest => dest.GPSMaintenanceStatus, option => option
                .MapFrom(src => src.GPSModule.DeviceStatus.MaintenanceStatus))
                .ForMember(dest => dest.GPSPerformanceStatus, option => option
                .MapFrom(src => src.GPSModule.DeviceStatus.PerformanceStatus))
                .ForMember(dest => dest.GPSHealthStatus, option => option
                .MapFrom(src => src.GPSModule.DeviceStatus.HealthStatus))
                .ForMember(dest => dest.GPSPowerStatus, option => option
                .MapFrom(src => src.GPSModule.DeviceStatus.PowerStatus))
                .ForMember(dest => dest.GPSConfigurationStatus, option => option
                .MapFrom(src => src.GPSModule.DeviceStatus.ConfigurationStatus))
                .ForMember(dest => dest.GPSOperationalStatus, option => option
                .MapFrom(src => src.GPSModule.DeviceStatus.OperationalStatus))

                .ForMember(dest => dest.UltrasonicSensorDeviceId, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceId))
                .ForMember(dest => dest.UltrasonicSensorMaintenanceStatus, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceStatus.MaintenanceStatus))
                .ForMember(dest => dest.UltrasonicSensorPerformanceStatus, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceStatus.PerformanceStatus))
                .ForMember(dest => dest.UltrasonicSensorHealthStatus, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceStatus.HealthStatus))
                .ForMember(dest => dest.UltrasonicSensorPowerStatus, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceStatus.PowerStatus))
                .ForMember(dest => dest.UltrasonicSensorConfigurationStatus, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceStatus.ConfigurationStatus))
                .ForMember(dest => dest.UltrasonicSensorOperationalStatus, option => option
                .MapFrom(src => src.UltrasonicSensor.DeviceStatus.OperationalStatus))

                .ForMember(dest => dest.DHT11SensorDeviceId, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceId))
                .ForMember(dest => dest.DHT11SensorMaintenanceStatus, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceStatus.MaintenanceStatus))
                .ForMember(dest => dest.DHT11SensorPerformanceStatus, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceStatus.PerformanceStatus))
                .ForMember(dest => dest.DHT11SensorHealthStatus, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceStatus.HealthStatus))
                .ForMember(dest => dest.DHT11SensorPowerStatus, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceStatus.PowerStatus))
                .ForMember(dest => dest.DHT11SensorConfigurationStatus, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceStatus.ConfigurationStatus))
                .ForMember(dest => dest.DHT11SensorOperationalStatus, option => option
                .MapFrom(src => src.DHT11Sensor.DeviceStatus.OperationalStatus));
            #endregion

            #region Device Relationship
            CreateMap<CreateDeviceRelationshipDto, DeviceRelationship>()
                .ForMember(dest => dest.DeviceOneCondition, option => option
                .MapFrom(src => new DeviceOneReaction()
                {
                    Condition = src.DeviceOneCondition.Condition,
                    Value = src.DeviceOneCondition.Value,
                    Key = src.DeviceOneCondition.Key
                }))
                .ForMember(dest => dest.DeviceTwoReaction, option => option
                .MapFrom(src => new DeviceTwoReaction()
                {
                    Condition = src.DeviceTwoReaction.Condition,
                    Value = src.DeviceTwoReaction.Value,
                    Key = src.DeviceTwoReaction.Key
                }));

            CreateMap<DeviceRelationship, GetDeviceRelationshipDto>()
                .ForMember(dest => dest.MainIOTDevice, option => option
                .MapFrom(src => src.MainIOTDevice.Name))
                .ForMember(dest => dest.DeviceOne, option => option
                .MapFrom(src => src.DeviceOne.Name))
                .ForMember(dest => dest.DeviceTwo, option => option
                .MapFrom(src => src.DeviceTwo.Name))
                .ForMember(dest => dest.DeviceOneCondition, option => option
                .MapFrom(src => new GetDeviceReactionDto()
                {
                    Id = src.DeviceOneCondition.Id,
                    Condition = src.DeviceOneCondition.Condition,
                    Value = src.DeviceOneCondition.Value,
                    Key = src.DeviceOneCondition.Key,
                    DateModified = src.DeviceOneCondition.DateModified,
                    TimeStamp = src.DeviceOneCondition.TimeStamp,
                    IsActive = src.DeviceOneCondition.IsActive
                }))
                .ForMember(dest => dest.DeviceTwoReaction, option => option
                .MapFrom(src => new GetDeviceReactionDto()
                {
                    Id = src.DeviceTwoReaction.Id,
                    Condition = src.DeviceTwoReaction.Condition,
                    Value = src.DeviceTwoReaction.Value,
                    Key = src.DeviceTwoReaction.Key,
                    DateModified = src.DeviceTwoReaction.DateModified,
                    TimeStamp = src.DeviceTwoReaction.TimeStamp,
                    IsActive = src.DeviceTwoReaction.IsActive
                }));

            CreateMap<UpdateDeviceRelationshipDto, DeviceRelationship>()
                .ForMember(dest => dest.DeviceOneCondition, option => option
                .MapFrom(src => new DeviceOneReaction()
                {
                    Condition = src.DeviceOneCondition.Condition,
                    Value = src.DeviceOneCondition.Value,
                    Key = src.DeviceOneCondition.Key
                }))
                .ForMember(dest => dest.DeviceTwoReaction, option => option
                .MapFrom(src => new DeviceTwoReaction()
                {
                    Condition = src.DeviceTwoReaction.Condition,
                    Value = src.DeviceTwoReaction.Value,
                    Key = src.DeviceTwoReaction.Key
                }));
            #endregion
        }
    }
}
