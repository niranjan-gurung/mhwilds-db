using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
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
        private readonly ApplicationDbContext _context;
        public DecorationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var decorations = await _context.Decorations
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .ToListAsync();

            if (decorations == null || decorations.Count == 0)
                return BadRequest("No decoration found.");

            var response = decorations.Adapt<List<GetDeorationResponse>>();

            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int Id)
        {
            var decoration = await _context.Decorations
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .FirstOrDefaultAsync(d => d.Id == Id);

            if (decoration == null)
                return NotFound();

            var response = decoration.Adapt<GetDeorationResponse>();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<CreateDecorationRequest> decorations)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = decorations.Adapt<List<Decoration>>();

            for (int i = 0; i < request.Count; i++)
            {
                var dto = decorations[i];
                var deco = request[i];

                var skillRankIds = dto.Skills?
                    .Select(sr => sr.Id)
                    .ToList();

                if (skillRankIds.Count > 0)
                {
                    var skillRanks = await _context.SkillRanks
                        .Where(sr => skillRankIds.Contains(sr.Id))
                        .ToListAsync();

                    deco.Skills = skillRanks;
                }
            }

            _context.Decorations.AddRange(request);
            await _context.SaveChangesAsync();

            var response = decorations.Adapt<List<GetDeorationResponse>>();

            // return 201 response, location: /api/decorations
            return Created("api/decorations", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deco = await _context.Decorations.FindAsync(Id);
            if (deco == null)
                return NotFound();

            _context.Decorations.Remove(deco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
