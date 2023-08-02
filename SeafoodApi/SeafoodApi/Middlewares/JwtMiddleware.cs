using Microsoft.Extensions.Options;
using SeafoodApi.Configurations;
using SeafoodServices.Interfaces;

namespace SeafoodApi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next) {  _next = next; }
        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var id = jwtUtils.ValidateJwtToken(token);
            if (id != null)
            {
                // attach user to context on successful jwt validation
                //context.Items["User"] = userService.GetUserToContext();
            }

            await _next(context);
        }
    }
}
