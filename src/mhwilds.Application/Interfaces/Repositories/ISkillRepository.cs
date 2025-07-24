using mhwilds.Domain.Entities;

namespace mhwilds.Application.Interfaces.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
        Task<Skill> CreateAsync(Skill skill);
        Task<List<Skill>> CreateRangeAsync(List<Skill> skills);
        Task<bool> DeleteAsync(int id);
        Task<List<SkillRank>> GetSkillRanksBySkillIdsAsync(List<int> skillIds);
        Task<List<SkillRank>> GetSkillRanksByIdsAsync(List<int> skillRankIds);
    }
}
