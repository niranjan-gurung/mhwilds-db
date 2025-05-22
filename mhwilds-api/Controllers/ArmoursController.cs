using mhwilds_api.Models;
using mhwilds_api.Services;
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
                .Include(a => a.Slots)
                .ToListAsync();

            return Ok(armours);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var armour = await _context.Armours
                .Include(a => a.Slots)
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

            _context.Armours.Add(armour);
            await _context.SaveChangesAsync();

            // return 201 response, location: /api/armours
            return Created("api/armours", armour);
        }
    }
}
