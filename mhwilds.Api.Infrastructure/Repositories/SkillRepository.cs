using mhwilds.Api.Application.Interfaces;
using mhwilds.Api.Doman.Entities;
using mhwilds.Api.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace mhwilds.Api.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skills.Include(s => s.Ranks).ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Skills.Include(s => s.Ranks).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddRangeAsync(List<Skill> skills)
        {
            await _context.Skills.AddRangeAsync(skills);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }
    }
}
