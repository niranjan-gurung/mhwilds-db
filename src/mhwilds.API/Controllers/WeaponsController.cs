using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace mhwilds.API.Controllers
{
    [ApiController]
    [Route("api/weapons")]
    public class WeaponsController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        private readonly ILogger<WeaponsController> _logger;

        public WeaponsController(
            IWeaponService weaponService,
            ILogger<WeaponsController> logger)
        {
            _weaponService = weaponService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetWeaponResponse>>> GetAll()
        {
            try
            {
                var weapons = await _weaponService.GetAllAsync();
                return Ok(weapons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all weapons");
                return StatusCode(500, "An error occurred while retrieving weapons");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetWeaponResponse>> Get([FromRoute] int id)
        {
            try
            {
                var weapon = await _weaponService.GetByIdAsync(id);

                if (weapon == null)
                {
                    return NotFound($"No weapon found with ID: {id}.");
                }

                return Ok(weapon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving weapon with ID: {id}", id);
                return StatusCode(500, "An error occurred while retrieving weapon");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetWeaponResponse>> Create([FromBody] WeaponRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _weaponService.CreateAsync(request);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating weapon of type {WeaponType}", request.WeaponType);
                return StatusCode(500, "An error occurred while creating weapon");
            }
        }

        [HttpPost("range")]
        public async Task<ActionResult<List<GetWeaponResponse>>> CreateRange([FromBody] List<WeaponRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _weaponService.CreateRangeAsync(requests);
                return CreatedAtAction(nameof(GetAll), response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating multiple weapons");
                return StatusCode(500, "An error occurred while creating weapons");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetWeaponResponse>> Update([FromRoute] int id, [FromBody] WeaponRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _weaponService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating weapon with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating weapon");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleted = await _weaponService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound($"Weapon with ID {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting weapon with ID {Id}", id);
                return StatusCode(500, "An error occurred while deleting the weapon");
            }
        }
    }
}
