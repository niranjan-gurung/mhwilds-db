using Mapster;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mhwilds_api.DTO.Response;

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
                .ThenInclude(cr => cr.Skills)
                .ToListAsync();

            if (charms == null || charms.Count == 0)
                return BadRequest("No charms found.");

            var response = charms.Adapt<List<GetCharmResponse>>();

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<Charm> charms)
        {
            if (charms == null || charms.Count == 0)
                return BadRequest("No charms found.");

            //var skillIds = charms
            //    .SelectMany(c => c.Ranks)
            //    .SelectMany(r => r.Skills)
            //    .Where(sr => sr.SkillId != 0)
            //    .Select(sr => sr.SkillId)
            //    .Distinct()
            //    .ToList();

            //// fetch all required skills in one database call
            //var existingSkillRanks = await _context.SkillRanks
            //    .Where(s => skillIds.Contains(s.Id))
            //    .ToDictionaryAsync(s => s.Id, s => s);

            //try
            //{
            //    foreach (var charm in charms)
            //    {
            //        if (charm.Ranks == null || charm.Ranks.Count == 0)
            //            return BadRequest($"Charm '{charm.Name}' must have at least one rank.");

            //        foreach (var rank in charm.Ranks)
            //        {
            //            rank.Charm = charm;

            //            if (rank.Skills != null)
            //            {
            //                var newSkillRanks = new List<SkillRank>();
            //                foreach (var skillRank in rank.Skills)
            //                {
            //                    if (skillRank.SkillId != 0)
            //                    {
            //                        if (existingSkillRanks.TryGetValue(skillRank.SkillId, out var existingSkillRank))
            //                            newSkillRanks.Add(existingSkillRank);
            //                        else
            //                            return BadRequest($"Skill with Id {skillRank.SkillId} not found.");
            //                    }
            //                    else
            //                    {
            //                        newSkillRanks.Add(skillRank);
            //                    }
            //                }

            //                rank.Skills = newSkillRanks;
            //            }
            //        }
            //        _context.Charms.Add(charm);
            //    }

            //    await _context.SaveChangesAsync();

            //    // return the created charms with assigned IDs
            //    var createdCharmsWithIds = await _context.Charms
            //        .Include(c => c.Ranks)
            //        .ThenInclude(r => r.Skills)
            //        .ThenInclude(sr => sr.Skill)
            //        .Where(c => charms.Select(ch => ch.Name).Contains(c.Name))
            //        .ToListAsync();

            //    var response = createdCharmsWithIds.Adapt<List<GetCharmResponse>>();
            //    return Ok(response);
            //}
            //catch (DbUpdateConcurrencyException dbEx)
            //{
            //    if (dbEx.InnerException?.Message.Contains("UNIQUE constraint") == true)
            //        return Conflict("A charm or rank with this data already exists.");

            //    return StatusCode(500, "Database error occurred while creating charms.");
            //}
            //catch (Exception ex) 
            //{
            //    return StatusCode(500, $"An unexpected error occurred while creating charms: {ex}");
            //}
            return Ok();
        }
    }
}
