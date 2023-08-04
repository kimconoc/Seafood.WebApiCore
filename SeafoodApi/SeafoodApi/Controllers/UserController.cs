using AutoMapper;
using DoMains.DTO;
using DoMains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeafoodApi.Interfaces;
using SeafoodServices.Interfaces;
using SeafoodServices.Services;

namespace SeafoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IJwtUtils _jwtUtils;
        private IMapper _mapper;
        public UserController(IUserService userService, IJwtUtils jwtUtils,IMapper mapper)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn request)
        {
            var response = await _userService.SignIn(request);           
            var jwtToken = _jwtUtils.GenerateJwtToken(response);
            return Ok(new { token = jwtToken, response });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listUser = _userService.GetAllUser();
           
            if (listUser == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No user in database");
            }
            return StatusCode(StatusCodes.Status200OK, listUser);
        }
    }
}
