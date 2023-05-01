using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.ServiceDtos;
using DigitalTwinMiddleware.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalTwinMiddleware.Services
{
    public interface IDeviceService
    {
        Task<CustomResponse<IOTDevice>> Create(IOTDevice iOTDevice, CancellationToken token);
        Task<CustomResponse<IOTDevice>> UpdateDevice(IOTDevice iOTDevice, CancellationToken token);
        Task<CustomResponse<bool>> LogTelemetry(Telemetry telemetry, CancellationToken token);
        IQueryable<IOTDevice> ListAll();
        IQueryable<IOTSubDevice> ListAllSubDevices();
        Task<CustomResponse<IOTDevice>> GetById(string iOTDeviceId, CancellationToken token);
        Task<CustomResponse<string>> Connect(string iOTDeviceId, CancellationToken token);
        Task<bool> ResetSubDevices(string iOTDeviceId, List<CreateIOTSubDeviceDto> iOTSubDevices, CancellationToken token);
        IQueryable<Telemetry> ListAllTelemetryByIoT(string iOTDeviceId);
        IQueryable<Telemetry> ListAllTelemetry();
    }

    public class DeviceService : IDeviceService
    {

        private readonly IRepository repository;

        public DeviceService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CustomResponse<IOTDevice>> Create(IOTDevice iOTDevice, CancellationToken token)
        {
            if (iOTDevice is null)
            {
                return new CustomResponse<IOTDevice>()
                {
                    Response = DTOs.Enums.ServiceResponses.Failed,
                    Message = "IOT Device cannot be null"
                };
            }

            var result = await repository.AddAsync(iOTDevice, token);
            if (result)
            {
                return await GetById(iOTDevice.Id, token);
            }

            return new CustomResponse<IOTDevice>()
            {
                Response = DTOs.Enums.ServiceResponses.Failed,
                Message = "Unable to add"
            };
        }

        public async Task<CustomResponse<IOTDevice>> GetById(string iOTDeviceId, CancellationToken token)
        {

            var iotDevice = await ListAll().Include(c => c.IOTSubDevices)
                .ThenInclude(c => c.IOTSubDeviceBody.IOTDevice)
                .FirstOrDefaultAsync(c => c.Id == iOTDeviceId, token);

            if (iotDevice is null)
            {
                return new CustomResponse<IOTDevice>()
                {
                    Response = DTOs.Enums.ServiceResponses.NotFound,
                    Message = "Not Found"
                };
            }

            return new CustomResponse<IOTDevice>()
            {
                Response = DTOs.Enums.ServiceResponses.Success,
                Data = iotDevice
            };
        }

        public async Task<CustomResponse<string>> Connect(string iOTDeviceId, CancellationToken token)
        {
            var iotDevice = await ListAll().FirstOrDefaultAsync(c => c.Id == iOTDeviceId, token);
            if (iotDevice is null)
            {
                return new CustomResponse<string>()
                {
                    Response = DTOs.Enums.ServiceResponses.NotFound,
                    Message = "Unable to connect, Device not found",
                    Data = "Unable to connect, Device not found"
                };
            }

            iotDevice.LastInitiatedConnection = DateTime.UtcNow;
            await Update(iotDevice, token);

            return new CustomResponse<string>()
            {
                Response = DTOs.Enums.ServiceResponses.Success,
                Message = "Connection Successful",
                Data = "Connection Successful"
            };
        }

        public IQueryable<IOTDevice> ListAll()
        {
            return repository.ListAll<IOTDevice>();
        }

        public IQueryable<Telemetry> ListAllTelemetryByIoT(string iOTDeviceId)
        {
            return repository.ListAll<Telemetry>()
                .Include(c => c.DeviceStatus)
                .Include(c => c.GPSModule.DeviceStatus)
                .Include(c => c.DHT11Sensor.DeviceStatus)
                .Include(c => c.UltrasonicSensor.DeviceStatus)
                .Where(c => c.IOTDeviceId == iOTDeviceId);
        }
        public IQueryable<Telemetry> ListAllTelemetry()
        {
            return repository.ListAll<Telemetry>()
                .Include(c => c.DeviceStatus)
                .Include(c => c.GPSModule.DeviceStatus)
                .Include(c => c.DHT11Sensor.DeviceStatus)
                .Include(c => c.UltrasonicSensor.DeviceStatus);
        }

        public async Task<CustomResponse<bool>> LogTelemetry(Telemetry telemetry, CancellationToken token)
        {
            if (telemetry is null)
            {
                return new CustomResponse<bool>()
                {
                    Response = DTOs.Enums.ServiceResponses.Failed,
                    Message = "Telemetry cannot be null"
                };
            }

            var result = await repository.AddAsync(telemetry, token);
            if (result)
            {
                return new CustomResponse<bool>()
                {
                    Response = DTOs.Enums.ServiceResponses.Success,
                    Data = true,
                    Message = "Data Saved"
                };
            }

            return new CustomResponse<bool>()
            {
                Response = DTOs.Enums.ServiceResponses.Failed,
                Message = "Unable to add",
                Data = false
            };
        }

        private async Task<bool> Update(IOTDevice iOTDevice, CancellationToken token)
        {
            if(iOTDevice is null)
            {
                return false;
            }

            iOTDevice.DateModified = DateTime.UtcNow;
            return await repository.ModifyAsync(iOTDevice, token);
        }

        public async Task<CustomResponse<IOTDevice>> UpdateDevice(IOTDevice iOTDevice, CancellationToken token)
        {
            if (iOTDevice is null)
            {
                return new CustomResponse<IOTDevice>()
                {
                    Response = DTOs.Enums.ServiceResponses.Failed,
                    Message = "IOT Device cannot be null"
                };
            }

            var result = await Update(iOTDevice, token);
            if (result)
            {
                return await GetById(iOTDevice.Id, token);
            }

            return new CustomResponse<IOTDevice>()
            {
                Response = DTOs.Enums.ServiceResponses.Failed,
                Message = "Unable to update"
            };
        }

        public async Task<bool> ResetSubDevices(string iOTDeviceId, List<CreateIOTSubDeviceDto> iOTSubDevices, CancellationToken token)
        {
            var iotSubDevices = await ListAllSubDevices().Where(c => c.IOTSubDeviceBody.IOTDeviceId == iOTDeviceId).ToListAsync(token);

            if (iotSubDevices is not null)
            {
                await repository.DeleteRangeAsync(iotSubDevices, token);
            }

            foreach(var subDevice in iOTSubDevices)
            {
                await repository.AddAsync(new IOTSubDevice()
                {
                    IOTDeviceId = iOTDeviceId,
                    IOTSubDeviceBody = new IOTSubDeviceBody()
                    {
                        IOTDeviceId = subDevice.IOTDeviceId
                    }
                }, token);
            }

            return true;
        }

        public IQueryable<IOTSubDevice> ListAllSubDevices()
        {
            return repository.ListAll<IOTSubDevice>();
        }
    }
}
