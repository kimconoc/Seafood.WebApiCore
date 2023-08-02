using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Seafood.Data.Entities;

namespace Seafood.WebApi.configurations
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;
        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }

            var user = (User)context.HttpContext.Items["User"];
            if (user == null || (_roles.Any() && !_roles.Contains(Enum.Parse<Role>(user.Roles))))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
