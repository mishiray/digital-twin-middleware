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
    public class DevicesController : ControllerBase
    {

        private readonly IDeviceService deviceService;
        private readonly IMapper mapper;

        public DevicesController(IDeviceService deviceService, IMapper mapper)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateIOTDeviceDto model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var iotDevice = mapper.Map<IOTDevice>(model);
            iotDevice.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var createdResult = await deviceService.Create(iotDevice, token);

            return new ControllerResponse().ReturnResponse(createdResult);
        }

        [HttpGet("connect")]
        public async Task<IActionResult> EstablishConnection(CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            return new ControllerResponse().ReturnResponse(await deviceService.Connect(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), token));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> ListAll(int page, int perPage, CancellationToken token)
        {
            var iotDevices = deviceService.ListAll()
                .Include(c => c.User)
                .Where(c => c.UserId == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var paginatedDevices = iotDevices.Paginate(page, perPage);

            var mapped = mapper.Map<List<GetIOTDeviceDto>>(paginatedDevices);

            return Ok(ResponseBuilder.BuildResponse(null, Pagination.GetPagedData(mapped, page, perPage, await iotDevices.CountAsync(token))));
        }

        [HttpGet("{iOTDeviceId}")]
        public async Task<IActionResult> GetById([Required] string iOTDeviceId, CancellationToken token)
        {

            var customResponse = await deviceService.GetById(iOTDeviceId, token);

            switch (customResponse.Response)
            {
                case ServiceResponses.NotFound:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Failed:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    return Ok(ResponseBuilder.BuildResponse<object>(null, mapper.Map<GetIOTDeviceDto>(customResponse.Data)));

                default:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }

        [HttpGet("list-device-types")]
        [AllowAnonymous]
        public async Task<IActionResult> DeviceTypes()
        {
            return Ok(ResponseBuilder.BuildResponse(null, await Task.Run(() => Enum.GetNames<IOTDeviceType>())));
        }

        [HttpGet("list-sensor-types")]
        [AllowAnonymous]
        public async Task<IActionResult> SensorTypes()
        {
            return Ok(ResponseBuilder.BuildResponse(null, await Task.Run(() => Enum.GetNames<IOTSensorType>())));
        }

        [HttpGet("list-config-types")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfigurationTypes()
        {
            return Ok(ResponseBuilder.BuildResponse(null, await Task.Run(() => Enum.GetNames<IOTType>())));
        }

        [HttpPatch("{iOTDeviceId}")]
        public async Task<IActionResult> Update([Required] string iOTDeviceId, UpdateIOTDeviceDto model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var existingIOTDevice = await deviceService.ListAll().Include(c => c.IOTSubDevices)
                .ThenInclude(c => c.IOTSubDeviceBody)
                .FirstOrDefaultAsync(c => c.Id == iOTDeviceId, token);

            if(existingIOTDevice is null)
            {
                ModelState.AddModelError($"NotFound", "Not Found");
                return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            await deviceService.ResetSubDevices(iOTDeviceId, model.IOTSubDevices, token);

            existingIOTDevice = mapper.Map(model, existingIOTDevice);

            var customResponse = await deviceService.UpdateDevice(existingIOTDevice, token);

            switch (customResponse.Response)
            {
                case ServiceResponses.NotFound:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Failed:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    return Ok(ResponseBuilder.BuildResponse<object>(null, mapper.Map<GetIOTDeviceDto>(customResponse.Data)));

                default:
                    ModelState.AddModelError($"{customResponse.Response}", customResponse.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }
    }
}
