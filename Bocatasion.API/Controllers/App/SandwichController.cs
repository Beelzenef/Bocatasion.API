using Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bocatasion.API.Controllers.App
{
    [ApiController]
    [Route("[controller]")]
    [ControllerName("Sandwich and food controller, see all items available")]
    public class SandwichController : ControllerBase
    {
        private readonly ISandwichService _sandwichService;

        public SandwichController(ISandwichService sandwichService)
        {
            _sandwichService = sandwichService ?? throw new ArgumentNullException(nameof(sandwichService));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<SandwichInfoDto>> GetAllActiveSandwiches()
        {
            var result = _sandwichService.GetAllActiveSandwiches();

            return Ok(result);
        }

        // Get sandwich info

        // Request sandwich -> new controller? -> RequestController
    }
}
