using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Bocatasion.API.Controllers
{
    /// <summary>
    /// Sandwich management
    /// </summary>
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

        /// <summary>
        /// Gets all the sandwiches in menu
        /// </summary>
        /// <returns>A list of sandwiches</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllSandwiches()
        {
            var sandwiches = _sandwichService.GetAllSandwiches();

            return Ok(sandwiches);
        }

        /// <summary>
        /// Get a sandiwch by id
        /// </summary>
        /// <param name="id">Sandwich id</param>
        /// <returns>The selected sandiwch</returns>
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetSandwichById(int id)
        {
            var sandwich = _sandwichService.GetSandwichById(id);

            return Ok(sandwich);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateSandwich([FromBody] SandwichCreatableDto sandwichCreatableDto)
        {
            var result = _sandwichService.CreateSandwich(sandwichCreatableDto);

            return CreatedAtAction(nameof(GetSandwichById), new { id = result.Id }, result);
        }
    }
}
