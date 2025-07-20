using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace mhwilds.API.Controllers
{
    [ApiController]
    [Route("api/charms")]
    public class CharmsController : ControllerBase
    {
        private readonly ICharmService _charmService;
        private readonly ILogger<CharmsController> _logger;

        public CharmsController(
            ICharmService charmService,
            ILogger<CharmsController> logger)
        {
            _charmService = charmService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCharmResponse>>> GetAll()
        {
            try
            {
                var charms = await _charmService.GetAllAsync();
                return Ok(charms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all charms");
                return StatusCode(500, "An error occurred while retrieving charms");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetCharmResponse>> Get([FromRoute] int id)
        {
            try
            {
                var charm = await _charmService.GetByIdAsync(id);

                if (charm == null)
                {
                    return NotFound($"No charm found with ID: {id}.");
                }

                return Ok(charm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving charm with ID: {id}", id);
                return StatusCode(500, "An error occurred while retrieving charm");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCharmResponse>> Create([FromBody] CharmRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _charmService.CreateAsync(request);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating charm");
                return StatusCode(500, "An error occurred while creating charm");
            }
        }

        [HttpPost("range")]
        public async Task<ActionResult<List<GetCharmResponse>>> CreateRange([FromBody] List<CharmRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _charmService.CreateRangeAsync(requests);
                return CreatedAtAction(nameof(GetAll), response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating charms");
                return StatusCode(500, "An error occurred while creating charms");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetCharmResponse>> Update([FromRoute] int id, [FromBody] CharmRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _charmService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating charm with ID: {Id}", id);
                return StatusCode(500, "An error occurred while updating the charm");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleted = await _charmService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound($"Charm with ID: {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting charm with ID: {id}", id);
                return StatusCode(500, "An error occurred while deleting charm");
            }
        }
    }
}
