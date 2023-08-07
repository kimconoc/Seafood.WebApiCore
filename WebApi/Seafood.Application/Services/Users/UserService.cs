using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Seafood.Data.Dtos;
using Seafood.Data.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly SeafoodDbcontext _context;
        private readonly IConfiguration _config;

        public UserService(SeafoodDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;

        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.UserName && u.PasswordHash == request.Password);
            if (user == null)
            {
                throw new Exception("Tài khoản hoặc mật khẩu không đúng");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Roles)
            };

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
