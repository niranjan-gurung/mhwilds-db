using mhwilds_api.Interfaces;
using mhwilds_api.Models;
using mhwilds_api.Services;
using Microsoft.EntityFrameworkCore;

namespace mhwilds_api.Repository
{
    public class CharmRepository : ICharmRepository
    {
        private readonly ApplicationDbContext _context;
        public CharmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public CRUD Operations
        public async Task<List<Charm>> GetAllAsync()
        {
            return await _context.Charms
                .Include(c => c.Ranks)
                    .ThenInclude(r => r.Skills)
                        .ThenInclude(s => s.Skill)
                .ToListAsync();
        }

        public async Task<Charm?> GetByIdAsync(int id)
        {
            return await _context.Charms
                .Include(c => c.Ranks)
                    .ThenInclude(r => r.Skills)
                        .ThenInclude(s => s.Skill)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Charm> CreateAsync(Charm charm)
        {
            _context.Charms.Add(charm);
            await _context.SaveChangesAsync();
            return charm;
        }

        public async Task<List<Charm>> CreateRangeAsync(List<Charm> charms)
        {
            _context.Charms.AddRange(charms);
            await _context.SaveChangesAsync();
            return charms;
        }

        public async Task<Charm> UpdateAsync(Charm charm)
        {
            _context.Entry(charm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return charm;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var charm = await _context.Charms.FindAsync(id);

            if (charm == null)
            {
                return false;
            }

            _context.Charms.Remove(charm);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
