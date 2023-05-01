using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DigitalTwinMiddleware.Entities;
using DigitalTwinMiddleware.Services;
using DigitalTwinMiddleware.Utilities;

namespace DigitalTwinMiddleware.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUserService userService;

        public RolesController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string rolename)
        {
            if (string.IsNullOrEmpty(rolename))
            {
                ModelState.AddModelError($"BadRequest", "Rolename cannot be null or empty");
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            if (await userService.RoleManager.FindByNameAsync(rolename) is not null)
            {
                ModelState.AddModelError($"BadRequest", "Role already exists");
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            var result = await userService.RoleManager.CreateAsync(new IdentityRole(rolename));
            if (result.Succeeded)
            {
                return Ok(ResponseBuilder.BuildResponse(null, "Role created successfully"));
            }

            ModelState.AddModelError($"BadRequest", "Unable to create role");
            return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
        }



        [HttpGet("list-all")]
        public async Task<IActionResult> ViewAllRoles(CancellationToken token)
        {
            var roles = await userService.RoleManager.Roles.Select(c => c.Name).ToListAsync(token);

            return Ok(ResponseBuilder.BuildResponse(null, roles));
        }

    }
}
