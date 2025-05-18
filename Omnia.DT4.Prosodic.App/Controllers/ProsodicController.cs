using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Omnia.DT4.Prosodic.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsodicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello from API! - Under Construction" });
        }
    }
}
