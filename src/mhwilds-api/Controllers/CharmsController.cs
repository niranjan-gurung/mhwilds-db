using Mapster;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mhwilds_api.DTO.Response;
using mhwilds_api.DTO.Request;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/charms")]
    public class CharmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var charms = await _context.Charms
                .Include(c => c.Ranks)
                    .ThenInclude(r => r.Skills)
                        .ThenInclude(s => s.Skill)
                .ToListAsync();

            if (charms == null || charms.Count == 0)
                return BadRequest("No charms found.");

            var response = charms.Adapt<List<GetCharmResponse>>();

            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            var charm = await _context.Charms
                .Include(c => c.Ranks)
                    .ThenInclude(r => r.Skills)
                        .ThenInclude(s => s.Skill)
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (charm == null)
                return NotFound();

            var response = charm.Adapt<GetCharmResponse>();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<CreateCharmRequest> charms)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = charms.Adapt<List<Charm>>();

            for (int i = 0; i < request.Count; i++)
            {
                var dto = charms[i];
                var charm = request[i];

                for (int j = 0; j < charm.Ranks.Count; j++)
                {
                    var skillRankIds = dto.Ranks[j].Skills?
                        .Select(sr => sr.Id)
                        .ToList();

                    if (skillRankIds?.Count > 0)
                    {
                        var skillRanks = await _context.SkillRanks
                            .Where(sr => skillRankIds.Contains(sr.Id))
                            .Include(sr => sr.Skill)
                            .ToListAsync();

                        charm.Ranks[j].Skills = skillRanks;
                    }
                }
            }
            
            _context.Charms.AddRange(request);
            await _context.SaveChangesAsync();

            var response = charms.Adapt<List<GetCharmResponse>>();

            return Created("api/charms", response);
        }
    }
}
