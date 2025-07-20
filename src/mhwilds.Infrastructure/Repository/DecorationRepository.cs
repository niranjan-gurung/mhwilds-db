using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Domain.Entities;
using mhwilds.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace mhwilds.Infrastructure.Repository
{
    public class DecorationRepository : IDecorationRepository
    {
        private readonly ApplicationDbContext _context;
        public DecorationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public CRUD Operations
        public async Task<List<Decoration>> GetAllAsync()
        {
            return await _context.Decorations
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .ToListAsync();
        }

        public async Task<Decoration?> GetByIdAsync(int id)
        {
            return await _context.Decorations
                .Include(s => s.Skills)
                    .ThenInclude(sr => sr.Skill)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Decoration> CreateAsync(Decoration decoration)
        {
            _context.Decorations.Add(decoration);
            await _context.SaveChangesAsync();
            return decoration;
        }

        public async Task<List<Decoration>> CreateRangeAsync(List<Decoration> decorations)
        {
            _context.Decorations.AddRange(decorations);
            await _context.SaveChangesAsync();
            return decorations;
        }

        public async Task<Decoration> UpdateAsync(Decoration decoration)
        {
            _context.Entry(decoration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return decoration;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var decoration = await _context.Decorations.FindAsync(id);

            if (decoration == null)
            {
                return false;
            }

            _context.Decorations.Remove(decoration);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
