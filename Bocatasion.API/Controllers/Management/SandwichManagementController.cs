using Bocatasion.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bocatasion.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SandwichManagementController : ControllerBase
    {
        private readonly ILogger<SandwichManagementController> _logger;
        private readonly SandwichService _sandwichService;

        public SandwichManagementController(ILogger<SandwichManagementController> logger)
        {
            _logger = logger;
            _sandwichService = new SandwichService();
        }

        [HttpGet]
        public IActionResult GetAllSandwiches()
        {
            var sandwiches = _sandwichService.GetAllSandwiches();

            return Ok(sandwiches);
        }
    }
}
