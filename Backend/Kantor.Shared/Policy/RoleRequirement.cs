using Microsoft.AspNetCore.Authorization;

namespace Kantor.Shared.Policy
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public ICollection<RoleEnum> RoleList { get; }
        public RoleRequirement(ICollection<RoleEnum> roleList)
        {
            RoleList = roleList;
        }
    }
}
