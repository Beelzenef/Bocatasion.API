using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bocatasion.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstController : ControllerBase
    {
        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Bocatasion API");
        }
    }
}
