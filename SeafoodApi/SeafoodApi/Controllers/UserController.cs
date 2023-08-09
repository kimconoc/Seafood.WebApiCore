using AutoMapper;
using DoMains.DTO;
using DoMains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seafood.Domain.Common.FileLog;
using SeafoodApi.Configurations;
using SeafoodApi.Interfaces;
using SeafoodServices.Interfaces;
using SeafoodServices.Services;
using System.Reflection;

namespace SeafoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IJwtUtils _jwtUtils;
        public UserController(IUserService userService, IJwtUtils jwtUtils)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
        }
        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn request)
        {
            var response = await _userService.SignIn(request);           
            var jwtToken = _jwtUtils.GenerateJwtToken(response);
            return Ok(new { token = jwtToken, response });
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp request)
        {
            var response = await _userService.SignUp(request);
            return Ok(response);
        }
        [Route("getListUser")]
        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listUser = _userService.GetAllUser();
                if (listUser == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No user in database");
                }
                return StatusCode(StatusCodes.Status200OK, listUser);
            }
            catch (Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                return StatusCode(StatusCodes.Status200OK, "log");
            }
            
        }
    }
}
