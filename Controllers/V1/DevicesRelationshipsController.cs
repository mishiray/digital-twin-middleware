using AutoMapper;
using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.DTOs.ServiceDtos;
using DigitalTwinMiddleware.Entities;
using DigitalTwinMiddleware.Services;
using DigitalTwinMiddleware.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DigitalTwinMiddleware.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class DeviceRelationshipsController : ControllerBase
    {

        private readonly IDeviceService deviceService;
        private readonly IDeviceRelationshipService deviceRelationshipService;
        private readonly IMapper mapper;

        public DeviceRelationshipsController(IDeviceService deviceService, IMapper mapper, IDeviceRelationshipService deviceRelationshipService)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
            this.deviceRelationshipService = deviceRelationshipService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateDeviceRelationshipDto model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var deviceRelationship = mapper.Map<DeviceRelationship>(model);

            var customResponse = await deviceRelationshipService.Create(deviceRelationship, token);
            switch (customResponse.Response)
            {
                case ServiceResponses.NotFound:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Failed:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    return Ok(ResponseBuilder.BuildResponse<object>(null, mapper.Map<GetDeviceRelationshipDto>(customResponse.Data)));

                default:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> ListAll(string iotDeviceId, CancellationToken token)
        {
            var deviceRelationships = deviceRelationshipService.ListAll()
                .Include(c => c.MainIOTDevice)
                .Include(c => c.DeviceOne)
                .Include(c => c.DeviceTwo)
                .Include(c => c.DeviceOneCondition)
                .Include(c => c.DeviceTwoReaction)
                .Where(c => c.MainIOTDeviceId == iotDeviceId);

            var mapped = mapper.Map<List<GetDeviceRelationshipDto>>(deviceRelationships);

            return Ok(ResponseBuilder.BuildResponse(null, mapped));
        }

        [HttpGet("{deviceRelationshipId}")]
        public async Task<IActionResult> GetById([Required] string deviceRelationshipId, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var customResponse = await deviceRelationshipService.GetById(deviceRelationshipId, token);

            switch (customResponse.Response)
            {
                case ServiceResponses.NotFound:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Failed:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    return Ok(ResponseBuilder.BuildResponse<object>(null, mapper.Map<GetDeviceRelationshipDto>(customResponse.Data)));

                default:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }

        [HttpDelete("{deviceRelationshipId}")]
        public async Task<IActionResult> Delete([Required] string deviceRelationshipId, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var customResponse = await deviceRelationshipService.GetById(deviceRelationshipId, token);

            switch (customResponse.Response)
            {
                case ServiceResponses.NotFound:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Failed:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    return new ControllerResponse().ReturnResponse(await deviceRelationshipService.Delete(customResponse.Data, token));

                default:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }

        [HttpPatch("{deviceRelationshipId}")]
        public async Task<IActionResult> Update([Required] string deviceRelationshipId, CreateDeviceRelationshipDto model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var existingDeviceRelationship = await deviceRelationshipService.ListAll()
                .Include(c => c.DeviceOne)
                .Include(c => c.DeviceTwo)
                .Include(c => c.DeviceOneCondition)
                .Include(c => c.DeviceTwoReaction)
                .FirstOrDefaultAsync(c => c.Id == deviceRelationshipId, token);

            if (existingDeviceRelationship is null)
            {
                ModelState.AddModelError($"NotFound", "Not Found");
                return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            await deviceRelationshipService.Delete(existingDeviceRelationship, token);

            var deviceRelationship = mapper.Map<DeviceRelationship>(model);

            var customResponse = await deviceRelationshipService.Create(deviceRelationship, token);
            switch (customResponse.Response)
            {
                case ServiceResponses.NotFound:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Failed:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    return Ok(ResponseBuilder.BuildResponse<object>(null, mapper.Map<GetDeviceRelationshipDto>(customResponse.Data)));

                default:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }
    }
}
