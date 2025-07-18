using Mapster;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Interfaces;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly ILogger<SkillsController> _logger;
        public SkillsController(
            ISkillService skillService,
            ILogger<SkillsController> logger)
        {
            _skillService = skillService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetSkillResponse>>> GetAll()
        {
            try
            {
                var skills = await _skillService.GetAllAsync();
                return Ok(skills);      // returns 200 with empty array []
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all skills");
                return StatusCode(500, "An error occurred while retrieving skills");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetSkillResponse>> Get([FromRoute] int id)
        {
            try
            {
                var skill = await _skillService.GetByIdAsync(id);

                if (skill == null)
                {
                    return NotFound($"No skill found with ID: {id}.");
                }

                return Ok(skill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving skill with ID: {id}", id);
                return StatusCode(500, "An error occurred while retrieving skill");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<GetSkillResponse>>> Create([FromBody] List<SkillRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _skillService.CreateRangeAsync(requests);
                return CreatedAtAction(nameof(GetAll), response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating skills");
                return StatusCode(500, "An error occurred while creating skills");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleted = await _skillService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound($"Skill with ID: {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting skill with ID: {id}", id);
                return StatusCode(500, "An error occurred while deleting skill");
            }
        }
    }
}
