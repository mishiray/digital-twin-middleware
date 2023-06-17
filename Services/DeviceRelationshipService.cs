using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.ServiceDtos;
using DigitalTwinMiddleware.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalTwinMiddleware.Services
{
    public interface IDeviceRelationshipService
    {
        Task<CustomResponse<DeviceRelationship>> Create(DeviceRelationship deviceRelationship, CancellationToken token);
        Task<CustomResponse<DeviceRelationship>> Update(DeviceRelationship deviceRelationship, CancellationToken token);
        Task<CustomResponse<bool>> Delete(DeviceRelationship deviceRelationship, CancellationToken token);
        IQueryable<DeviceRelationship> ListAll();
        Task<CustomResponse<DeviceRelationship>> GetById(string deviceRelationshipId, CancellationToken token);
    }
    public class DeviceRelationshipService : IDeviceRelationshipService
    {
        private readonly IRepository repository;

        public DeviceRelationshipService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CustomResponse<DeviceRelationship>> Create(DeviceRelationship deviceRelationship, CancellationToken token)
        {
            if(deviceRelationship is null)
            {
                return new CustomResponse<DeviceRelationship>()
                {
                    Response = DTOs.Enums.ServiceResponses.BadRequest,
                    Message = "Device relationship cannot be null"
                };
            }

            var result = await repository.AddAsync(deviceRelationship, token);
            if (result)
            {
                return await GetById(deviceRelationship.Id, token);
            }

            return new CustomResponse<DeviceRelationship>()
            {
                Response = DTOs.Enums.ServiceResponses.Failed,
                Message = "Unable to add"
            };
        }

        public async Task<CustomResponse<bool>> Delete(DeviceRelationship deviceRelationship, CancellationToken token)
        {
            if (deviceRelationship is null)
            {
                return new CustomResponse<bool>()
                {
                    Response = DTOs.Enums.ServiceResponses.BadRequest,
                    Message = "Device relationship cannot be null"
                };
            }

            var result = await repository.DeleteAsync(deviceRelationship, token);
            if (result)
            {
                return new CustomResponse<bool>()
                {
                    Response = DTOs.Enums.ServiceResponses.Success,
                    Data = true
                };
            }

            return new CustomResponse<bool>()
            {
                Response = DTOs.Enums.ServiceResponses.Failed,
                Message = "Unable to delete"
            };
        }

        public async Task<CustomResponse<DeviceRelationship>> GetById(string deviceRelationshipId, CancellationToken token)
        {
            var deviceRelationship = await ListAll()
                .Include(c => c.MainIOTDevice)
                .Include(c => c.DeviceOne)
                .Include(c => c.DeviceTwo)
                .Include(c => c.DeviceOneCondition)
                .Include(c => c.DeviceTwoReaction)
                .FirstOrDefaultAsync(c => c.Id == deviceRelationshipId, token);

            if(deviceRelationship is null)
            {
                return new CustomResponse<DeviceRelationship>()
                {
                    Response = DTOs.Enums.ServiceResponses.NotFound,
                    Message = "Device Reationship not found"
                };
            }

            return new CustomResponse<DeviceRelationship>()
            {
                Data = deviceRelationship,
                Response = DTOs.Enums.ServiceResponses.Success
            };
        }

        public IQueryable<DeviceRelationship> ListAll()
        {
            return repository.ListAll<DeviceRelationship>();
        }

        public async Task<CustomResponse<DeviceRelationship>> Update(DeviceRelationship deviceRelationship, CancellationToken token)
        {
            if (deviceRelationship is null)
            {
                return new CustomResponse<DeviceRelationship>()
                {
                    Response = DTOs.Enums.ServiceResponses.BadRequest,
                    Message = "Device relationship cannot be null"
                };
            }

            deviceRelationship.DateModified = DateTime.UtcNow;

            var result = await repository.ModifyAsync(deviceRelationship, token);
            if (result)
            {
                return await GetById(deviceRelationship.Id, token);
            }

            return new CustomResponse<DeviceRelationship>()
            {
                Response = DTOs.Enums.ServiceResponses.Failed,
                Message = "Unable to update"
            };
        }
    }
}
