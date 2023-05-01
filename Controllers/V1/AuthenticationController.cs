using DigitalTwinMiddleware.DTOs;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.Services;
using DigitalTwinMiddleware.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalTwinMiddleware.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IDeviceService deviceService;

        public AuthenticationController(IUserService userService, IDeviceService deviceService)
        {
            this.userService = userService;
            this.deviceService = deviceService;
        }

        [HttpPost("generate-token")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IOTDeviceToken(RequestBearerTokenModel model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var existingDevice = await deviceService.ListAll().FirstOrDefaultAsync(c => c.Id == model.IOTDeviceId, token);

            if (existingDevice is null)
            {
                ModelState.AddModelError($"{ServiceResponses.NotFound}", "IOT Device Not Found");
                return NotFound(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            return new ControllerResponse().ReturnResponse(await userService.GenerateDeviceBearerToken(existingDevice));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            return new ControllerResponse().ReturnResponse(await userService.Login(model));
        }

    }
}
