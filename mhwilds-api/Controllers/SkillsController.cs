using Mapster;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _context.Skills
                .Include(s => s.Ranks)
                .ToListAsync();

            if (skills == null || skills.Count == 0)
                return BadRequest("No skills found.");

            var responses = skills.Adapt<List<GetSkillResponse>>();
            return Ok(responses);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            var skill = await _context.Skills
                .Include(s => s.Ranks)
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (skill == null)
                return NotFound();

            var response = skill.Adapt<GetSkillResponse>();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<CreateSkillRequest> skills)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = skills.Adapt<List<Skill>>();

            _context.Skills.AddRange(request);
            await _context.SaveChangesAsync();

            var response = request.Adapt<List<GetSkillResponse>>();

            // return 201 response, location: /api/skills
            return Created("api/skills", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var skill = await _context.Skills.FindAsync(Id);
            if (skill == null)
                return NotFound();

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
