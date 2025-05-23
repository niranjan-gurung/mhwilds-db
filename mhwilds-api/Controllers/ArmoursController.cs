using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/armours")]
    public class ArmoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var armours = await _context.Armours
                .Include(r => r.Resistances)
                .Include(a => a.Slots)
                .Include(s => s.Skills)
                .ToListAsync();

            return Ok(armours);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var armour = await _context.Armours
                .Include(r => r.Resistances)
                .Include(a => a.Slots)
                .Include(s => s.Skills)
                .FirstOrDefaultAsync(a => a.Id == Id);

            if (armour == null)
                return NotFound();

            return Ok(armour);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Armour armour)
        {
            if (armour == null)
                return BadRequest("No armour found.");

            if (armour.Skills != null && armour.Skills.Any())
            {
                var skillRankIds = armour.Skills.Select(sr => sr.Id).ToList();

                var existingSkillRanks = await _context.SkillRanks
                    .Where(sr => skillRankIds.Contains(sr.Id))
                    .ToListAsync();

                // Replace the Skills collection with the tracked entities
                armour.Skills = existingSkillRanks;
            }

            _context.Armours.Add(armour);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get), 
                new { Id = armour.Id },
                armour
            );
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Patch(int Id, [FromBody] JsonPatchDocument<Armour> patchDoc)
        {
            if (patchDoc != null)
            {
                var armour = await _context.Armours
                    .Include(r => r.Resistances)
                    .Include(a => a.Slots)
                    .FirstOrDefaultAsync(item => item.Id == Id);

                if (armour == null)
                    return NotFound();

                patchDoc.ApplyTo(armour, ModelState);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _context.SaveChangesAsync();

                return Ok(armour);
            }
            else
                return BadRequest(ModelState);
        }
    }
}
