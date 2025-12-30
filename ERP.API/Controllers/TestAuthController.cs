using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestAuthController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("Public endpoint – no token needed");
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("Protected endpoint – JWT is VALID ✅");
        }
    }
}
