using Mapster;
using mhwilds_api.Models;
//using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using mhwilds_api.DTO.Request;
//using mhwilds_api.DTO.Response;
using mhwilds.Api.Application.Services;
using mhwilds.Api.Application.DTOs.Skills;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        //public SkillsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly SkillService _skillService;
        public SkillsController(SkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var skills = await _context.Skills
            //    .Include(s => s.Ranks)
            //    .ToListAsync();

            //if (skills == null || skills.Count == 0)
            //    return BadRequest("No skills found.");

            //var responses = skills.Adapt<List<GetSkillResponse>>();
            //return Ok(responses);

            var skills = await _skillService.GetAllSkillsAsync();
            if (skills == null || skills.Count == 0)
                return BadRequest("No skills found.");
            return Ok(skills);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            //var skill = await _context.Skills
            //    .Include(s => s.Ranks)
            //    .FirstOrDefaultAsync(s => s.Id == Id);

            //if (skill == null)
            //    return NotFound();

            //var response = skill.Adapt<GetSkillResponse>();

            //return Ok(response);
            var skill = await _skillService.GetSkillByIdAsync(Id);
            if (skill == null)
                return NotFound();
            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<CreateSkillRequest> skills)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var request = skills.Adapt<List<Skill>>();

            //_context.Skills.AddRange(request);
            //await _context.SaveChangesAsync();

            //var response = request.Adapt<List<GetSkillResponse>>();

            //// return 201 response, location: /api/skills
            //return Created("api/skills", response);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSkills = await _skillService.CreateSkillsAsync(skills);
            return Created("api/skills", createdSkills);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            //var skill = await _context.Skills.FindAsync(Id);
            //if (skill == null)
            //    return NotFound();

            //_context.Skills.Remove(skill);
            //await _context.SaveChangesAsync();

            //return NoContent();
            var deleted = await _skillService.DeleteSkillAsync(Id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
