using AutoMapper;
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
    //[Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateUserDto model, CancellationToken token)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));

            var user = mapper.Map<User>(model);

            var createdResult = await userService.CreateUser(user);

            return new ControllerResponse().ReturnResponse(createdResult);
        }

        [HttpGet("get-all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListAll(int page, int perPage, CancellationToken token)
        {
            var users = userService.ListAll();

            var paginatedUsers = users.Paginate(page, perPage);

            var mapped = mapper.Map<List<GetUserDto>>(paginatedUsers);

            return Ok(ResponseBuilder.BuildResponse(null, Pagination.GetPagedData(mapped, page, perPage, await users.CountAsync(token))));
        }

        [HttpGet("get-by-id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([Required]string userId, CancellationToken token)
        {
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError($"BadRequest", "UserId cannot be null or empty");
                return BadRequest(ResponseBuilder.BuildResponse<object>(ModelState, null));
            }

            return new ControllerResponse().ReturnResponse(await userService.GetUserById(userId, token));
        }
    }
}
