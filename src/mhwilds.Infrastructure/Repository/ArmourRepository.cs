using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Domain.Entities;
using mhwilds.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace mhwilds.Infrastructure.Repository
{
    public class ArmourRepository : IArmourRepository
    {
        private readonly ApplicationDbContext _context;
        public ArmourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public CRUD Operations
        public async Task<List<Armour>> GetAllAsync()
        {
            return await _context.Armours
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .ToListAsync();
        }

        public async Task<Armour?> GetByIdAsync(int id)
        {
            return await _context.Armours
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Armour> CreateAsync(Armour armour)
        {
            _context.Armours.Add(armour);
            await _context.SaveChangesAsync();
            return armour;
        } 
        
        public async Task<List<Armour>> CreateRangeAsync(List<Armour> armours)
        {
            _context.Armours.AddRange(armours);
            await _context.SaveChangesAsync();
            return armours;
        }

        public async Task<Armour> UpdateAsync(Armour armour)
        {
            _context.Entry(armour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return armour;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var armour = await _context.Armours.FindAsync(id);
            
            if (armour == null)
            {
                return false;
            }

            _context.Armours.Remove(armour);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
