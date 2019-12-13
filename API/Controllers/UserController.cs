using System;
using System.Linq;
using KeenSap.Portal.API.Common.Validation;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Service.Dto;
using KeenSap.Portal.Service.Dto.Request;
using KeenSap.Portal.Service.Dto.Response;
using KeenSap.Portal.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KeenSap.Portal.API.Controllers
{
    // [Authorize]
    //[ApiController]
    [Route("api/[controller]")]
    public class UsersController : GenericController
    {
        private readonly ILogger _logger;
        private IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // [AllowAnonymous]
        // [HttpPost("authenticate")]
        // public IActionResult Authenticate([FromBody]User userParam)
        // {
        //     var user = _userService.Authenticate(userParam.Username, userParam.Password);

        //     if (user == null)
        //         return BadRequest(new { message = "Username or password is incorrect" });

        //     return Ok(user);
        // }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var users =  _userService.Get();
            return Success(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user =  _userService.Get(id);

            if (user == null) {
                return NotFound();
            }

            // only allow admins to access other user records
            // var currentUserId = int.Parse(User.Identity.Name);
            // if (id != currentUserId && !User.IsInRole(Role.Admin)) {
            //     return Forbid();
            // }

            return Success(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateDto userCreateDto)
        {
            _logger.LogDebug($"Create User: Getting item {userCreateDto}");
            try
            {
                var userGetDto = _userService.Add(userCreateDto);
                _logger.LogDebug("Create User: Added successfully");
                return  Success(userGetDto, "Added successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError("Create User: Error occured", ex);
                return UnprocessableEntity(ex);                
            }
            
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public IActionResult Update(long id, [FromBody] UserUpdateDto userUpdateDto)
        {
            _logger.LogDebug($"Update User: Getting item {userUpdateDto}");
            try
            {
                var userGetDto = _userService.Update(id, userUpdateDto);
                _logger.LogDebug("Update User: Updated successfully");
                return  Success(userGetDto, "Updated successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError("Update User: Error occured", ex);
                return Error("An error occured", ex);
            }
            
        }
    }
}