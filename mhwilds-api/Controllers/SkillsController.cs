using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Ok(skills);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var skill = await _context.Skills
                .Include(s => s.Ranks)
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (skill == null)
                return NotFound();

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<Skill> skills)
        {
            if (skills == null || !skills.Any())
                return BadRequest("No skills found.");

            _context.Skills.AddRange(skills);
            await _context.SaveChangesAsync();

            // return 201 response, location: /api/skills
            return Created("api/skills", skills);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, Skill skill)
        {
            if (Id != skill.Id)
                return BadRequest();

            _context.Entry(skill).State = EntityState.Modified;

            // handle related SkillRanks - this is important for updating related entities
            if (skill.Ranks != null)
            {
                // get existing ranks
                var existingRanks = await _context.SkillRanks
                    .Where(r => r.SkillId == Id)
                    .ToListAsync();

                // remove ranks that aren't in the update
                var rankIdsToKeep = skill.Ranks.Select(r => r.Id).ToList();
                var ranksToRemove = existingRanks
                    .Where(r => r.Id > 0 && !rankIdsToKeep.Contains(r.Id))
                    .ToList();

                foreach (var rank in ranksToRemove)
                {
                    _context.SkillRanks.Remove(rank);
                }

                // update or add ranks
                foreach (var rank in skill.Ranks)
                {
                    if (rank.Id == 0)
                    {
                        // this is a new rank, add it
                        rank.SkillId = Id;
                        _context.SkillRanks.Add(rank);
                    }
                    else
                    {
                        // This is an existing rank, update it
                        _context.Entry(rank).State = EntityState.Modified;
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(Id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
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

        private bool SkillExists(int Id)
        {
            return _context.Skills.Any(e => e.Id == Id);
        }
    }
}
