using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
                    .ThenInclude(sr => sr.Skill)
                .ToListAsync();

            if (armours == null || armours.Count == 0)
                return BadRequest("No armours found.");

            var response = armours.Adapt<List<GetArmourResponse>>();

            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            var armour = await _context.Armours
                .Include(r => r.Resistances)
                .Include(a => a.Slots)
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .FirstOrDefaultAsync(a => a.Id == Id);

            if (armour == null)
                return NotFound();

            var response = armour.Adapt<GetArmourResponse>();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<CreateArmourRequest> armours)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = armours.Adapt<List<Armour>>();

            for (int i = 0; i < request.Count; i++)
            {
                var dto = armours[i];
                var armour = request[i];

                var skillRankIds = dto.Skills?
                    .Select(sr => sr.Id)
                    .ToList();

                if (skillRankIds.Count > 0)
                {
                    var skillRanks = await _context.SkillRanks
                        .Where(sr => skillRankIds.Contains(sr.Id))
                        .ToListAsync();

                    armour.Skills = skillRanks;
                }
            }

            _context.Armours.AddRange(request);
            await _context.SaveChangesAsync();

            var response = armours.Adapt<List<GetArmourResponse>>();

            // return 201 response, location: /api/armours
            return Created("api/armours", response);
        }

        [HttpPatch("{Id:int}")]
        public async Task<IActionResult> Patch([FromRoute] int Id, [FromBody] JsonPatchDocument<Armour> patchDoc)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var armour = await _context.Armours.FindAsync(Id);
            if (armour == null)
                return NotFound();

            _context.Armours.Remove(armour);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
