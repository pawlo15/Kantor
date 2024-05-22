using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kantor.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid _id
        {
            get
            {
                return Guid.Parse(
                    User.Identities.First()
                    .Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
        }
    }
}
