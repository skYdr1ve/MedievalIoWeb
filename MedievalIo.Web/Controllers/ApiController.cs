using MedievalIo.Services.constants;
using Microsoft.AspNetCore.Mvc;

namespace MedievalIoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        protected string UserToken => User.FindFirst(AuthenticationConstants.Token)?.Value;

        protected string UserRole => User.FindFirst(AuthenticationConstants.Role)?.Value;
    }
}
