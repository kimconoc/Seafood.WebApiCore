using Seafood.Application.Services.Users;
using Seafood.WebApi.Interfaces;

namespace Seafood.WebApi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService, IJwtUtil jwtUtil)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split().Last();
            var id = jwtUtil.ValidateJwtToken(token);
            if (id != null)
            {
                context.Items["User"] = userService.GetUserById(id.Value).Result;
            }

            //context.Response.WriteAsync("tmp");
            await _requestDelegate(context);
        }
    }
}
