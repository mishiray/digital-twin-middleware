﻿using AutoMapper;
using DigitalTwinMiddleware.DigitalTwin;
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
    public class DigitalTwinsController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        private readonly IMapper mapper;

        public DigitalTwinsController(IDeviceService deviceService, IMapper mapper)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
        }

        [HttpGet("evaluate")]
        public async Task<IActionResult> ListAll([Required] string iOTDeviceId, DateTime startDate, DateTime endDate, CancellationToken token)
        {
            var iotDevice = await deviceService.GetById(iOTDeviceId, token);

            switch (iotDevice.Response)
            {
                case ServiceResponses.NotFound:

                    ModelState.AddModelError($"{iotDevice.Response}", iotDevice.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    var telemetry = await deviceService.ListAllTelemetry()
                        .Include(c => c.DeviceStatus)
                        .Include(c => c.IOTDevice.DeviceRelationships)
                        .ThenInclude(c => c.DeviceOneCondition)
                        .Include(c => c.IOTDevice.DeviceRelationships)
                        .ThenInclude(c => c.DeviceTwoReaction)
                        .Include(c => c.GPSModule.IOTDevice)
                        .Include(c => c.DHT11Sensor.IOTDevice)
                        .Include(c => c.LightSensor.IOTDevice)
                        .Include(c => c.MotionSensor.IOTDevice)
                        .Include(c => c.UltrasonicSensor.IOTDevice)
                        .Include(c => c.LedSensor.IOTDevice)
                        .Include(c => c.CameraSensor.IOTDevice)
                        .Where(c => c.TimeStamp >= startDate.ToUniversalTime() && c.TimeStamp <= endDate.ToUniversalTime() && c.IOTDeviceId == iOTDeviceId)
                        .ToListAsync(token);

                    var twinData = new IOTDeviceTwin(telemetry);
                    var data = twinData.Principal();

                    return Ok(ResponseBuilder.BuildResponse(null, data));

                default:
                    ModelState.AddModelError($"{iotDevice.Response}", iotDevice.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }
    }
}
