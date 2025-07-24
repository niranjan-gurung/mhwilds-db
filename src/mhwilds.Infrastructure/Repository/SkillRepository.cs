using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Domain.Entities;
using mhwilds.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace mhwilds.Infrastructure.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public CRUD Operations
        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skills
                .Include(s => s.Ranks)
                .ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Skills
                .Include(s => s.Ranks)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Skill> CreateAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<List<Skill>> CreateRangeAsync(List<Skill> skills)
        {
            _context.Skills.AddRange(skills);
            await _context.SaveChangesAsync();
            return skills;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                return false;
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SkillRank>> GetSkillRanksBySkillIdsAsync(List<int> skillIds)
        {
            return await _context.SkillRanks
                .Include(sr => sr.Skill)
                .Where(sr => skillIds.Contains(sr.SkillId))
                .ToListAsync();
        }

        public async Task<List<SkillRank>> GetSkillRanksByIdsAsync(List<int> skillRankIds)
        {
            return await _context.SkillRanks
                .Include(sr => sr.Skill)
                .Where(sr => skillRankIds.Contains(sr.Id))
                .ToListAsync();
        }
        #endregion
    }
}
