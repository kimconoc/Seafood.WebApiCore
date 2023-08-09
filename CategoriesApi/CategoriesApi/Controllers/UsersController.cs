using CategoriesApi.Interfaces;
using CategoryServices.Interfaces;
using Domains.DTOs;
using Domains.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesApi.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtUtil _jwtUtil;

        public UsersController(IUserService userService, IJwtUtil jwtUtil)
        {
            _userService = userService;
            _jwtUtil = jwtUtil;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var response = await _userService.SignIn(request);
            var jwtToken = _jwtUtil.GenerateJwtToken(response.Id);
            return Ok(new {token = jwtToken, response});
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            var response = await _userService.SignUp(request);
            return Ok(response);
        }

        [CategoriesApi.Configurations.Authorize(Role.Admin)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await _userService.GetUserById(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [CategoriesApi.Configurations.Authorize(Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            if(!(await _userService.ExistsUserById(id)))
            {
                return NotFound();
            }
            return Ok(new { message = "Deleted success!" });
        }
    } 
}
