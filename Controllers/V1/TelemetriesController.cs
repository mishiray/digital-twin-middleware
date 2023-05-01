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
    public class TelemetriesController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        private readonly IMapper mapper;

        public TelemetriesController(IDeviceService deviceService, IMapper mapper)
        {
            this.deviceService = deviceService;
            this.mapper = mapper;
        }


        [HttpPost("log")]
        public async Task<IActionResult> Create(CreateTelemetryDto model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var telematry = mapper.Map<Telemetry>(model);
            telematry.IOTDeviceId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var createdResult = await deviceService.LogTelemetry(telematry, token);

            return new ControllerResponse().ReturnResponse(createdResult);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> ListAll([Required] string iOTDeviceId, DateTime startDate, DateTime endDate, CancellationToken token)
        {
            var iotDevice = await deviceService.GetById(iOTDeviceId, token);

            switch (iotDevice.Response)
            {
                case ServiceResponses.NotFound:
                    
                    ModelState.AddModelError($"{iotDevice.Response}", iotDevice.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    var telemetry = await deviceService.ListAllTelemetryByIoT(iOTDeviceId)
                        .Where(c => c.TimeStamp >= startDate.ToUniversalTime() && c.TimeStamp <= endDate.ToUniversalTime())
                        .ToListAsync(token);
                    return Ok(ResponseBuilder.BuildResponse(null, mapper.Map<List<GetTelemetryDto>>(telemetry)));

                default:
                    ModelState.AddModelError($"{iotDevice.Response}", iotDevice.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }

        [HttpGet("export-training-data")]
        public async Task<IActionResult> ExportData([Required] string iOTDeviceId, DateTime startDate, DateTime endDate, CancellationToken token)
        {
            var iotDevice = await deviceService.GetById(iOTDeviceId, token);

            switch (iotDevice.Response)
            {
                case ServiceResponses.NotFound:

                    ModelState.AddModelError($"{iotDevice.Response}", iotDevice.Message);
                    return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));

                case ServiceResponses.Success:
                    var telemetry = await deviceService.ListAllTelemetryByIoT(iOTDeviceId)
                        .Where(c => c.TimeStamp >= startDate.ToUniversalTime() && c.TimeStamp <= endDate.ToUniversalTime())
                        .ToListAsync(token);

                    var stretched = mapper.Map<List<ExportTelemetryData>>(telemetry);
                    CsvSerializer.ToCsv<ExportTelemetryData>(",",stretched);

                    return Ok(ResponseBuilder.BuildResponse(null, "Ok"));

                default:
                    ModelState.AddModelError($"{iotDevice.Response}", iotDevice.Message);
                    return UnprocessableEntity(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }
        }
    }
}
