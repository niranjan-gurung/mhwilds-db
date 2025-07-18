using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
        Task<Skill> CreateAsync(Skill skill);
        Task<List<Skill>> CreateRangeAsync(List<Skill> skills);
        //Task<Skill> UpdateAsync(Skill skill);
        Task<bool> DeleteAsync(int id);
    }
}
