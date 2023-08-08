using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seafood.Application.Services.Users;
using Seafood.Data.Dtos;
using Seafood.WebApi.Interfaces;

namespace Seafood.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtUtil _jwtUtil;

        public UsersController(IUserService userService, IJwtUtil jwtUtil)
        {
            _userService = userService;
            _jwtUtil = jwtUtil;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.Authenticate(request);
            var jwtToken = _jwtUtil.GenerateJwtToken(response.Id);
            return Ok(new { token = jwtToken, response });
        }
    }
}
