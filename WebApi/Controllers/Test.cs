using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class Test : Controller
    {
        [HttpGet]
        [Route("api")]
        public IActionResult Greet()
        {
            return Ok("You hit me!");
        }
    }
}
