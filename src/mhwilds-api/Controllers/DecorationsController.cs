using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Interfaces;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/decorations")]
    public class DecorationsController : ControllerBase
    {
        private readonly IDecorationService _decorationService;
        private readonly ILogger<DecorationsController> _logger;
        public DecorationsController(
            IDecorationService decorationService,
            ILogger<DecorationsController> logger)
        {
            _decorationService = decorationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetDecorationResponse>>> GetAll()
        {
            try
            {
                var decorations = await _decorationService.GetAllAsync();
                return Ok(decorations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all decorations");
                return StatusCode(500, "An error occurred while retrieving decorations");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetDecorationResponse>> Get([FromRoute] int id)
        {
            try
            {
                var decoration = await _decorationService.GetByIdAsync(id);

                if (decoration == null)
                {
                    return NotFound($"No decoration found with ID: {id}.");
                }

                return Ok(decoration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving decoration with ID: {id}", id);
                return StatusCode(500, "An error occurred while retrieving decoration");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetDecorationResponse>> Create([FromBody] DecorationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _decorationService.CreateAsync(request);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating decoration");
                return StatusCode(500, "An error occurred while creating decoration");
            }
        }

        [HttpPost("range")]
        public async Task<ActionResult<List<GetDecorationResponse>>> CreateRange([FromBody] List<DecorationRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _decorationService.CreateRangeAsync(requests);
                return CreatedAtAction(nameof(GetAll), response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating decorations");
                return StatusCode(500, "An error occurred while creating decorations");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetDecorationResponse>> Update([FromRoute] int id, [FromBody] DecorationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _decorationService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating decoration with ID: {Id}", id);
                return StatusCode(500, "An error occurred while updating the decoration");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _decorationService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound($"Decoration with ID: {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting decoration with ID: {id}", id);
                return StatusCode(500, "An error occurred while deleting decoration");
            }
        }
    }
}
