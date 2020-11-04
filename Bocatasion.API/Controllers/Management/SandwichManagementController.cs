using Bocatasion.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Bocatasion.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SandwichManagementController : ControllerBase
    {
        private readonly ILogger<SandwichManagementController> _logger;
        private readonly ISandwichService _sandwichService;

        public SandwichManagementController(ILogger<SandwichManagementController> logger,
            ISandwichService sandwichService)
        {
            _logger = logger;
            _sandwichService = sandwichService ?? throw new ArgumentNullException(nameof(sandwichService));
        }

        [HttpGet]
        public IActionResult GetAllSandwiches()
        {
            var sandwiches = _sandwichService.GetAllSandwiches();

            return Ok(sandwiches);
        }
    }
}
