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
                .MapFrom(src => src.GPSModule == null ? null : new GPSModule(src.GPSModule.DeviceId, src.GPSModule.Longitude, src.GPSModule.Latitude, new DeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus, 
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.GPSModule.IOTDeviceId)))
                .ForMember(dest => dest.UltrasonicSensor, option => option
                .MapFrom(src => src.UltrasonicSensor == null ? null : new UltrasonicSensor(src.UltrasonicSensor.Distance, src.UltrasonicSensor.DeviceId, new DeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.UltrasonicSensor.IOTDeviceId, src.UltrasonicSensor.Duration)))
                .ForMember(dest => dest.DHT11Sensor, option => option
                .MapFrom(src => src.DHT11Sensor == null ? null : new DHT11Sensor(src.DHT11Sensor.DeviceId, src.DHT11Sensor.Temperature, src.DHT11Sensor.Humidity, new DeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.DHT11Sensor.IOTDeviceId)))
                .ForMember(dest => dest.MotionSensor, option => option
                .MapFrom(src => src.MotionSensor == null ? null : new MotionSensor(src.MotionSensor.DeviceId, src.MotionSensor.MotionDetected, new DeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.MotionSensor.IOTDeviceId)))
                .ForMember(dest => dest.LedSensor, option => option
                .MapFrom(src => src.LedSensor == null ? null : new MotionSensor(src.LedSensor.DeviceId, src.LedSensor.IsOn, new DeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.LedSensor.IOTDeviceId)));

            CreateMap<Telemetry, GetTelemetryDto>()
                .ForMember(dest => dest.DeviceStatus, option => option
                .MapFrom(src => new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus)))
                .ForMember(dest => dest.GPSData, option => option
                .MapFrom(src =>src.GPSModule == null ? null : new GetGPSModuleDto(src.GPSModule.DeviceId, src.GPSModule.Longitude, src.GPSModule.Latitude, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.GPSModule.IOTDeviceId)))
                .ForMember(dest => dest.UltrasonicSensorData, option => option
                .MapFrom(src => src.UltrasonicSensor == null ? null : new GetUltrasonicSensorDto(src.UltrasonicSensor.DeviceId, src.UltrasonicSensor.Distance, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.UltrasonicSensor.IOTDeviceId, src.UltrasonicSensor.Duration)))
                .ForMember(dest => dest.DHT11SensorData, option => option
                .MapFrom(src => src.DHT11Sensor == null ? null : new GetDHT11SensorDto(src.DHT11Sensor.DeviceId, src.DHT11Sensor.Temperature, src.DHT11Sensor.Humidity, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.DHT11Sensor.IOTDeviceId)))
                .ForMember(dest => dest.MotionSensorDto, option => option
                .MapFrom(src => src.MotionSensor == null ? null : new GetMotionSensorDto(src.MotionSensor.DeviceId, src.MotionSensor.MotionDetected, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.MotionSensor.IOTDeviceId)))
                .ForMember(dest => dest.LedSensor, option => option
                .MapFrom(src => src.LedSensor == null ? null : new GetMotionSensorDto(src.LedSensor.DeviceId, src.LedSensor.IsOn, new GetDeviceStatus(src.DeviceStatus.OperationalStatus, src.DeviceStatus.PowerStatus,
                src.DeviceStatus.MaintenanceStatus, src.DeviceStatus.PerformanceStatus, src.DeviceStatus.HealthStatus, src.DeviceStatus.ConfigurationStatus), src.LedSensor.IOTDeviceId)));

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
        }
    }
}
