using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models.Weapons;
using mhwilds_api.Models.Weapons.Melee;
using mhwilds_api.Models.Weapons.Ranged;
using mhwilds_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mhwilds_api.Controllers
{
    [ApiController]
    [Route("api/weapons")]
    public class WeaponsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WeaponsController> _logger;
        public WeaponsController(ApplicationDbContext context, ILogger<WeaponsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetWeaponResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<GetWeaponResponse>>> GetAll()
        {
            try
            {
                var weapons = await _context.Weapons
                    .Include(w => w.Skills)
                        .ThenInclude(s => s.Skill)
                    .ToListAsync();

                if (weapons.Count == 0)
                {
                    _logger.LogInformation("No weapons found in database");
                    return NotFound("No weapons found.");
                }

                var response = weapons.Adapt<List<GetWeaponResponse>>();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all weapons");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetWeaponResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetWeaponResponse>> Create([FromBody] CreateWeaponRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // mapster automatically maps to the correct weapon type based on the request
                var weapon = request.Adapt<BaseWeapon>();

                //BaseWeapon weapon = request switch
                //{
                //    CreateGreatswordRequest gs => gs.Adapt<Greatsword>(),
                //    CreateLongswordRequest ls => ls.Adapt<Longsword>(),
                //    CreateDualBladesRequest db => db.Adapt<DualBlades>(),
                //    CreateSwordAndShieldRequest sns => sns.Adapt<SwordAndShield>(),
                //    CreateHammerRequest hm => hm.Adapt<Hammer>(),
                //    CreateHuntingHornRequest hh => hh.Adapt<HuntingHorn>(),
                //    CreateGunlanceRequest gl => gl.Adapt<Gunlance>(),
                //    CreateLanceRequest lnc => lnc.Adapt<Lance>(),
                //    CreateChargeBladesRequest cb => cb.Adapt<ChargeBlade>(),
                //    CreateSwitchAxeRequest sa => sa.Adapt<SwitchAxe>(),
                //    CreateInsectGlaiveRequest ig => ig.Adapt<InsectGlaive>(),
                //    CreateLightBowgunRequest lbg => lbg.Adapt<LightBowgun>(),
                //    CreateHeavyBowgunRequest hbg => hbg.Adapt<HeavyBowgun>(),
                //    CreateBowRequest bow => bow.Adapt<Bow>(),
                //    _ => throw new InvalidOperationException("Unsupported weapon type.")
                //};

                // handle skills relationship if present
                if (request.Skills?.Count != 0)
                {
                    var skillRankIds = request.Skills?.Select(s => s.Id).ToList();
                    var skillRanks = await _context.SkillRanks
                        .Where(sr => skillRankIds.Contains(sr.Id))
                        .Include(sr => sr.Skill)
                        .ToListAsync();

                    weapon.Skills = skillRanks;
                }

                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();

                // Mapster automatically maps to the correct response type
                var response = weapon.Adapt<GetWeaponResponse>();
                _logger.LogInformation("Created new weapon with ID {Id} of type {WeaponType}", weapon.Id, weapon.WeaponType);

                //return CreatedAtAction(nameof(GetById), new { id = weapon.Id }, response);
                return Created("api/weapons", response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating weapon of type {WeaponType}", request.WeaponType);
                throw;
            }
        }
    }
}
