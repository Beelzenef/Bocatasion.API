using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bocatasion.API.Controllers
{
    /// <summary>
    /// Sandwich and food management
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ControllerName("Management of sandwiches and food")]
    public class SandwichManagementController : ControllerBase
    {
        private readonly ILogger<SandwichManagementController> _logger;
        private readonly ISandwichService _sandwichService;

        /// <summary>
        /// Sandwich and food management controller
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="sandwichService"></param>
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
        public ActionResult<List<SandwichDto>> GetAllSandwiches()
        {
            var sandwiches = _sandwichService.GetAllSandwiches();

            return Ok(sandwiches);
        }

        /// <summary>
        /// Get a sandiwch by id
        /// </summary>
        /// <param name="id">Sandwich id</param>
        /// <returns>The selected sandiwch</returns>
        [HttpGet("[action]/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<SandwichDto> GetSandwichById([Required] int id)
        {
            var sandwich = _sandwichService.GetSandwichById(id);

            return Ok(sandwich);
        }

        /// <summary>
        /// Creates a sandwich.
        /// </summary>
        /// <param name="sandwichCreatableDto">The creatable with sandwich data.</param>
        /// <returns>Sandwich created</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<SandwichDto> CreateSandwich([Required][FromBody] SandwichCreatableDto sandwichCreatableDto)
        {
            var result = _sandwichService.CreateSandwich(sandwichCreatableDto);

            return CreatedAtAction(nameof(GetSandwichById), new { id = result.Id }, result);
        }

        [HttpDelete("[action]/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult DeleteSandwich([Required] int id)
        {
            _sandwichService.DeleteSandwich(id);

            return Ok();
        }
    }
}
