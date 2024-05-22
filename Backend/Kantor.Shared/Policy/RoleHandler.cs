using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Kantor.Shared.Policy
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var userRoleClaim = context.User.FindAll(r => r.Type == ClaimTypes.Role);

            if (userRoleClaim is null)
                return Task.CompletedTask;

            foreach (var userClaim in userRoleClaim)
            {
                foreach (var role in requirement.RoleList)
                {
                    if (userClaim.Value == role.ToString())
                        context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
