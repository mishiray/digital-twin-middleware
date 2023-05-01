using AutoMapper;
using DigitalTwinMiddleware.DTOs;
using DigitalTwinMiddleware.DTOs.ControllerDtos;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Entities;
using DigitalTwinMiddleware.Services;
using DigitalTwinMiddleware.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DigitalTwinMiddleware.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ResourceDiscoveriesController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        private readonly IMapper mapper;

        public ResourceDiscoveriesController(IDeviceService deviceService, IMapper mapper)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
        }

        [HttpGet("get-all-devices")]
        public async Task<IActionResult> ListAllDevices(CancellationToken token)
        {
            var iotDevices = await deviceService.ListAll().Where(c => c.IsActive).ToListAsync(token);

            return Ok(ResponseBuilder.BuildResponse(null, mapper.Map<List<GetIOTResourceDiscoveryDeviceDto>>(iotDevices)));
        }

        [HttpGet("get-all-devices-around-me")]
        public async Task<IActionResult> ListAllDevicesAroundMe(ResourceDiscoveryLocationDto model, CancellationToken token)
        {
            var telemetryData = await deviceService.ListAllTelemetry().Include(c => c.GPSModule).Where(c => c.GPSModule.Longitude == model.Longitude
            && c.GPSModule.Latitude == model.Latitude).Take(10).ToListAsync(token);
                
            return Ok(ResponseBuilder.BuildResponse(null, mapper.Map<List<GetTelemetryDto>>(telemetryData)));
        }
    }
}
