using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace mhwilds.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArmoursController : ControllerBase
    {
        private readonly IArmourService _armourService;
        private readonly ILogger<ArmoursController> _logger;
        public ArmoursController(
            IArmourService armourService, 
            ILogger<ArmoursController> logger)
        {
            _armourService = armourService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetArmourResponse>>> GetAll()
        {
            try
            {
                var armours = await _armourService.GetAllAsync();
                return Ok(armours);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all armours");
                return StatusCode(500, "An error occurred while retrieving armours");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetArmourResponse>> Get([FromRoute] int id)
        {
            try
            {
                var armour = await _armourService.GetByIdAsync(id);

                if (armour == null)
                {
                    return NotFound($"No armour found with ID: {id}.");
                }

                return Ok(armour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving armour with ID: {id}", id);
                return StatusCode(500, "An error occurred while retrieving armour");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetArmourResponse>> Create([FromBody] ArmourRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _armourService.CreateAsync(request);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating armour");
                return StatusCode(500, "An error occurred while creating armour");
            }

        }

        [HttpPost("range")]
        public async Task<ActionResult<List<GetArmourResponse>>> CreateRange([FromBody] List<ArmourRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _armourService.CreateRangeAsync(requests);
                return CreatedAtAction(nameof(GetAll), response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating armours");
                return StatusCode(500, "An error occurred while creating armours");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetArmourResponse>> Update([FromRoute] int id, [FromBody] ArmourRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _armourService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating armour with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the armour");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleted = await _armourService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound($"Armour with ID: {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting armour with ID: {id}", id);
                return StatusCode(500, "An error occurred while deleting armour");
            }
        }
    }
}
